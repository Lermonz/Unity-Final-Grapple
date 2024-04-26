using UnityEngine;

public class ControlSword : MonoBehaviour
{
    GameObject _sword;
    SwordSwinger _swinger;
    float _chargeLimit = 0.8f;
    float chargeTime = 0.0f;
    bool _doneCharging;
    [SerializeField] GameObject _lightningPrefab;
    public GameObject _chargeDisplay;
    PlayerStateMachine _player;
    void Start()
    {
        _sword = GameObject.Find("Sword");
        _swinger = _sword.GetComponent<SwordSwinger>();
        _player = GetComponent<PlayerStateMachine>();
    }
    public void SetUp() {
        chargeTime = 0.0f;
        _doneCharging = false;
    }
    public void Controller()
    {
        if(Input.GetAxis("Fire1") != 0) {
            chargeTime += Time.deltaTime;
            Debug.Log("IS CHARGING");
            if (chargeTime >= _chargeLimit) {
                _doneCharging = true;
                Debug.Log("READY TO FIRE");
                if(_chargeDisplay == null) {
                    _chargeDisplay = Instantiate(_lightningPrefab, _sword.transform.position, _sword.transform.rotation);
                    _chargeDisplay.transform.SetParent(_sword.transform);
                }
            }
        }
        if(Input.GetAxis("Fire1") == 0) {
            if(_chargeDisplay != null) {
                Destroy(_chargeDisplay);
            }
            _player.SwordHitboxMethod();
            _swinger.ReleaseClick(_doneCharging);
        }
    }
}
