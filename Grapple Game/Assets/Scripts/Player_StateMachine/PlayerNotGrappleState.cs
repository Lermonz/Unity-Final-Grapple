using UnityEngine;

public class PlayerNotGrappleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine player) {
        Debug.Log("NOT Grapple State - Enter");
    }
    public override void UpdateState(PlayerStateMachine player) {
        player.FPSInput.Movement();
        player.RayShooter.Clicker();
        Debug.Log("NOT Grapple State - Update");
    }
    public override void ExitState(PlayerStateMachine player){
    }
}
