using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClassData
{

    [SerializeField]
    int[] _values = new int[Enum.GetValues(typeof(ClassEnum)).Length];

    public int this[int i] {
        get { return _values[i]; }
        private set { _values[i] = value; }
    }

    public int this[TypeEnum a] {
        get { return this[(int)a]; }
        private set { this[(int)a] = value; }
    }


    public static ClassData operator +(ClassData cd1, ClassData cd2)
    {
        for (int i = 0; i < cd1._values.Length; i++) cd1[i] += cd2[i];
        return cd1;
    }


    public ClassData()
    {
        for (int i = 0; i < _values.Length; i++)
        {
            _values[i] = 0;
        }
    }

}
