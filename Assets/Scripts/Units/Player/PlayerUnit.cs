using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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

        public void OnEnable()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            currentHealth = baseStats.health;
        }

        private void Update()
        {
            HandleHealth();
        }


        public void MoveUnit(Vector3 _destination)
        {
            navAgent.SetDestination(_destination);
        }

        public void TakeDamage(float damage)
        {
            float totalDamage = damage - baseStats.armor;
            currentHealth -= totalDamage;
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

