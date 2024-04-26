using System.Collections;
using UnityEngine;

public class AttackAI : MonoBehaviour
{
    float _speed = 2.5f;
    Rigidbody _body;
    EnemyStateMachine _stateMachine;
    void Awake() {
        _body = GetComponent<Rigidbody>();
        _stateMachine = GetComponent<EnemyStateMachine>();
    }
    public void NoticePlayer()
    {
        _body.velocity = new Vector3(0,4.5f,0);
        StartCoroutine(ReturnToWander());
    }
    public void AttackAction()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }
    
    IEnumerator ReturnToWander() {
        yield return new WaitForSeconds(1.2f);
        _stateMachine.Wandering();
    }
}
