using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Vagrant.Game.TimeManager;

namespace Vagrant.Game {
    public class TimeScaledBehaviour : MonoBehaviour{


        protected float _selfTimescale;
        public float timescale {
            get { return _selfTimescale; }
            set { _selfTimescale = value; }
        }

        protected TimeStates _timeState;

        protected void Start() {

            // subscribe to timemanager
            TimeManager.instance.Subscribe(SetTimescale);

            SetTimescale(TimeStates.NORMAL, TimeManager.instance.GetTimescale(TimeStates.NORMAL));

        }

        private void OnDestroy() {
            TimeManager.instance.Unsubscribe(SetTimescale);
        }

        private void SetTimescale(float timescale) {
            _selfTimescale = timescale;
        }


        private void SetTimescale(TimeStates state, float scale) {

            _timeState = state;
            _selfTimescale = scale;
            
        }



    }
}
