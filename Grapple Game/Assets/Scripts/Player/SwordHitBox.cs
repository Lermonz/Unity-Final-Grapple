using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    RaycastHit _hit;
    float _swordDmg = 1;
    public void MakeHitBox()
    {
        LayerMask mask = 3;
        if(Physics.BoxCast(transform.position, 
        new Vector3(1,1.5f,0.5f), transform.forward, out _hit, transform.rotation, 2f, mask)) {
            
            GameObject hitObj = _hit.transform.gameObject;
            Debug.Log("Hit something!!!"+hitObj);
            ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();
            if (target != null) {
                target.ReactToHit(_swordDmg);
            }
        }
    }
}
