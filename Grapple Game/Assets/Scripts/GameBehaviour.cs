using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour Instance;
    public GameState State = GameState.Play;
    public int _onLevel;
    public int[] _enemyReq = new int[5];
    public string[] _levelScene = new string[5];
    [SerializeField] KillCount _totalKills;
    [SerializeField] ManaBar _currentMana;
    [SerializeField] GameObject _levelClearText;
    bool _levelClear;
    public bool LevelClear { get => _levelClear; set { _levelClear = value;  } }
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
        //Debug stuff to get through levels quickly in testing
        if(Input.GetKeyDown(KeyCode.L)) {
            _totalKills.Kills = _enemyReq[_onLevel-1];
        }
        if(_totalKills.Kills == _enemyReq[_onLevel-1] && !_levelClear) {
            _levelClear = true;
            StartCoroutine(LoadNextLevel());
        }
    }
    IEnumerator LoadNextLevel() {
        _levelClearText.transform.localPosition = new Vector3(0,70,0);
        yield return new WaitForSeconds(1f);
        _levelClearText.transform.localPosition = new Vector3(0,700,0);
        _totalKills.Kills = 0;
        _levelClear = false;
        _onLevel++;
        SceneManager.LoadScene(_levelScene[_onLevel-1]);
    }
}
