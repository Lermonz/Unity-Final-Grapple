using UnityEngine;

public class PlayerSwordState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine player) {
        player.FPSInput._moveSpeed = 4.5f;
        player.ControlSword.SetUp();
        //Debug.Log("Sword State - Enter");
    }
    public override void UpdateState(PlayerStateMachine player) {
        player.FPSInput.Movement();
        player.ControlSword.Controller();
        //Debug.Log("Sword State - Update");
    }
    public override void ExitState(PlayerStateMachine player) {
        player.FPSInput._moveSpeed = 6.0f;
        if(player.IsCharged) {
            //Debug.Log("SHOOT");
            player.RayShooter.ShootLightning();
        }
        player.IsCharged = false;
        //Debug.Log("Sword State - Exit");
    }
}
