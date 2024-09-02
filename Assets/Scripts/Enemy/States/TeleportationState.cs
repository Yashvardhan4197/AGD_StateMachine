using StatePattern.StateMachine;
using StatePattern.Main;
using StatePattern.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.Enemy
{
    public class TeleportationState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }

        private GenericStateMachine<T> stateMachine;
        public TeleportationState(GenericStateMachine<T> stateMachine)=>this.stateMachine= stateMachine;

        public void OnStateEnter()
        {
            TeleportEnemy();
            stateMachine.ChangeState(States.CHASING);
        }

        private void TeleportEnemy() => Owner.Agent.Warp(NewLocation());

        private Vector3 NewLocation()
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * Owner.Data.TeleportingRadius + Owner.Position;

            NavMeshHit Hit;
            if (NavMesh.SamplePosition(randomDirection, out Hit, Owner.Data.TeleportingRadius, NavMesh.AllAreas))
                return Hit.position;
            return Owner.Data.SpawnRotation;
        }

        public void OnStateExit()
        {
        }

        public void Update()
        {
        }
    }
}
