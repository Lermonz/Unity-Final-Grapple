using System.Collections;
using UnityEngine;

public class SwordSwinger : MonoBehaviour
{
    float _swingAnimTime = 0.1f;
    Vector3 _origPos;
    Vector3 _origRot;
    Vector3 _newPos;
    Vector3 _newRot;
    PlayerStateMachine _player;
    AudioSource _audio;
    void Start() {
        _player = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        _audio = GetComponent<AudioSource>();
    }
    public void ReleaseClick(bool charge)
    {
        _player.IsCharged = charge; //check for if the player held click long enough for lightning
        _origPos  = transform.localPosition; 
        _origRot = transform.localEulerAngles;
        _newPos = new Vector3(-0.71f,0.12f,1);
        _newRot = new Vector3(_origRot.x,_origRot.y,41);
        StartCoroutine(RealSwing());
        _audio.PlayOneShot(_audio.clip);
    }
    IEnumerator RealSwing() {
        float elapsedTime = 0f;
        _player.IsGrappling(false);
        while (elapsedTime < _swingAnimTime) {
            // Vector3 MovePos = Vector3.Lerp(_origPos, _newPos, elapsedTime/_swingAnimTime);
            // MovePos = transform.InverseTransformDirection(MovePos);
            transform.localPosition = Vector3.Slerp(_origPos, _newPos, elapsedTime/_swingAnimTime);
            transform.localEulerAngles = Vector3.Slerp(_origRot, _newRot, elapsedTime/_swingAnimTime);
            elapsedTime+=Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        transform.localPosition = new Vector3(0.8f,0.12f,1);
        transform.localEulerAngles = new Vector3(38.1f,0f,-26);
    }
}
