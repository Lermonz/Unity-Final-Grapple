using UnityEngine;

public class PlayerGrapplePull : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine player) {
        player.Puller.SetUp();
        //Debug.Log("Pull State - Enter");
    }
    public override void UpdateState(PlayerStateMachine player) {
        player.FPSInput.ActualMovement(player.Puller.GetMovedByGrapple());
        //player.Puller.GetMovedByGrapple();
        player.RayShooter.Clicker();
        //Debug.Log("Pull State - Update");
    }
    public override void ExitState(PlayerStateMachine player){
        //Debug.Log("Camera RESET!");
    }
}