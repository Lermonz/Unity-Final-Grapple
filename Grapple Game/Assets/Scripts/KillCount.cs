using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    int _kills = 0;
    string _contextText;
    public int Kills {
        get => _kills;
        set {
            _kills = value;
            if(GameBehaviour.Instance._onLevel == 1)
                _contextText = "Targets";
            else
                _contextText = "Enemies";
            TextBox.text = Kills.ToString()+"/"+GameBehaviour.Instance._enemyReq[GameBehaviour.Instance._onLevel-1].ToString()+" "+_contextText;
        }
    }
    public TextMeshProUGUI TextBox;
    void Start() {
        Kills = 0;
    }
}