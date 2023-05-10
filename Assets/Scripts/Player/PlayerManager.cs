using G.K.S.InputManager;
using UnityEngine;


namespace G.K.S.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;
        public Transform enemyUnits;
        public Transform playerBuildings;

        private void Awake()
        {
            instance = this;
            SetBasicUnitStats(playerUnits);
            SetBasicUnitStats(enemyUnits);
            SetBasicUnitStats(playerBuildings);

        }
        private void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }

        public void SetBasicUnitStats(Transform type)
        {
            foreach (Transform child in type)
            {
                foreach (Transform tf in child)
                {
                    string name = child.name.ToLower();
                    //var stats = Units.UnitHandler.instance.GetBasicUnitStats(name);

                    if (type == playerUnits)
                    {
                        Units.Player.PlayerUnit pU = tf.GetComponent<Units.Player.PlayerUnit>();
                        pU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);
                    }
                    else if (type == enemyUnits)
                    {

                        Units.Enemy.EnemyUnit eU = tf.GetComponent<Units.Enemy.EnemyUnit>();
                        eU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);
                    }
                    else if(type == playerBuildings)
                    {
                        Buildings.Player.PlayerBuilding pB = tf.GetComponent<Buildings.Player.PlayerBuilding>();
                        pB.baseStats = Buildings.BuildingHandler.instance.GetBasicBuildingStats(name);
                    }

                    //if we have any upgrades add them now
                    //add upgrages to unit stats
                }
            }
        }
    }
}

