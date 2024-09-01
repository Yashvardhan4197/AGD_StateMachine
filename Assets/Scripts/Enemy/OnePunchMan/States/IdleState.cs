using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IStates
{

    private OnePunchManStateMachine stateMachine;
    private OnePunchManController owner;
    private float IdleTimer;

    public IdleState(OnePunchManStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public void SetOwner(OnePunchManController owner)
    {
        this.owner = owner;
    }
    public void OnStateEnter()
    {
        ResetTimer();
    }

    public void OnStateExit()
    {
        IdleTimer = 0;
    }

    public void Update()
    {
        IdleTimer -= Time.deltaTime;
        if(IdleTimer < 0 )
        {
            stateMachine.ChangeState(OnePunchManStates.Rotating);
        }
    }

    private void ResetTimer() => IdleTimer = owner.Data.IdleTime;
}
