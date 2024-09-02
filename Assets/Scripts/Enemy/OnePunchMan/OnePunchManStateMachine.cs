
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : GenericStateMachine<OnePunchManController>
    {

        public OnePunchManStateMachine(OnePunchManController Owner): base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(global::States.IDLE, new IdleState<OnePunchManController>(this));
            States.Add(global::States.ROTATING, new RotatingState<OnePunchManController>(this));
            States.Add(global::States.SHOOTING, new ShootingState<OnePunchManController>(this));
        }

    }
}