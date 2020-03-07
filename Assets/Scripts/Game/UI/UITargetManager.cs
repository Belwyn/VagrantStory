using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Belwyn.Utils;
using Vagrant.Game.Targeting;



namespace Vagrant.Game.UI {

    [System.Serializable]
    class SelectablesPool : Pool<UITarget> { }


    public class UITargetManager : SingletonBehaviour<UITargetManager> {

        private List<UITarget> _selectables;
        private UITarget _current;


        [SerializeField]
        private SelectablesPool _pool;

        [SerializeField]
        private Transform _poolTransform;

        protected override void Awake() {
            base.Awake();
            _pool.Init(_poolTransform);
            _selectables = new List<UITarget>();
        }

        void Update() {
            GameObject currentSelected = EventSystem.current.currentSelectedGameObject;

            if (currentSelected != null && _selectables.Count > 0) {
                UITarget newCurrent = _selectables.Single(s => s.button == currentSelected.GetComponent<Button>());
                if (newCurrent != null && newCurrent != _current) {
                    _current = newCurrent;
                    UpdateHighlight();
                }
            }


        }


        private void UpdateHighlight() {
            foreach(UITarget selectable in _selectables) {
                if (selectable == _current)
                    selectable.onHighlight();
                else
                    selectable.onNonHighlight();
            }
        }


        public void SetSelectables(List<BaseTarget> targets) {

            CleanSelectables();

            _selectables = targets.ConvertAll(t => _pool.RetrieveItem().assignTarget(t));

            foreach (UITarget sce in _selectables) {
                sce.transform.SetParent(transform);
                sce.gameObject.SetActive(true);
                sce.button.navigation = Navigation.defaultNavigation;
            }




            //EventSystem.current.SetSelectedGameObject(_selectables.Count > 0 ? _selectables[0].gameObject : null);
            if (_selectables.Count > 0) {
                _selectables[0].button.Select();
                EventSystem.current.firstSelectedGameObject = _selectables[0].gameObject;
            }

        }

        public void RemoveElement(GameObject sceneElement) {

            UITarget sce = _selectables.First(s => s.target == sceneElement);
            RemoveSelectable(sce);
        }


        public void RemoveSelectable(UITarget sce) {
            _selectables.Remove(sce);
            _pool.DestroyItem(sce);
        }


        public void CleanSelectables() {
            foreach (UITarget sce in _selectables) {
                _pool.DestroyItem(sce);
            }
            _selectables.Clear();
        }
    }
}