using UnityEngine;
using StatePattern.Enemy.Bullet;
using StatePattern.Main;
using StatePattern.Player;

namespace StatePattern.Enemy
{
    public class OnePunchManController : EnemyController
    {
        public PlayerController target;
        private OnePunchManStateMachine onePunchManStateMachine;

        public OnePunchManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            onePunchManStateMachine = new OnePunchManStateMachine(this);
            onePunchManStateMachine.ChangeState(OnePunchManStates.Idle);
        }


        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            onePunchManStateMachine.Update();

        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            target = targetToSet;
            onePunchManStateMachine.ChangeState(OnePunchManStates.Shooting);
            
        }

        public override void PlayerExitedRange() 
        {
            onePunchManStateMachine.ChangeState(OnePunchManStates.Idle);
        }
    }
}