using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using G.K.S.Units.Enemy;

namespace G.K.S.Units.Player

{
    public class RTSGameManager : MonoBehaviour
    {
        public static void UnitTakeDamage(PlayerUnit attackingController,EnemyUnit attackedController)
        {
            var damage = attackingController.baseStats.attack;

            attackedController.TakeDamage(attackingController, damage);
        }
    }

}

