using System.Collections;
using UnityEngine;

public class DealsDamage : MonoBehaviour
{
    GameObject player;
    EnemyStateMachine _stateMachine;
    [SerializeField] int _damage;
    public void SetUp()
    {
        _stateMachine = GetComponent<EnemyStateMachine>();
        player = GameObject.Find("Player");
        Vector3 playerPos = new Vector3(player.transform.position.x, 
                                        transform.position.y, 
                                        player.transform.position.z);//limit rotation to just the y axis
        transform.LookAt(playerPos);
        transform.Rotate(0,180,0);
        player.GetComponent<PlayerCharacter>().Hurt(_damage);
        StartCoroutine(ReturnToWander());
    }

    // Update is called once per frame
    public void Buffer()
    {
        transform.Translate(0, 0, 1.5f * Time.deltaTime);
    }
    IEnumerator ReturnToWander() {
        yield return new WaitForSeconds(0.1f);
        _stateMachine.Wandering();
    }
}
