
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace StatePattern.Enemy
{
    public interface IStateMachine
    {
        public void CreateStates();
        public void SetOwner();
        public void Update();
        public void ChangeState(States newState);
    }
}
