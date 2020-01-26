using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Belwyn.Utils;


namespace Vagrant.Game.UI {

    [System.Serializable]
    class SelectablePool : Pool<SelectableSceneElement> { }


    public class SelectableManager : SingletonBehaviour<SelectableManager> {

        private List<SelectableSceneElement> _selectables;

        [SerializeField]
        private SelectablePool _pool;

        protected override void Awake() {
            base.Awake();
            _pool.Init(transform);
            _selectables = new List<SelectableSceneElement>();
        }

        public void SetSelectables(List<GameObject> selectables) {

            CleanSelectables();

            _selectables = selectables.ConvertAll(s => _pool.RetrieveItem().assignSceneObject(s.gameObject));

            foreach (SelectableSceneElement sce in _selectables) {
                sce.transform.SetParent(transform);
                sce.gameObject.SetActive(true);
            }

        }

        public void RemoveElement(GameObject sceneElement) {

            SelectableSceneElement sce = _selectables.First(s => s.sceneElement == sceneElement);
            RemoveSelectable(sce);
        }


        public void RemoveSelectable(SelectableSceneElement sce) {
            _selectables.Remove(sce);
            _pool.DestroyItem(sce);
        }


        public void CleanSelectables() {
            foreach (SelectableSceneElement sce in _selectables) {
                _pool.DestroyItem(sce);
            }
            _selectables.Clear();
        }
    }
}