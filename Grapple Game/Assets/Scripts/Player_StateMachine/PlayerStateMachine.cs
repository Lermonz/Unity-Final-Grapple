using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState _currentState;

    public PlayerGrappleState GrappleState = new();
    public PlayerNotGrappleState NotGrappleState = new();
    public PlayerGrapplePull GrapplePullState = new();
    public PlayerSwordState SwordState = new();

    public FPSInput FPSInput;
    public PulledByGrapple Puller;
    public MouseLook MouseLook;
    public RayShooter RayShooter;
    public ControlSword ControlSword;
    public SwordHitBox SwordHitBox;

    bool _isCharged;
    public bool IsCharged { get => _isCharged; set { _isCharged = value;  } }
    void Awake()
    {
        FPSInput = GetComponent<FPSInput>();
        Puller = GetComponent<PulledByGrapple>();
        MouseLook = GetComponent<MouseLook>();
        RayShooter = GetComponent<RayShooter>();
        ControlSword = GetComponent<ControlSword>();
        SwordHitBox = GetComponent<SwordHitBox>();
    }
    void Start() {
        SetState(NotGrappleState);
    }
    void Update()
    {
        _currentState.UpdateState(this);
    }
    public void SetState(PlayerBaseState newState) {
        if(_currentState != null) {
            _currentState.ExitState(this);
        }
        _currentState = newState;
        _currentState.EnterState(this);
    }
    public void IsGrappling(bool AreYou) {
        if(AreYou) {
            SetState(GrappleState);
        }
        else {
            SetState(NotGrappleState);
        }
    }
    public void IsPulledByGrapple() {
        SetState(GrapplePullState);
    }
    public void SwingWeapon() {
        SetState(SwordState);
    }
    public void SwordHitboxMethod() {
        SwordHitBox.MakeHitBox();
    }
}
