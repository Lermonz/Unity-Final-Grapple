using UnityEngine;

public class EnemyGotGrappled : MonoBehaviour
{
    GameObject _grappleRef;
    EnemyStateMachine _stateMachine;
    void Start() {
        _stateMachine = GetComponent<EnemyStateMachine>();
    }
    public void SetUp() {
        _grappleRef = GameObject.Find("GrappleEnd(Clone)");
    }
    public void Pulled() {
        if(_grappleRef != null) {
            Vector3 GrapPos = _grappleRef.transform.position;
            transform.LookAt(GrapPos);
            transform.position = new Vector3(GrapPos.x, GrapPos.y, GrapPos.z);
            transform.Translate(0,0,-2);
        }
        else {
            _stateMachine.Wandering();
        }
    }
}
