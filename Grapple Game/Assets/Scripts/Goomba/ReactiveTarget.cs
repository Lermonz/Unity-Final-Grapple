using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] float _deathAnimTime;
    EnemyStateMachine _stateMachine;
    bool _isDead;

    void Start() {
        _stateMachine = GetComponent<EnemyStateMachine>();
    }

    // Used for interpolating rotation
    private Quaternion _initRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion _endRotation;

    // This code will be triggered once the entity has been shot.
    public void ReactToHit(float damage)
    {
        if(_stateMachine != null) {
            if(!_isDead) {
                _stateMachine.EnemyHealth -= damage;
                _stateMachine.GotHit();
                //StartCoroutine(Die());
            }
        }
        else {
            GameBehaviour.Instance.KillEnemy();
            Destroy(gameObject);
        }
    }
    public void Die() {
        var _body = GetComponent<Rigidbody>();
        _body.velocity = Vector3.up*4f;
        _endRotation = Quaternion.Euler(Random.Range(-50,-75), Random.Range(-30,-60), Random.Range(-10,-20));
        StartCoroutine(DieCoro());
    }

    IEnumerator DieCoro()
    {
        float elapsedTime = 0.0f;
        _isDead = true;
        
        while (elapsedTime < _deathAnimTime)
        {
            transform.rotation = Quaternion.Lerp(
                _initRotation, _endRotation, elapsedTime*5f / _deathAnimTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
