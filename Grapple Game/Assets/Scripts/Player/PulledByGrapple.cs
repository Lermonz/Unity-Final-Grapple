using UnityEditor;
using UnityEngine;

public class PulledByGrapple : MonoBehaviour
{
    GameObject _grapplePart;
    [SerializeField] float _speed;
    Vector3 _originalView;
    public void SetUp()
    {
        _originalView = transform.localEulerAngles;
        _grapplePart = GameObject.Find("GrappleEnd(Clone)");
    }
    public Vector3 GetMovedByGrapple()
    {
        Vector3 movement = Vector3.forward*15;
        movement = transform.TransformDirection(movement);
        transform.LookAt(_grapplePart.GetComponent<Transform>());
        Debug.Log(transform.localEulerAngles);
        return movement;
    }
    public void ResetCamera() {
        transform.localEulerAngles = _originalView;
    }
}
