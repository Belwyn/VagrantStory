using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Core {
    [Serializable]
    public class AffinityData {

        [SerializeField]
        int[] _values = new int[Enum.GetValues(typeof(AffinityEnum)).Length];

        public int this[int i] {
            get { return _values[i]; }
            private set { _values[i] = value; }
        }

        public int this[AffinityEnum a] {
            get { return this[(int)a]; }
            private set { this[(int)a] = value; }
        }


        public static AffinityData operator +(AffinityData ad1, AffinityData ad2) {
            for (int i = 0; i < ad1._values.Length; i++) ad1[i] += ad2[i];
            return ad1;
        }


        public AffinityData() {
            for (int i = 0; i < _values.Length; i++) {
                _values[i] = 0;
            }
        }




    }
}