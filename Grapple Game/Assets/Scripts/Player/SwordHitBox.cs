using UnityEditor;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    RaycastHit _hit;
    bool _detect;
    float _swordDmg = 1;
    public void MakeHitBox()
    {
        LayerMask mask = 3;
        _detect = Physics.BoxCast(transform.position-transform.forward, 
        new Vector3(1.2f,0.7f,1f), transform.forward, out _hit, transform.rotation, 2.5f, mask);
        if(_detect) {
            GameObject hitObj = _hit.transform.gameObject;
            //Debug.Log("Hit something!!!"+hitObj);
            ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();
            if (target != null) {
                target.ReactToHit(_swordDmg);
            }
        }
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if(_detect) {
            Gizmos.DrawRay(transform.position-transform.forward, transform.forward * _hit.distance);
            Gizmos.DrawWireCube(transform.position-transform.forward + transform.forward*_hit.distance, new Vector3(1.2f,0.7f,1f)*2);
        }
        else {
            Gizmos.DrawRay(transform.position-transform.forward, transform.forward * 2);
            Gizmos.DrawWireCube(transform.position-transform.forward + transform.forward*2, new Vector3(1.2f,0.7f,1f)*2);
        }
    }
}
