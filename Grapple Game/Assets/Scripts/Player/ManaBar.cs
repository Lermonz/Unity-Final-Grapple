using UnityEngine;
using TMPro;

public class ManaBar : MonoBehaviour
{
    int _mana = 0;
    [SerializeField] int initMana;
    public int Mana {
        get => _mana;
        set {
            _mana = value;
            TextBox.text = "Mana: "+Mana.ToString();
        }
    }
    public TextMeshProUGUI TextBox;
    void Start() {
        Mana = initMana;
    }
}