using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Core {
    public class Blade : MonoBehaviour {
        [SerializeField]
        private BladeKindEnum _bladeKind;
        public BladeKindEnum bladeKind { get => _bladeKind; private set => _bladeKind = value; }

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
        private MaterialEnum _material;
        public MaterialEnum material { get => _material; private set => _material = value; }


        [SerializeField]
        private ClassData _classData;
        public ClassData classData { get => _classData; private set => _classData = value; }

        [SerializeField]
        private AffinityData _affinityData;
        public AffinityData affinityData { get => _affinityData; private set => _affinityData = value; }

        [SerializeField]
        private TypeEnum _typeAttack;
        public TypeEnum typeDamage { get => _typeAttack; private set => _typeAttack = value; }


        [SerializeField]
        private int _risk;
        public int risk { get => _risk; private set => _risk = value; }

        [SerializeField]
        private int _range;
        public int range { get => _range; private set => _range = value; }


        [SerializeField]
        private int _damagePtsMax;
        public int damagePtsMax { get => _damagePtsMax; private set => _damagePtsMax = value; }

        [SerializeField]
        private int _damagePtsCurrent;
        public int damagePtsCurrent { get => _damagePtsCurrent; private set => _damagePtsCurrent = value; }

        [SerializeField]
        private int _phantomPtsMax;
        public int phantomPtsMax { get => _phantomPtsMax; private set => _phantomPtsMax = value; }

        [SerializeField]
        private int _phantomPtsCurrent;
        public int phantomPtsCurrent { get => _phantomPtsCurrent; private set => _phantomPtsCurrent = value; }



        private void OnGUI() {

            int x = 130;
            int y = 5;

            GUI.Label(new Rect(x, y, 200, 20), "Range: " + range); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Risk: " + risk); y += 20;

            GUI.Label(new Rect(x, y, 200, 20), "Strength: " + strength); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Intelligence: " + intelligence); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Agility: " + agility); y += 20;

            GUI.Label(new Rect(x, y, 200, 20), "TypeDamage: " + typeDamage); y += 20;

            GUI.Label(new Rect(x, y, 200, 20), "Damage pts Max: " + damagePtsMax); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Damage pts current: " + damagePtsCurrent); y += 20;

            GUI.Label(new Rect(x, y, 200, 20), "Phantom pts Max: " + phantomPtsMax); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Phantom pts current: " + phantomPtsCurrent); y += 20;

            GUI.Label(new Rect(x, y, 200, 20), "Class"); y += 10;
            for (int i = 0; i < Enum.GetNames(typeof(ClassEnum)).Length; i++) {
                GUI.Label(new Rect(x + 10, y, 200, 20), Enum.GetNames(typeof(ClassEnum))[i] + ": " + classData[i]);
                y += 10;
            }
            y += 10;

            GUI.Label(new Rect(x, y, 200, 20), "Affinity"); y += 10;
            for (int i = 0; i < Enum.GetNames(typeof(AffinityEnum)).Length; i++) {
                GUI.Label(new Rect(x + 10, y, 200, 20), Enum.GetNames(typeof(AffinityEnum))[i] + ": " + affinityData[i]);
                y += 10;
            }
            y += 10;

        }

    }
}