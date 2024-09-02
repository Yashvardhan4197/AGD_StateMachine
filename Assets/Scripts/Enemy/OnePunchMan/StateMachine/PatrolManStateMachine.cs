using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : IStateMachine
    {
        public EnemyController Owner { get; private set; }
        private IState currentState;
        protected Dictionary<States, IState> StateList = new Dictionary<States, IState>();

        public PatrolManStateMachine(EnemyController owner)
        {
            Owner = owner;
            CreateStates();
            SetOwner();
        }
        public void ChangeState(States newState)
        {
            currentState?.OnStateExit();
            currentState = StateList[newState];
            currentState?.OnStateEnter();
        }

        public void CreateStates()
        {
            StateList.Add(States.IDLE, new IdleState(this));
            StateList.Add(States.ROTATING, new RotatingState(this));
            StateList.Add(States.SHOOTING, new ShootingState(this));
            StateList.Add(States.PATROLLING, new PatrollingState(this));
            StateList.Add(States.CHASING, new ChasingState(this));
        }

        public void SetOwner()
        {
            foreach(IState state in StateList.Values)
            {
                state.Owner = Owner;
            }
            StateList[States.IDLE].currentType = Owner.Data.Type;
        }

        public void Update()
        {
            currentState?.Update();
        }
    }
}
