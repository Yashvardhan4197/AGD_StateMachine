using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using StatePattern.Player;

public class ShootingState : IStates
{
    private OnePunchManStateMachine stateMachine;
    private OnePunchManController owner;
    private PlayerController target;
    private float shootTimer;

    public ShootingState(OnePunchManStateMachine onePunchManStateMachine)
    {
        stateMachine = onePunchManStateMachine;
    }

    public void SetOwner(OnePunchManController owner)
    {
        this.owner = owner;
    }


    public void OnStateEnter()
    {
        target=owner.target;
        shootTimer = 0;

    }

    public void OnStateExit() 
    {
        target = null;
        shootTimer = 0;
    }

    public void Update()
    {
        Quaternion desiredRotation = CalculateRotationTowardsPlayer();
        owner.SetRotation(RotateTowards(desiredRotation));
        if(IsFacingPlayer(desiredRotation))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = owner.Data.RateOfFire;
                owner.Shoot();
            }
        }
    }

    private Quaternion CalculateRotationTowardsPlayer()
    {
        Vector3 directionToPlayer = target.Position - owner.Position;
        directionToPlayer.y = 0f;
        return Quaternion.LookRotation(directionToPlayer, Vector3.up);
    }
    private Quaternion RotateTowards(Quaternion desiredRotation)
    {
        return Quaternion.LerpUnclamped(owner.Rotation, desiredRotation, owner.Data.RotationSpeed / 30 * Time.deltaTime);
    }
    private bool IsFacingPlayer(Quaternion desiredRotation) => Quaternion.Angle(owner.Rotation, desiredRotation) < owner.Data.RotationThreshold;
}
