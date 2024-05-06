using System.Collections;
using UnityEngine;

public class GlobalSoftlockFix : MonoBehaviour
{
    PlayerStateMachine thePlayer;
    void Start()
    {
        thePlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        StartCoroutine(Unload());
    }
    IEnumerator Unload() {
        yield return new WaitForSeconds(4);
        thePlayer.IsGrappling(false);
        Destroy(this.gameObject);
    }
}
