using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine player) {
        Debug.Log("Grapple State - Enter");
    }
    public override void UpdateState(PlayerStateMachine player) {
        player.RayShooter.Clicker();
        Debug.Log("Grapple State - Update");
    }
    public override void ExitState(PlayerStateMachine player){
    }
}
