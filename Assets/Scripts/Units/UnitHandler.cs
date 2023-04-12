using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using G.K.S.Player;

namespace G.K.S.Units
{   
    public class UnitHandler : MonoBehaviour
    {
        public static UnitHandler instance;

        [SerializeField]
        private BasicUnit worker, warrior, ranger;

        public LayerMask pUnitLayer, eUnitLayer;

        private void Awake()
        {
            instance = this;

        }

        private void Start()
        {
            pUnitLayer = LayerMask.NameToLayer("PlayerUnits");
            eUnitLayer = LayerMask.NameToLayer("EnemyUnits");
        }

        public UnitStatTypes.Base GetBasicUnitStats(string type)
        {
            BasicUnit unit;
            switch (type)
            {
                case "worker goblin":
                    unit = worker;
                    break;
                case "warrior goblin":
                    unit = warrior;
                    break;
                case "ranger goblin":
                    unit = ranger;
                    break;
                case "worker kobold":
                    unit = worker;
                    break;
                case "warrior kobold":
                    unit = warrior;
                    break;
                case "ranger kobold":
                    unit = ranger;
                    break;
                default:
                    Debug.Log($"Unit Type: {type} could not be found or does not exist!");
                    return null;
            }
            return unit.baseStats;
        }
        public void SetBasicUnitStats(Transform type)
        {
            Transform pUnits = PlayerManager.instance.playerUnits;
            Transform eUnits = PlayerManager.instance.enemyUnits;

            foreach (Transform child in type)
            {
                foreach (Transform tf in child)
                {
                    string name = child.name.ToLower();
                    var stats = GetBasicUnitStats(name);

                    if (type == pUnits)
                    {
                        Player.PlayerUnit pU = tf.GetComponent<Player.PlayerUnit>();
                        pU.baseStats = GetBasicUnitStats(name);
                    }
                    else if (type == eUnits)
                    {

                        Enemy.EnemyUnit eU = tf.GetComponent<Enemy.EnemyUnit>();
                        eU.baseStats = GetBasicUnitStats(name);
                    }

                    //if we have any upgrades add them now
                    //add upgrages to unit stats
                }
            }
        }

    }

}