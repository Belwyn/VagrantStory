using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip : MonoBehaviour
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
    private BladeKindEnum[] _compatibleBladeKinds;
    public BladeKindEnum[] compatibleBladeKinds { get => _compatibleBladeKinds; private set => _compatibleBladeKinds = value; }


    [SerializeField]
    private TypeData _typeValues;
    public TypeData typeValues { get => _typeValues; private set => _typeValues = value; }


    [SerializeField]
    private int _gemSlots;
    public int gemSlots { get => _gemSlots; private set => _gemSlots = value; }



    private void OnGUI()
    {
        int x = 280;
        int y = 5;

        GUI.Label(new Rect(x, y, 200, 20), "Strength: " + strength); y += 10;
        GUI.Label(new Rect(x, y, 200, 20), "Intelligence: " + intelligence); y += 10;
        GUI.Label(new Rect(x, y, 200, 20), "Agility: " + agility); y += 20;

        GUI.Label(new Rect(x, y, 200, 20), "Type"); y += 10;
        for (int i = 0; i < Enum.GetNames(typeof(TypeEnum)).Length; i++)
        {
            GUI.Label(new Rect(x + 10, y, 100, 20), Enum.GetNames(typeof(TypeEnum))[i] + ": " + typeValues[i]);
            y += 10;
        }
        y += 10;

        GUI.Label(new Rect(x, y, 200, 20), "Gem Slots: " + gemSlots); y += 10;
    }

}
