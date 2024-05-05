using UnityEngine;

public class EnemyHurtState  : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy) {
        enemy.FlashHurt.Flash();
    }
    public override void UpdateState(EnemyStateMachine enemy) {

    }
    public override void ExitState(EnemyStateMachine enemy) {

    }
}
