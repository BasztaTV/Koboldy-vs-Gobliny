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

        public bool isPlayerUnit;

        public unitType type;

        public new string name;

        public GameObject goblinPrefab;
        public GameObject koboldPrefab;
        public GameObject ratPrefab;

        public int cost;
        public int attack;
        public int health;
        public int armor;
    }
}
