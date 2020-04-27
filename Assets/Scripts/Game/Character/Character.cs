using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vagrant.Game;

namespace Vagrant.Character {

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Animator))]

    public class Character : MonoBehaviour {

        private Rigidbody _rigidbody;
        private Collider _collider;
        private Animator _animator;
        private const float k_Half = 0.5f;

        private float _originalGroundCheckDistance;

        // Config
        [Header("Configuration")]
        [SerializeField]
        private float _groundCheckDistance = 0.1f;
        [SerializeField]
        private float _jumpPower = 12f;
        [Range(1f, 4f)] 
        [SerializeField] 
        private float _gravityMultiplier = 2f;
        [SerializeField] 
        private float _moveSpeedMultiplier = 1f;
        [SerializeField]
        float _movingTurnSpeed = 360;
        [SerializeField]
        float _stationaryTurnSpeed = 180;


        [Header("Animation")]
        [SerializeField]
        float _runCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
        [SerializeField]
        float _animSpeedMultiplier = 1f;


        // State
        private Vector3 _groundNormal;
        private bool _isGrounded;
        private float _turnAmount;
        private float _forwardAmount;

        private Vector3 _previousVelocity;


        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _animator = GetComponent<Animator>();

        }


        private void Start() {

            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            _originalGroundCheckDistance = _groundCheckDistance;
            _previousVelocity = new Vector3();
        }


        private void FixedUpdate() {
            //_previousVelocity = _rigidbody.velocity;
            //_rigidbody.velocity *= _timeScaledBehaviour.timescale;
            //_rigidbody.useGravity = false;
            /*
            _rigidbody.AddForce(_rigidbody.velocity * (1 - _timeScaledBehaviour.timescale) * _timeScaledBehaviour.timescale);
            
            _rigidbody.AddForce(Physics.gravity * _timeScaledBehaviour.timescale);*/
        }


        private void OnDrawGizmos() {
            if (_rigidbody != null) {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(_rigidbody.worldCenterOfMass, _rigidbody.worldCenterOfMass + _rigidbody.velocity);
            }
        }



        private void CheckGround() {

            RaycastHit hitInfo;
#if UNITY_EDITOR
            // helper to visualise the ground check ray in the scene view
            Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * _groundCheckDistance));
#endif
            // 0.1f is a small offset to start the ray from inside the character
            // it is also good to note that the transform position in the sample assets is at the base of the character
            if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, _groundCheckDistance)) {
                _groundNormal = hitInfo.normal;
                _isGrounded = true;
                _animator.applyRootMotion = false;
            } else {
                _isGrounded = false;
                _groundNormal = Vector3.up;
                _animator.applyRootMotion = false;
            }

        }



        private void HandleGroundMovement(bool jump) {

            if (jump && _animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded")) {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpPower, _rigidbody.velocity.z);
                _isGrounded = false;
                _animator.applyRootMotion = false;
                _groundCheckDistance = 0.1f;
            }

        }


        private void HandleAirborneMovement() {

            Vector3 extraGravityForce = (Physics.gravity * _gravityMultiplier) - Physics.gravity;
            _rigidbody.AddForce(extraGravityForce);

            _groundCheckDistance = _rigidbody.velocity.y < 0 ? _originalGroundCheckDistance : 0.01f;
        }


        void ApplyExtraTurnRotation() {
            // help the character turn faster (this is in addition to root rotation in the animation)
            float turnSpeed = Mathf.Lerp(_stationaryTurnSpeed, _movingTurnSpeed, _forwardAmount);
            transform.Rotate(0, _turnAmount * turnSpeed * Time.deltaTime, 0);
        }



        public void Move(Vector3 move, bool jump) {

            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);

            CheckGround();
            move = Vector3.ProjectOnPlane(move, _groundNormal);

            _turnAmount = Mathf.Atan2(move.x, move.z);
            _forwardAmount = move.z;

            // Apply extra turn rotation
            ApplyExtraTurnRotation();


            if (_isGrounded) {
                HandleGroundMovement(jump);
            } 
            else {
                HandleAirborneMovement();
            }


            UpdateAnimator(move);
        }




        /////////// ANIMATOR

        private void UpdateAnimator(Vector3 move) {

            // update the animator parameters
            _animator.SetFloat("Forward", _forwardAmount, 0.1f, Time.deltaTime);
            _animator.SetFloat("Turn", _turnAmount, 0.1f, Time.deltaTime);
            //_animator.SetBool("Crouch", m_Crouching);
            _animator.SetBool("OnGround", _isGrounded);
            if (!_isGrounded) {
                _animator.SetFloat("Jump", _rigidbody.velocity.y);
            }

            // calculate which leg is behind, so as to leave that leg trailing in the jump animation
            // (This code is reliant on the specific run cycle offset in our animations,
            // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
            float runCycle =
                Mathf.Repeat(
                    _animator.GetCurrentAnimatorStateInfo(0).normalizedTime + _runCycleLegOffset, 1);
            float jumpLeg = (runCycle < k_Half ? 1 : -1) * _forwardAmount;
            if (_isGrounded) {
                _animator.SetFloat("JumpLeg", jumpLeg);
            }

            // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
            // which affects the movement speed because of the root motion.
            if (_isGrounded && move.magnitude > 0) {
                _animator.speed = _animSpeedMultiplier;
            } else {
                // don't use that while airborne
                _animator.speed = 1;
            }

        }

        public void OnAnimatorMove() {
            // we implement this function to override the default root motion.
            // this allows us to modify the positional speed before it's applied.
            if (_isGrounded && Time.deltaTime > 0) {
                Vector3 v = (_animator.deltaPosition * _moveSpeedMultiplier) / Time.deltaTime;

                // we preserve the existing y part of the current velocity.
                v.y = _rigidbody.velocity.y;
                _rigidbody.velocity = v;
            }
        }


    }

}