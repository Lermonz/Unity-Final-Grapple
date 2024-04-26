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
    void Awake()
    {
        ReactiveTarget = GetComponent<ReactiveTarget>();
        WanderingAI = GetComponent<WanderingAI>();
        AttackAI = GetComponent<AttackAI>();
        DealsDamage = GetComponent<DealsDamage>();
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
        if(_enemyHealth <= 0) {
            GameBehaviour.Instance.KillEnemy();
            SetState(DieState);
        }
        else {
            SetState(HurtState);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        PlayerCharacter player = other.gameObject.GetComponent<PlayerCharacter>();
        if (player != null) {
            SetState(DealDamageState);
        }
    }
}
