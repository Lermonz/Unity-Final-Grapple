using UnityEngine;

public class BillBoard : MonoBehaviour
{
    GameObject _player;
    void Start()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.LookAt(_player.transform.position);
        transform.Rotate(0,90,0);
    }
}
