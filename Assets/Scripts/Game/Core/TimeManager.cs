using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Belwyn.Utils;

namespace Vagrant.Game {
    public class TimeManager : SingletonBehaviour<TimeManager> {

        const float _normalScaleFactor = 1f;
        const float _slowScaleFactor = 0.025f;
        const float _slowScalePhysicsFactor = 0.01f;

        static float _normalFixedDeltaTime;

        private void Start() {

            GameManager.instance.timeManager = this;
            GameManager.instance.onTargetingMode.AddListener(FreezeScale);
            GameManager.instance.onNormalMode.AddListener(NormalScale);
        }

        public static void FreezeScale() {
            Time.timeScale = _slowScaleFactor;
            _normalFixedDeltaTime = Time.fixedDeltaTime;
            Time.fixedDeltaTime = _slowScalePhysicsFactor * Time.timeScale;
        }


        public static void NormalScale() {
            Time.timeScale = _normalScaleFactor;
            Time.fixedDeltaTime = _normalFixedDeltaTime;
        }


    }

}