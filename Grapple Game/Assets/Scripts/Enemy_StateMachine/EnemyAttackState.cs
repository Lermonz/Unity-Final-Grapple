using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy) {
        enemy.AttackAI.NoticePlayer();
    }
    public override void UpdateState(EnemyStateMachine enemy) {
        enemy.AttackAI.AttackAction();
    }
    public override void ExitState(EnemyStateMachine enemy) {

    }
}
