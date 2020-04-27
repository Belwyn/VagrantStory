using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vagrant.Character;

using Belwyn.Utils;
using Belwyn.Events;

namespace Vagrant.Game {
    public class TimeManager : SingletonBehaviour<TimeManager> {

        public enum TimeStates {
            NORMAL,
            SLOW
        }

        const float _normalScaleFactor = 1f;
        const float _slowScaleFactor = 0.01f;
        //const float _slowScalePhysicsFactor = 0.01f;

        readonly Dictionary<TimeStates, float> _timeScales = new Dictionary<TimeStates, float> {
            { TimeStates.NORMAL,    _normalScaleFactor },
            { TimeStates.SLOW,      _slowScaleFactor }
        };

        //static float _normalFixedDeltaTime;

        private FloatEvent _normalScaleEvent;
        private FloatEvent _slowScaleEvent;



        protected override void Awake() {
            base.Awake();
            _normalScaleEvent = new FloatEvent();
            _slowScaleEvent = new FloatEvent();
            //_normalFixedDeltaTime = Time.fixedDeltaTime;
        }

        private void Start() {
            GameManager.instance.timeManager = this;
            GameManager.instance.onTargetingMode.AddListener(FreezeScale);
            GameManager.instance.onNormalMode.AddListener(NormalScale);
            GameManager.instance.onActionMode.AddListener(ActionSetupScale);


            NormalScale();
        }



        public void Subscribe(UnityAction<float> action) {
            _normalScaleEvent.AddListener(action);
            _slowScaleEvent.AddListener(action);
        }

        public void Unsubscribe(UnityAction<float> action) {
            _normalScaleEvent.RemoveListener(action);
            _slowScaleEvent.AddListener(action);
        }


        public float GetTimescale(TimeStates state) {
            return _timeScales[state];
        }


        public void FreezeScale() {
            //Time.timeScale = _slowScaleFactor;
            //Time.fixedDeltaTime = _slowScalePhysicsFactor * Time.timeScale;
            _slowScaleEvent.Invoke(_timeScales[TimeStates.SLOW]);
        }


        public void NormalScale() {
            //Time.timeScale = _normalScaleFactor;
            //Time.fixedDeltaTime = _normalFixedDeltaTime;
            _normalScaleEvent.Invoke(_timeScales[TimeStates.NORMAL]);
        }


        public void ActionSetupScale() {
            _slowScaleEvent.Invoke(_timeScales[TimeStates.SLOW]);
            List<CharController> affected = GameManager.instance.GetActionAffectedChars();
            /*foreach (CharController character in affected) {
                character.GetComponent<TimeScaledBehaviour>().timescale = _timeScales[TimeStates.NORMAL];
            }*/

        }

    }

}