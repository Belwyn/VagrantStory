using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Core {
    [Serializable]
    public class TypeData {

        [SerializeField]
        int[] _values = new int[Enum.GetValues(typeof(TypeEnum)).Length];

        public int this[int i] {
            get { return _values[i]; }
            private set { _values[i] = value; }
        }

        public int this[TypeEnum a] {
            get { return this[(int)a]; }
            private set { this[(int)a] = value; }
        }


        public static TypeData operator +(TypeData td1, TypeData td2) {
            for (int i = 0; i < td1._values.Length; i++) td1[i] += td2[i];
            return td1;
        }

        public TypeData() {
            for (int i = 0; i < _values.Length; i++) {
                _values[i] = 0;
            }
        }

    }
}