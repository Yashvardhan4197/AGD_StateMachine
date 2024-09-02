using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Enemy
{
    public class PatrollingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private int currentPatrollingIndex=0;
        private Vector3 destination;

        public PatrollingState(IStateMachine stateMachine)=>this.stateMachine = stateMachine;

        

        private void MoveToDestination()
        {
            Owner.Agent.isStopped = false;
            Owner.Agent.SetDestination(destination);
        }

        private Vector3 SetDestination()
        {
            return Owner.Data.PatrollingPoints[currentPatrollingIndex];
        }

        private void SetPatrollingIndex()
        {
            if (currentPatrollingIndex >= Owner.Data.PatrollingPoints.Count)
            {
                currentPatrollingIndex = 0;
                return;
            }
            currentPatrollingIndex++;
        }

        public void OnStateEnter()
        {
            SetPatrollingIndex();
            destination = SetDestination();
            MoveToDestination();
        }

        public void OnStateExit()
        {
            
        }

        public void Update()
        {
            if (Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance)
            {
                stateMachine.ChangeState(States.IDLE);
                Owner.Agent.isStopped = true;
            }
        }
    }
}
