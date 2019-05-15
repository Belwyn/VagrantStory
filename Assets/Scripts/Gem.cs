using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    [SerializeField]
    private int _strength;
    public int strength { get => _strength; private set => _strength = value; }

    [SerializeField]
    private int _intelligence;
    public int intelligence { get => _intelligence; private set => _intelligence = value; }

    [SerializeField]
    private int _agility;
    public int agility { get => _agility; private set => _agility = value; }


    [SerializeField]
    private AffinityData _affinityData;
    public AffinityData affinityData { get => _affinityData; private set => _affinityData = value; }


    [SerializeField]
    private ClassData _classData;
    public ClassData classData { get => _classData; private set => _classData = value; }





    // TODO think about this
    private object _specialProperty;





    private void OnGUI()
    {
        int x = 400;
        int y = 5;

        GUI.Label(new Rect(x, y, 200, 20), "Strength: " + strength); y += 10;
        GUI.Label(new Rect(x, y, 200, 20), "Intelligence: " + intelligence); y += 10;
        GUI.Label(new Rect(x, y, 200, 20), "Agility: " + agility); y += 20;

        GUI.Label(new Rect(x, y, 200, 20), "Class"); y += 10;
        for (int i = 0; i < Enum.GetNames(typeof(ClassEnum)).Length; i++)
        {
            GUI.Label(new Rect(x + 10, y, 200, 20), Enum.GetNames(typeof(ClassEnum))[i] + ": " + classData[i]);
            y += 10;
        }
        y += 10;

        GUI.Label(new Rect(x, y, 200, 20), "Affinity"); y += 10;
        for (int i = 0; i < Enum.GetNames(typeof(AffinityEnum)).Length; i++)
        {
            GUI.Label(new Rect(x + 10, y, 200, 20), Enum.GetNames(typeof(AffinityEnum))[i] + ": " + affinityData[i]);
            y += 10;
        }
        y += 10;
    }

}
