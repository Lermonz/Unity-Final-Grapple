using UnityEngine;

public class EnemyDealDamageState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy) {
        enemy.DealsDamage.SetUp();
    }
    public override void UpdateState(EnemyStateMachine enemy) {
        enemy.DealsDamage.Buffer();
    }
    public override void ExitState(EnemyStateMachine enemy) {

    }
}
