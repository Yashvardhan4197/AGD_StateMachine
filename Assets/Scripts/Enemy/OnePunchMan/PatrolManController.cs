
using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManController : EnemyController
    {
        private IStateMachine stateMachine;
        public PatrolManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            stateMachine = new PatrolManStateMachine(this);
            stateMachine.ChangeState(States.IDLE);
        }

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;
            stateMachine.Update();
        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            Debug.Log("hello");
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(States.CHASING);
        }

        public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);


    }
}
