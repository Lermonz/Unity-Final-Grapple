using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    int _kills = 0;
    public int Kills {
        get => _kills;
        set {
            _kills = value;
            TextBox.text = Kills.ToString()+"/"+GameBehaviour.Instance._enemyReq[GameBehaviour.Instance._onLevel-1].ToString()+" Enemies Killed";
        }
    }
    public TextMeshProUGUI TextBox;
    void Start() {
        Kills = 0;
    }
}