using UnityEngine;
using TMPro;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] int _health = 5;
    public TextMeshProUGUI TextBox;
    void Start() {
        TextBox = GameObject.Find("Health Display").GetComponent<TextMeshProUGUI>();
        TextBox.text = _health.ToString()+" HP";
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        TextBox.text = _health.ToString()+" HP";
        Debug.Log($"Health: {_health}");
    }
}
