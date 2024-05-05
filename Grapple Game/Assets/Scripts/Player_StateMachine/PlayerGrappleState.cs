using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine player) {
        player.FPSInput._moveSpeed = 4.5f;
        //Debug.Log("Grapple State - Enter");
    }
    public override void UpdateState(PlayerStateMachine player) {
        player.FPSInput.Movement();
        //player.RayShooter.Clicker();
        //Debug.Log("Grapple State - Update");
    }
    public override void ExitState(PlayerStateMachine player){
        player.FPSInput._moveSpeed = 6.0f;
    }
}
