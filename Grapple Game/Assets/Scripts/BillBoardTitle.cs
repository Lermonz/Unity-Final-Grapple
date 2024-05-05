using UnityEngine;

public class BillBoardTitle : MonoBehaviour
{
    GameObject _camera;
    void Start()
    {
        _camera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        transform.LookAt(_camera.transform.position);
        transform.Rotate(90,0,0);
    }
}

