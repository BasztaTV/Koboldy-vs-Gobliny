using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using G.K.S.Units.Enemy;

namespace G.K.S.Units.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerUnit : MonoBehaviour
    {
        private NavMeshAgent navAgent;

        public UnitStatTypes.Base baseStats;

        public GameObject unitStatsDisplay;

        public Image healthBarAmount;

        public float currentHealth;

        private Collider[] rangeColliders;

        private Transform aggroUnit;

        private bool hasAggro = false;

        private float distance;

        private float atkCooldown;
        



        public void OnEnable()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            currentHealth = baseStats.health;
        }

        private void Update()
        {
            atkCooldown -= Time.deltaTime;
            HandleHealth();
            if (aggroUnit != null)
            {
                navAgent.destination = aggroUnit.position;

                var distance = (transform.position - aggroUnit.position).magnitude;

                if (distance <= baseStats.atkRange)
                {
                    Attack();
                }
            }
        }

        public void SetNewTarget(Transform aggroTarget)
        {
            aggroUnit = aggroTarget;
        }

        private void Attack()
        {
            if (atkCooldown <= 0 && distance <= baseStats.atkRange + 1)
            {
                RTSGameManager.UnitTakeDamage(this, aggroUnit.GetComponent<EnemyUnit>());
                atkCooldown = baseStats.atkSpeed;
            }
        }

        public void TakeDamage(float damage)
        {
            float totalDamage = damage - baseStats.armor;
            currentHealth -= totalDamage;
        }

        public void MoveUnit(Vector3 _destination)
        {
            navAgent.SetDestination(_destination);
        }

        private void HandleHealth()
        {
            Camera camera = Camera.main;
            unitStatsDisplay.transform.LookAt(unitStatsDisplay.transform.position +
                camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

            healthBarAmount.fillAmount = currentHealth / baseStats.health;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}

