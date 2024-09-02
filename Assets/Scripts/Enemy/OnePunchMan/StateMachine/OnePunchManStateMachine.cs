using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine: IStateMachine
    {
        private EnemyController Owner;
        private IState currentState;
        protected Dictionary<States, IState> StateList = new Dictionary<States, IState>();

        public OnePunchManStateMachine(EnemyController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        public void CreateStates()
        {
            StateList.Add(Enemy.States.IDLE, new IdleState(this));
            StateList.Add(Enemy.States.ROTATING, new RotatingState(this));
            StateList.Add(Enemy.States.SHOOTING, new ShootingState(this));
        }

        public void SetOwner()
        {
            foreach(IState state in StateList.Values)
            {
                state.Owner = Owner;
            }
        }

        public void Update() => currentState?.Update();

        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void ChangeState(States newState) => ChangeState(StateList[newState]);
    }

    public enum States
    {
        IDLE,
        ROTATING,
        SHOOTING,
        PATROLLING,
        CHASING
    }
}