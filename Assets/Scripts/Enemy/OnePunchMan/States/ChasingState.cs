using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.Player;
using StatePattern.Main;

namespace StatePattern.Enemy
{
    public class ChasingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private PlayerController target;

        public ChasingState(IStateMachine stateMachine)=>this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            SetTarget();
            Owner.Agent.isStopped = false;
        }

        private void SetTarget()
        {
            target = GameService.Instance.PlayerService.GetPlayer();
        }

        public void OnStateExit()
        {
            target = null;
            Owner.Agent.isStopped = true;
        }

        public void Update()
        {
            Vector3 targetPos= target.Position;
            Owner.Agent.SetDestination(targetPos);
            if (Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance)
            {
                Owner.Agent.isStopped = true;
            }
            else
            {
                Owner.Agent.isStopped= false;
            }
        }
    }
}
