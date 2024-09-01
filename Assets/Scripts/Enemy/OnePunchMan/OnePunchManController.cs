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
            InitializeVariables();
            onePunchManStateMachine = new OnePunchManStateMachine(this);
        }

        private void InitializeVariables()
        {
            
        }

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            onePunchManStateMachine.ChangeState(OnePunchManStates.Shooting);
            target = targetToSet;
        }

        public override void PlayerExitedRange() 
        {
            onePunchManStateMachine.ChangeState(OnePunchManStates.Idle);
        }
    }
}