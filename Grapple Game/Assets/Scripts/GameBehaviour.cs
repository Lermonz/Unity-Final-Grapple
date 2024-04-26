using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour Instance;
    public GameState State = GameState.Play;
    public int _onLevel;
    public int[] _enemyReq = new int[5];
    [SerializeField] KillCount _totalKills;
    [SerializeField] ManaBar _currentMana;
    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    public enum GameState {
        Play, Pause
    }
    public void KillEnemy() {
        _totalKills.Kills++; //when an enemy dies (goes into die state) trigger this
    }
    public void ChangeMana(int change) {
        _currentMana.Mana += change;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("pause");
            if(State == GameState.Play) {
                Time.timeScale = 0f;
                State = GameState.Pause;
            }
            else {
                Time.timeScale = 1f;
                State = GameState.Play;
            }
        }
    }
}
