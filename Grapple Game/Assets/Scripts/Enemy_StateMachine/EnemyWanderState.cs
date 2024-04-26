using UnityEngine;

public class EnemyWanderState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy) {
        enemy.WanderingAI.SetUp();
    }
    public override void UpdateState(EnemyStateMachine enemy) {
        enemy.WanderingAI.Wander();
    }
    public override void ExitState(EnemyStateMachine enemy) {

    }
}
