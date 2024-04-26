using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] float _speed = 1.5f;
    [SerializeField] float _obstacleRange = 5.0f;

    private readonly float _sphereRadius = 4.0f;
    private bool _isAlive;

    float _travelTime = 2;
    float _stopTime = 1;
    bool _canMove;

    Vector3 _home;
    float _maxDistFromHome = 7.0f;

    EnemyStateMachine _stateMachine;

    // [SerializeField] GameObject _fireballPrefab;
    // public GameObject _fireball;

    private void Start()
    {
        SetAlive(true);
        _home = transform.position;
        _stateMachine = GetComponent<EnemyStateMachine>();
    }

    public void SetUp() {
        _canMove = true;
        StartCoroutine(Wait());
    }

    public void Wander()
    {
        if(_canMove) {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
        Ray ray = new(transform.position, transform.forward);
        float dist = Vector3.Distance(transform.position, _home);
        if (dist >= _maxDistFromHome) {
            Vector3 _homeY = new Vector3(_home.x, 
                                        transform.position.y, 
                                        _home.z);//limit rotation to just the y axis
            transform.LookAt(_homeY);
            StopAllCoroutines();
            StartCoroutine(Move());
        }
        //Debug.Log(transform.position.z - _home.z+"\n"+_home);
        // Cast a sphere in the direction of the ray and see if it collides
        // with the player or with the walls.
        if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit))
        {
            GameObject hitObj = hit.transform.gameObject;

            // Shoot a fireball if the ray collided with the player.
            if (hitObj.GetComponent<CharacterController>() && hit.distance < _obstacleRange)
            {
                StopAllCoroutines();
                Vector3 playerPos = new Vector3(hitObj.transform.position.x, 
                                                transform.position.y, 
                                                hitObj.transform.position.z);//limit rotation to just the y axis
                transform.LookAt(playerPos);
                _stateMachine.AttackPlayer();
                // if (_fireball == null)
                // {
                //     _fireball = Instantiate(
                //         _fireballPrefab,
                //         // TransformPoint from local space to global space.
                //         // The fireball will be placed in front of the
                //         // entity and facing in the same direction.
                //         transform.TransformPoint(Vector3.forward * 1.5f),
                //         transform.rotation);
                // }
            }
        }
    }
// this guy will "lunge" at you, and be knocked back when hit
    public void SetAlive(bool alive)
    {
        _isAlive = alive;
    }
    IEnumerator Move(float theta) {
        Debug.Log("Move (theta)");
        transform.Rotate(0,theta,0);
        yield return new WaitForSeconds(_travelTime);
        StartCoroutine(Wait());
    }
    IEnumerator Move() {
        Debug.Log("Move");
        while (Mathf.Abs(transform.position.z - _home.z) > 1f) {
            yield return null;
        }
        yield return null;
        StartCoroutine(Wait());
    }
    IEnumerator Wait() {
        Debug.Log("Wait");
        _canMove = false;
        yield return new WaitForSeconds(_stopTime);
        _canMove = true;
        StartCoroutine(Move(Random.Range(120,240)));
    }
}
