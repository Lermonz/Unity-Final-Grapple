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
    [SerializeField] GameObject _dieText;
    [SerializeField] GameObject _winText;
    [SerializeField] GameObject _pauseText;
    bool _levelClear;
    public bool LevelClear { get => _levelClear; set { _levelClear = value;  } }
    int _playerHealth = 5;
    public int PlayerHealth { get => _playerHealth; set { _playerHealth = value;  } }
    int _playerMana = 5;
    public int PlayerMana { get => _playerMana; set { _playerMana = value;  } }
    public bool StopTimer;
    bool _returnToTitle;
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
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StopTimer = false;
        _returnToTitle = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            //Debug.Log("pause");
            if(State == GameState.Play) {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _pauseText.transform.localPosition = new Vector3(0,0,0);
                State = GameState.Pause;
            }
            else {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _pauseText.transform.localPosition = new Vector3(0,700,0);
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
        if(_playerHealth <= 0) {
            StartCoroutine(PlayerLost());
        }
        if(_returnToTitle) {
            if(Input.anyKeyDown) {
                _winText.transform.localPosition = new Vector3(0,700,0);
                StartCoroutine(LoadTitle());
            }
        }
    }
    IEnumerator LoadNextLevel() {
        if(_levelClearText != null) {
            _levelClearText.transform.localPosition = new Vector3(0,70,0);
        }
        yield return new WaitForSeconds(1f);
        _levelClearText.transform.localPosition = new Vector3(0,700,0);
        yield return null;
        _levelClear = false;
        _onLevel++;
        if(_levelScene[_onLevel-1] != "stop") {
            _totalKills.Kills = 0;
            SceneManager.LoadScene(_levelScene[_onLevel-1]);
        }
        else {
            yield return null;
            StopTimer = true;
            _winText.transform.localPosition = new Vector3(0,0,0);
            yield return new WaitForSeconds(3f);
            _returnToTitle = true;
            
        }
    }
    IEnumerator PlayerLost() {
        if(_dieText != null) {
            _dieText.transform.localPosition = new Vector3(0,70,0);
            yield return new WaitForSeconds(1f);
            _dieText.transform.localPosition = new Vector3(0,700,0);
        }
        yield return null;
        StartCoroutine(LoadTitle());
    }
    IEnumerator LoadTitle() {
        _totalKills.Kills = 0;
        var Canvas = GameObject.Find("Canvas");
        if (Canvas.GetComponent<DontDestroy>() != null) {
            Destroy(Canvas);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        yield return null;
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }
}
