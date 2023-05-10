using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace G.K.S.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName ="New Unit/Basic")]
    public class BasicUnit : ScriptableObject
    {
        public enum unitType
        {
            Worker,
            Warrior,
            Ranger

        };

        [Space(15)]
        [Header("Unit Settings")]
        public unitType type;

        public new string name;

        public GameObject goblinPrefab;
        public GameObject koboldPrefab;
        public GameObject ratPrefab;
        public GameObject icon;
        public float spawnTime;

        [Space(15)]
        [Header("Unit Stats")]
        [Space(40)]

        public UnitStatTypes.Base baseStats;
    }
}
