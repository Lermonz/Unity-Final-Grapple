using UnityEngine;

public class EnemyGrappledState  : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy) {
        enemy.EnemyGotGrappled.SetUp();
        Debug.Log("Enemy Grappled STATE");
    }
    public override void UpdateState(EnemyStateMachine enemy) {
        enemy.EnemyGotGrappled.Pulled();
    }
    public override void ExitState(EnemyStateMachine enemy) {

    }
}
