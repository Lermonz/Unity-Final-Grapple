using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;
    GameObject _camObject;
    [SerializeField] GameObject _grappleEndPrefab;
    public GameObject _grappler;
    [SerializeField] GameObject _lightningPrefab;
    public GameObject _lightning;
    float _lightningDmg = 5;
    int _manaCost = 2;
    PlayerStateMachine _stateMachine;
    ManaBar _manaBar;

    private void Start()
    {
        _camObject = GameObject.Find("Main Camera");
        _cam = _camObject.GetComponent<Camera>();
        _stateMachine = GetComponent<PlayerStateMachine>();
        _manaBar = GetComponent<ManaBar>();

        // Lock cursor to the middle of the screen and hide it.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Clicker()
    {
        if (Input.GetAxis("Fire1") != 0) {
            _stateMachine.SwingWeapon();
        }
        if (Input.GetAxis("Fire2") != 0) {
            if(_grappler == null) {
                _stateMachine.IsGrappling(true);
                //create a GrappleEndPrefab at a position relative to the player, and rotation relative to the camera
                _grappler = Instantiate(_grappleEndPrefab, transform.TransformPoint(Vector3.forward * 1.5f), _camObject.transform.rotation);
            }
        }
    }
    public void ShootLightning() {
        if(_manaBar.Mana < _manaCost) {
            return;
        }
        GameBehaviour.Instance.ChangeMana(-_manaCost);
        // Create a ray that goes forward from player
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.Log("start: "+transform.position+"\ndir: "+transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.red, 5f);
        // Data structure to record information about the ray collision
        RaycastHit hit;
        // Check if the created ray collided with any geometry
        if (Physics.SphereCast(ray, 2.0f, out hit))
        {
            // Retrieve GameObject ray collided with.
            GameObject hitObj = hit.transform.gameObject;
            ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();
            Debug.Log("hitObj: "+hitObj);
            float lightningSize;
            //if it hits nothing, lightning still has a size
            if(hitObj != null) {
                lightningSize = hit.distance;
            }
            else {
                lightningSize = 500;
            }
            _lightning = Instantiate(
                _lightningPrefab, 
                transform.TransformPoint(Vector3.forward * lightningSize*0.5f), 
                _camObject.transform.rotation
            );
            //change length of lightning to be the distance it takes to hit something
            _lightning.transform.localScale = new Vector3(0.5f, lightningSize, 0.5f);
            //rotate the prefab 90 degrees along x
            _lightning.transform.localEulerAngles = new Vector3(90, _lightning.transform.localEulerAngles.y, _lightning.transform.localEulerAngles.z);
            StartCoroutine(LightningIsTemp());
            if (target != null)
                target.ReactToHit(_lightningDmg);
        }
    }
    void OnGUI()
    {
        // Size of the rectangular GUI that will contain the text.
        int size = 12;

        // Position of the text. Note that subtracting the scaled size will
        // ensure that the star is centered.
        float posX = _cam.pixelWidth / 2 - size / 4;
        float posY = _cam.pixelHeight / 2 - size / 2;

        // Change the color of the GUI's contents to red.
        GUI.contentColor = Color.red;

        // Render a label that defines a position and the text it contains.
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    IEnumerator LightningIsTemp()
    {
        yield return new WaitForSeconds(1f);
        Destroy(_lightning);
    }
}
