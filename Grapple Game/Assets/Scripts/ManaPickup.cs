using System.Collections;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    [SerializeField] int _manaGain;
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<CharacterController>()) {
            GameBehaviour.Instance.ChangeMana(_manaGain);
            transform.Translate(0,-100,0);
            StartCoroutine(Respawn());
        }
    }
    void Update() {
        transform.Rotate(0, 0.5f, 0);
    }
    IEnumerator Respawn() {
        yield return new WaitForSeconds(15f);
        transform.Translate(0,100,0);
    }
}
