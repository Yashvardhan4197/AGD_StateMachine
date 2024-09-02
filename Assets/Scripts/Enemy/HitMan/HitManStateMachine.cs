using StatePattern.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Enemy
{
    public class HitManStateMachine : GenericStateMachine<HitManController>
    {
        public HitManStateMachine(HitManController owner) : base(owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<HitManController>(this));
            States.Add(StateMachine.States.PATROLLING, new PatrollingState<HitManController>(this));
            States.Add(StateMachine.States.CHASING, new ChasingState<HitManController>(this));
            States.Add(StateMachine.States.SHOOTING, new ShootingState<HitManController>(this));
            States.Add(StateMachine.States.TELEPORT, new TeleportationState<HitManController>(this));
        }
    }
}
