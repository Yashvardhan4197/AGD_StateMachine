using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStates
{

    public void SetOwner(OnePunchManController controller);

    public void OnStateEnter();
    public void OnStateExit();
    public void Update();

}
