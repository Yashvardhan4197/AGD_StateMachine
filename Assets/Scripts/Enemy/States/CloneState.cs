using StatePattern.Main;
using StatePattern.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

namespace StatePattern.Enemy
{
    public class CloneState<T> : IState where T : CloneManController
    {
        public EnemyController Owner {  get; set; }
        private CloneManStateMachine stateMachine;
        public CloneState(CloneManStateMachine cloneManStateMachine)
        {
            stateMachine = cloneManStateMachine;
        }

        public void OnStateEnter()
        {
            CreateNewEnemy();
            stateMachine.ChangeState(States.CHASING);
        }

        private void CreateNewEnemy()
        {
            Owner.CloneNumber--;
            if (Owner.CloneNumber >= 0)
            {
                EnemyController newenemy1 = new CloneManController(Owner.enemyScriptableObject);
                EnemyController newenemy2 = new CloneManController(Owner.enemyScriptableObject);
                InitializeNewEnemiesData(newenemy1, newenemy2);
                TeleportEnemies(newenemy1, newenemy2);

            }
        }

        private void InitializeNewEnemiesData(EnemyController newenemy1,EnemyController newenemy2)
        {
            
            newenemy1.ChangeEnemyColor(Color.magenta);
            newenemy2.ChangeEnemyColor(Color.magenta);
            newenemy1.CloneNumber = Owner.CloneNumber;
            newenemy2.CloneNumber = Owner.CloneNumber;
            GameService.Instance.EnemyService.AddtoEnemyList(newenemy1);
            GameService.Instance.EnemyService.AddtoEnemyList(newenemy2);
        }

        private void TeleportEnemies(EnemyController newenemy1, EnemyController newenemy2)
        {
            newenemy1.Agent.Warp(NewLocation());
            newenemy2.Agent.Warp(NewLocation());
        }

        private Vector3 NewLocation()
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * Owner.Data.TeleportingRadius + Owner.Position;

            NavMeshHit Hit;
            if (NavMesh.SamplePosition(randomDirection, out Hit, Owner.Data.TeleportingRadius, NavMesh.AllAreas))
                return Hit.position;
            return Owner.Data.SpawnRotation;
        }


        public void OnStateExit()
        {
        }

        public void Update()
        {
        }
    }
}
