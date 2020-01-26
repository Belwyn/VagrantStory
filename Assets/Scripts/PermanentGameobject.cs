using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utility component to make the gameobject that is attached to permanent between scenes.

namespace Belwyn.Utils {
 
    public class PermanentGameObject : MonoBehaviour {

        // Make the GameObject permanent on awake
        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }

    }

}