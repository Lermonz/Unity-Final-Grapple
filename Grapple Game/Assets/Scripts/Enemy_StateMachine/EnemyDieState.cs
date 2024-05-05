using UnityEngine;

public class EnemyDieState  : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy) {
        enemy.ReactiveTarget.Die();
    }
    public override void UpdateState(EnemyStateMachine enemy) {

    }
    public override void ExitState(EnemyStateMachine enemy) {

    }
}
