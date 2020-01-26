using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract component with a default behaviour as a Singleton
// Stores instance on Awake

namespace Belwyn.Utils {
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

        public static T instance { get; private set; }

        protected virtual void Awake() {
            if (instance != null) {
                Debug.LogWarning(name + " - Singleton instance already exists. This is not permitted ");
                Destroy(gameObject);
                return;
            }

            instance = GetComponent<T>();
        }

    }

}