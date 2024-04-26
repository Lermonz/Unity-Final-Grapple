using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    [SerializeField] int _manaGain;
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<CharacterController>()) {
            GameBehaviour.Instance.ChangeMana(_manaGain);
            Destroy(this.gameObject);
        }
    }
    void Update() {
        transform.Rotate(0, 0.5f, 0);
    }
}
