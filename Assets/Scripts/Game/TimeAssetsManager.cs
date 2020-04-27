using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vagrant.Game {

    public class TimeAssetsManager : MonoBehaviour {

        [SerializeField]
        private TimeManager _timeManager;

        [Header("Materials")]
        [SerializeField]
        private string _materialTimeParameter;
        [SerializeField]
        private Material _highlightedMaterial;




        private void Start() {
            //_timeManager.normalScaleEvent.AddListener(UpdateAssets);
            //_timeManager.slowScaleEvent.AddListener(UpdateAssets);
        }



        private void UpdateAssets(float timescale) {
            _highlightedMaterial.SetFloat(_materialTimeParameter, 1 / timescale);
        }


    }

}