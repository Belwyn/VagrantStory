using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Belwyn.Utils;
using Vagrant.Game.Player;
using Vagrant.Game.Targeting;
using Vagrant.Game.UI;


namespace Vagrant.Game {

    public class GameManager : SingletonBehaviour<GameManager> {


        public PlayerController playerController { private get; set; }
        public TargetManager targetManager { private get; set; }
        public TimeManager timeManager { private get; set; }


        [SerializeField]
        public UnityEvent onNormalMode;
        [SerializeField]
        public UnityEvent onTargetingMode;



        protected override void Awake() {
            base.Awake();
        }


        public void TargetingMode() {
            onTargetingMode.Invoke();
        }


        public void NormalMode() {
            onNormalMode.Invoke();
        }

    

    }

}