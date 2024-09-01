using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnePunchManStateMachine : MonoBehaviour
{
    public OnePunchManController Owner {  get; private set; }
    private Dictionary<OnePunchManStates, IStates> states = new Dictionary<OnePunchManStates, IStates>();
    private IStates currentState;

    public OnePunchManStateMachine(OnePunchManController owner)
    {
        this.Owner = owner;
        InitializeStates();
        SetOwner();
    }

    public void InitializeStates()
    {
        states.Add(OnePunchManStates.Idle,new  IdleState(this));
        states.Add(OnePunchManStates.Rotating,new RotatingState(this));
        states.Add(OnePunchManStates.Shooting,new ShootingState(this));
    }

    public void SetOwner()
    {
        foreach(IStates state in states.Values)
        {
            state.SetOwner(Owner);
        }
    }

    private void Update()
    {
        currentState?.Update();
    }

    protected void changeState(OnePunchManStates state)
    {
        currentState?.OnStateExit();
        currentState = states[state];
        currentState?.OnStateEnter();
    }

    public void ChangeState(OnePunchManStates state) => changeState(state);
}
