using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] float _deathAnimTime = 1.5f;
    EnemyStateMachine _stateMachine;

    void Start() {
        _stateMachine = GetComponent<EnemyStateMachine>();
    }

    // Used for interpolating rotation
    private Quaternion _initRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion _endRotation = Quaternion.Euler(-75, 0, 0);

    // This code will be triggered once the entity has been shot.
    public void ReactToHit(float damage)
    {
        _stateMachine.EnemyHealth -= damage;
        _stateMachine.GotHit();
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
            behavior.SetAlive(false);
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < _deathAnimTime)
        {
            transform.rotation = Quaternion.Lerp(
                _initRotation, _endRotation, elapsedTime / _deathAnimTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
