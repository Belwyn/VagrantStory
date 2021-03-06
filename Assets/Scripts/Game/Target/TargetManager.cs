﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Belwyn.Utils;
using Vagrant.Game.UI;
using Vagrant.Character;

namespace Vagrant.Game.Targeting {

    public class TargetManager : SingletonBehaviour<TargetManager> {

        private List<BaseTarget> _targets;
        
        private List<CharController> _affectedChars;
        public List<CharController> affectedChars => _affectedChars;


        private bool _dirty = false;

        protected override void Awake() {
            base.Awake();
            _targets = new List<BaseTarget>();
            _affectedChars = new List<CharController>();
        }


        private void Start() {
            //GameManager.instance.targetManager = this;
            //GameManager.instance.onTargetingMode.AddListener(RefreshTargets);
            //GameManager.instance.onNormalMode.AddListener(RefreshTargets);
        }


        private void Update() {
            
            if (_dirty) {
                RefreshTargets();
            }

            _dirty = false;
        }


        private void RefreshTargets() {
            // TODO
            string message = "Targets: \n";
            //string message = $"Targets: \n {string.Join("\n", _targets)}";
            _targets.ForEach( t => { message += $" {t.name} -"; });

            Debug.Log(message);

            UITargetManager.instance.SetSelectables(_targets);
        }


        public void AddTarget(BaseTarget target) {
            if (!_targets.Contains(target)) {
                _targets.Add(target);
                _dirty = true;
            }
        }
        
        public void RemoveTarget(BaseTarget target) {
            if (_targets.Contains(target)) {
                target.onNonHighlight();
                _targets.Remove(target);
                _dirty = true;
            }
            //SelectableManager.instance.RemoveSelectable(target.gameObject);
        }

        public void AddAffectedCharacter(CharController charController) {
            if (!_affectedChars.Contains(charController))
                _affectedChars.Add(charController);
        }

        public void ClearAffectedCharacters() {
            _affectedChars.Clear();
        }

    }
}
