using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleShooter : MonoBehaviour
{
    [SerializeField] float _speed;
    bool _rangeCoroutine = true;
    IEnumerator coroutine;
    int _direction = 1;
    PlayerStateMachine thePlayer;
    void Start() {
        thePlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        coroutine = Range();
        StartCoroutine(Range());
    }
    void Update()
    {
        transform.Translate(0, 0, _speed * _direction * Time.deltaTime);
    }
    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            thePlayer.IsGrappling(false);
            Destroy(gameObject);
        }
        else {
            _direction = 0;
            thePlayer.IsPulledByGrapple();
            StopAllCoroutines(); //prevents the grapple from returning to the player
        }
    }
    IEnumerator Range() {
        yield return new WaitForSeconds(0.3f);
        _direction = -1;
        _rangeCoroutine = false;
    }
}
