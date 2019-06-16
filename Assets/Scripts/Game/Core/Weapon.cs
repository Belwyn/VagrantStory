using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Core {
    public class Weapon : MonoBehaviour {
        [SerializeField]
        private Blade _blade;
        public Blade blade { get => _blade; private set => _blade = value; }

        [SerializeField]
        private Grip _grip;
        public Grip grip { get => _grip; private set => _grip = value; }

        [SerializeField]
        private Gem[] _gems;
        public Gem[] gems { get => _gems; private set => _gems = value; }


        public BladeKindEnum bladeKind { get => _blade.bladeKind; }

        public int range { get => _blade.range; }
        public int risk { get => _blade.risk; }
        public int strength {
            get {
                int gemValue = 0;
                for (int i = 0; i < gems.Length; i++)
                    gemValue += gems[i].strength;
                return _blade.strength + _grip.strength + gemValue;
            }
        }
        public int intelligence {
            get {
                int gemValue = 0;
                for (int i = 0; i < gems.Length; i++)
                    gemValue += gems[i].intelligence;
                return _blade.intelligence + _grip.intelligence + gemValue;
            }
        }
        public int agility {
            get {
                int gemValue = 0;
                for (int i = 0; i < gems.Length; i++)
                    gemValue += gems[i].agility;
                return _blade.agility + _grip.agility + gemValue;
            }
        }

        public TypeEnum type { get => _blade.typeDamage; }
        public TypeData typeData { get => _grip.typeValues; }

        public int damagePtsMax { get => _blade.damagePtsMax; }
        public int damagePtsCurrent { get => _blade.damagePtsCurrent; }

        public int phantomPtsMax { get => _blade.phantomPtsMax; }
        public int phantomPtsCurrent { get => _blade.phantomPtsCurrent; }


        public ClassData classData {
            get {
                ClassData result = new ClassData();
                result += _blade.classData;
                for (int i = 0; i < _gems.Length; i++)
                    if (_gems[i] != null) result += _gems[i].classData;
                return result;
            }
        }

        public AffinityData affinityData {
            get {
                AffinityData result = new AffinityData();
                result += _blade.affinityData;
                for (int i = 0; i < _gems.Length; i++)
                    if (_gems[i] != null) result += _gems[i].affinityData;
                return result;
            }
        }


        public void Assemble(Blade assemblyBlade, Grip assemblyGrip, Gem[] assemblyGems, string assemblyName = "Weapon") {

            blade = assemblyBlade;
            grip = assemblyGrip;
            gems = assemblyGems;
            name = assemblyName;

            blade.transform.SetParent(transform);
            grip.transform.SetParent(transform);
            for (int i = 0; i < gems.Length; i++)
                gems[i].transform.SetParent(grip.transform);


        }

        private void OnGUI() {
            int x = 580;
            int y = 5;

            GUI.Label(new Rect(x, y, 200, 20), "Range: " + range); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Risk: " + risk); y += 20;

            GUI.Label(new Rect(x, y, 200, 20), "Strength: " + strength); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Intelligence: " + intelligence); y += 10;
            GUI.Label(new Rect(x, y, 200, 20), "Agility: " + agility); y += 20;

            GUI.Label(new Rect(x, y, 200, 20), "TypeDamage: " + type); y += 10;
            for (int i = 0; i < Enum.GetNames(typeof(TypeEnum)).Length; i++) {
                GUI.Label(new Rect(x + 10, y, 100, 20), Enum.GetNames(typeof(TypeEnum))[i] + ": " + typeData[i]);
                y += 10;
            }
            y += 10;

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