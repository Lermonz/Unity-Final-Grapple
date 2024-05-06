using UnityEngine;
using TMPro;

public class ManaBar : MonoBehaviour
{
    int _mana = 5;
    public TextMeshProUGUI TextBox;
    void Start() {
        TextBox = GameObject.Find("Mana Display").GetComponent<TextMeshProUGUI>();
        TextBox.text = _mana.ToString()+" LP";
    }
    public int Mana {
        get => _mana;
        set {
            _mana = value;
            TextBox.text = Mana.ToString()+" LP";
        }
    }
    public void ChangeMana(int mana) {
        _mana+=mana;
        TextBox.text = _mana.ToString()+" LP";
    }
}