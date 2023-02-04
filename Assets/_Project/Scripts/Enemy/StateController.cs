using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

using GGJ.Data;

namespace GGJ.Enemies
{
    public class StateController : MonoBehaviour
    {
        [SerializeField] private State m_currentState;
        [SerializeField] private State m_remainState;
        public EnemyData enemyData;
        public List<Transform> wayPointList;

        [Header("Debug")]
        [ReadOnly] public Transform chaseTarget;

        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public int nextWayPoint;

        private void Awake() {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update() {
            m_currentState.UpdateState(this);
        }

        public void TransitionToState(State nextState) {
            if (nextState == m_remainState) return;

            m_currentState = nextState;
            OnExitState();
        }    

        private void OnExitState() {

        }
    }
}