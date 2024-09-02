using StatePattern.StateMachine;
using System;
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class GenericStateMachine<T>where T:EnemyController
    {
        public T Owner { get; set; }
        public IState currentState;
        protected Dictionary<States,IState> States=new Dictionary<States,IState>();
        public GenericStateMachine(T owner)=>this.Owner=owner;
        public void ChangeState(States state) => changeState(state);

        protected void SetOwner()
        {
            foreach(var state in States.Values)
            {
                state.Owner = Owner;
            }
        }
        protected void changeState(States newState)
        {
            currentState?.OnStateExit();
            currentState = States[newState];
            currentState?.OnStateEnter();
        }

        public void Update()
        {
            currentState?.Update();
        }

    }
}
