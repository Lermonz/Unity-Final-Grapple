using UnityEngine;

public class BillBoard : MonoBehaviour
{
    GameObject _player;
    [SerializeField] Vector3 FixBy;
    void Start()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.LookAt(_player.transform.position);
        transform.Rotate(FixBy);
    }
}
