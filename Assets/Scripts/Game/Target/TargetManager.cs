using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Belwyn.Utils;
using Vagrant.Game.UI;

namespace Vagrant.Game.Targeting {

    public class TargetManager : SingletonBehaviour<TargetManager> {

        private List<ITargetable> _targets;

        private bool _dirty = false;

        protected override void Awake() {
            base.Awake();
            _targets = new List<ITargetable>();
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
            _targets.ForEach( t => { message += $"{t.name}"; });

            Debug.Log(message);

            SelectableManager.instance.SetSelectables(_targets.ConvertAll( t => t.gameObject));
        }


        public void AddTarget(ITargetable target) {
            if (!_targets.Contains(target)) {
                _targets.Add(target);
                _dirty = true;
            }
        }
        
        public void RemoveTarget(ITargetable target) {
            if (_targets.Contains(target)) {
                _targets.Remove(target);
                _dirty = true;
            }
            //SelectableManager.instance.RemoveSelectable(target.gameObject);
        }


    }
}
