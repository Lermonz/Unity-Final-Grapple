using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    EnemyBaseState _currentState;
    public EnemyWanderState WanderState = new();
    public EnemyAttackState AttackState = new();
    public EnemyHurtState HurtState = new();
    public EnemyDieState DieState = new();
    public EnemyGrappledState GrappledState = new();
    public EnemyDealDamageState DealDamageState = new();

    [SerializeField] float _maxHealth;
    float _enemyHealth;
    public float EnemyHealth {get => _enemyHealth; set { _enemyHealth = value;} }

    public ReactiveTarget ReactiveTarget;
    public WanderingAI WanderingAI;
    public AttackAI AttackAI;
    public DealsDamage DealsDamage;
    public EnemyGotGrappled EnemyGotGrappled;
    public FlashHurt FlashHurt;
    void Awake()
    {
        ReactiveTarget = GetComponent<ReactiveTarget>();
        WanderingAI = GetComponent<WanderingAI>();
        AttackAI = GetComponent<AttackAI>();
        DealsDamage = GetComponent<DealsDamage>();
        EnemyGotGrappled = GetComponent<EnemyGotGrappled>();
        FlashHurt = GetComponent<FlashHurt>();
    }
    void Start() {
        EnemyHealth = _maxHealth;
        SetState(WanderState);
    }
    void Update() {
        _currentState.UpdateState(this);
    }
    public void SetState(EnemyBaseState newState) {
        if(_currentState != null) {
            _currentState.ExitState(this);
        }
        _currentState = newState;
        _currentState.EnterState(this);
    }
    public void Wandering() {
        SetState(WanderState);
    }
    public void AttackPlayer() {
        SetState(AttackState);
    }
    public void GotHit() {
        Debug.Log(_enemyHealth);
        if(_enemyHealth <= 0) {
            GameBehaviour.Instance.KillEnemy();
            SetState(DieState);
        }
        else {
            SetState(HurtState);
        }
    }
    public void GotGrappled() {
        SetState(GrappledState);
    }
    private void OnCollisionEnter(Collision other)
    {
        PlayerCharacter player = other.gameObject.GetComponent<PlayerCharacter>();
        GrappleShooter grapple = other.gameObject.GetComponent<GrappleShooter>();
        Debug.Log("Touched by: "+player+grapple);
        if (player != null) {
            SetState(DealDamageState);
        }
        else if(grapple != null) {
            Debug.Log("Enemy Touched Grapple!");
            SetState(GrappledState);
        }
    }
}
