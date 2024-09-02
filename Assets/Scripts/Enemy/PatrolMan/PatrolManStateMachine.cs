

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : GenericStateMachine<PatrolManController>
    {

        public PatrolManStateMachine(PatrolManController Owner) : base(Owner) 
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(global::States.IDLE,new IdleState<PatrolManController>(this));
            States.Add(global::States.PATROLLING, new PatrollingState<PatrolManController>(this));
            States.Add(global::States.CHASING, new ChasingState<PatrolManController>(this));
            States.Add(global::States.SHOOTING, new ShootingState<PatrolManController>(this));
        }
    }
}