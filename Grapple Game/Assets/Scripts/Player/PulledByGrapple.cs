using UnityEditor;
using UnityEngine;

public class PulledByGrapple : MonoBehaviour
{
    GameObject _grapplePart;
    [SerializeField] float _speed;
    public void SetUp()
    {
        _grapplePart = GameObject.Find("GrappleEnd(Clone)");
    }
    public Vector3 GetMovedByGrapple()
    {
        if(_grapplePart != null) {
            Vector3 direction = _grapplePart.transform.position - transform.position;
            direction *= 5;
            return direction;
        }
        else {
            return Vector3.zero;
        }
    }
}
