using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleShooter : MonoBehaviour
{
    [SerializeField] float Speed;
    float _speed;
    IEnumerator coroutine;
    int _direction = 1;
    bool _followPlayer;
    GameObject _player;
    PlayerStateMachine thePlayer;
    bool _ignoreCol;
    void Start() {
        _player = GameObject.Find("Player");
        thePlayer = _player.GetComponent<PlayerStateMachine>();
        coroutine = Range();
        StartCoroutine(Range());
        _ignoreCol = true;
        StartCoroutine(IgnoreCol());
        _speed = Speed;
    }
    void Update()
    {
        if(!_followPlayer) {
            transform.Translate(0, 0, _speed * _direction * Time.deltaTime);
        }
        else {
            transform.LookAt(_player.transform.position);
            transform.Translate(0, 0, _speed * _direction * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider col) {
        if(!_ignoreCol) {
            if(col.CompareTag("Player")) {
                thePlayer.IsGrappling(false);
                Destroy(gameObject);
            }
            else if(col.CompareTag("Enemy")) {
                Debug.Log("Grapple Touched Enemy");
                _followPlayer = true;
                _speed*=0.8f;
                EnemyStateMachine enemy = col.GetComponent<EnemyStateMachine>();
                enemy.GotGrappled();
                StopAllCoroutines();
            }
            else if(col.CompareTag("NotGrabble")) {
                _followPlayer = true;
                _speed*=0.8f;
                StopAllCoroutines();
            }
            else if(col.CompareTag("Pickup")) {
            }
            else {
                _direction = 0;
                thePlayer.IsPulledByGrapple();
                StopAllCoroutines(); //prevents the grapple from returning to the player
                StartCoroutine(Stuck());
            }
        }
    }
    IEnumerator Range() {
        yield return new WaitForSeconds(0.3f);
        _followPlayer = true;
    }
    IEnumerator IgnoreCol() {
        yield return new WaitForSeconds(0.02f);
        _ignoreCol = false;
    }
    IEnumerator Stuck() {
        yield return new WaitForSeconds(1.2f);
        transform.position = _player.transform.position;
    }
}
