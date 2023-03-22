using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace G.K.S.Units.Goblin
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class GoblinUnit : MonoBehaviour
    {
        private NavMeshAgent navAgent;

        public void OnEnable()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }


        public void MoveUnit(Vector3 _destination)
        {
            navAgent.SetDestination(_destination);
        }
    }
}

