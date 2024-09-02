using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class CloneManStateMachine : GenericStateMachine<CloneManController>
    {
        public Vector3 spawnPos;
        public CloneManStateMachine(CloneManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<CloneManController>(this));
            States.Add(StateMachine.States.PATROLLING, new PatrollingState<CloneManController>(this));
            States.Add(StateMachine.States.CHASING, new ChasingState<CloneManController>(this));
            States.Add(StateMachine.States.SHOOTING, new ShootingState<CloneManController>(this));
            States.Add(StateMachine.States.CLONE, new CloneState<CloneManController>(this));
        }
    }
}
