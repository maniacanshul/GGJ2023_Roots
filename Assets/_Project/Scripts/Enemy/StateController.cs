using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

using GGJ.Data;
using Unity.VisualScripting;

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
        [ReadOnly] public float stateTimeElapsed = 0f;

        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public EnemyManager EnemyManager;
        [HideInInspector] public int nextWayPoint;
        

        private void Awake() {
            navMeshAgent = GetComponent<NavMeshAgent>();
            EnemyManager = GetComponent<EnemyManager>();
        }

        private void Update() {
            m_currentState.UpdateState(this);

            stateTimeElapsed += Time.deltaTime;
        }

        public void TransitionToState(State nextState) {
            if (nextState == m_remainState) return;

            m_currentState.OnExitState(this);
            m_currentState = nextState;
            m_currentState.OnEnterState(this);
            OnExitState();
        }    

        private void OnExitState() {
            stateTimeElapsed = 0f;
        }
    }
}