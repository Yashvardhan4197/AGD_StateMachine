using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingState : IStates
{

    private OnePunchManStateMachine stateMachine;
    private OnePunchManController owner;
    private float targetRotation;
    public RotatingState(OnePunchManStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void SetOwner(OnePunchManController owner)
    {
        this.owner = owner;
    }
    public void OnStateEnter()
    {
        targetRotation=(owner.Rotation.eulerAngles.y + 180) % 360;
    }

    public void OnStateExit()
    {
        targetRotation = 0;
    }

    public void Update()
    {
        owner.SetRotation(CalculateRotation());
        if (isRotationCompleted())
        {
            stateMachine.ChangeState(OnePunchManStates.Idle);
        }
    }

    private Vector3 CalculateRotation()
    {
        return Vector3.up* Mathf.MoveTowardsAngle(owner.Rotation.eulerAngles.y, targetRotation, owner.Data.RotationSpeed * Time.deltaTime);
    }

    private bool isRotationCompleted()
    {
        if(Mathf.Abs(Mathf.Abs(owner.Rotation.eulerAngles.y) - Mathf.Abs(targetRotation)) < owner.Data.RotationThreshold)
        {
            return true;
        }
        return false;
    }
}
