using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using G.K.S.Units.Player;

namespace G.K.S.Units.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Tower : MonoBehaviour
    {
        private NavMeshAgent navAgent;

        public UnitStatTypes.Base baseStats;

        private Collider[] rangeColliders;

        private Transform aggroTarget;

        private Enemy.EnemyUnit aggroUnit;

        private bool hasAggro = false;

        private float distance;

        public GameObject unitStatsDisplay;

        public Image healthBarAmount;

        public float currentHealth;

        private float atkCooldown;

        private void Start()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            currentHealth = baseStats.health;
        }


        private void Update()
        {
            atkCooldown -= Time.deltaTime;

            if (!hasAggro)
            {
                CheckForEnemyTargets();
            }
            else
            {
                Attack();
            }
        }
        private void CheckForEnemyTargets()
        {
            rangeColliders = Physics.OverlapSphere(transform.position, baseStats.aggroRange, UnitHandler.instance.eUnitLayer);

            for (int i = 0; i < rangeColliders.Length;)
            {
                aggroTarget = rangeColliders[i].gameObject.transform;
                aggroUnit = aggroTarget.gameObject.GetComponent<Enemy.EnemyUnit>();
                hasAggro = true;
                break;
            }
        }

        private void Attack()
        {
            if (atkCooldown <= 0 && distance <= baseStats.atkRange + 1)
            {
                aggroUnit.TakeDamage(baseStats.attack);
                atkCooldown = baseStats.atkSpeed;
            }
        }
    }

}