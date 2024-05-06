using System.Collections;
using UnityEngine;

public class ShowControlsMenu : MonoBehaviour
{    
    GameObject _canvas;
    float _endTime = 0.15f;
    [SerializeField] float _moveBy;
    Vector3 _startPos;
    Vector3 _endPos;
    void Start() {
        _canvas = GameObject.Find("ChangeMenu");
    }
    public void MoveMenu() {
        StartCoroutine(ActualMoveMenu());
        Debug.Log("Screen Height: "+Screen.height);
    }
    IEnumerator ActualMoveMenu() {
        _startPos = _canvas.transform.position;
        _endPos = _startPos + Vector3.up*(Screen.height*(_moveBy/348));
        float elapsedTime = 0;
        while(elapsedTime < _endTime) {
            _canvas.transform.position = Vector3.Lerp(_startPos,_endPos,elapsedTime/_endTime);
            elapsedTime+=Time.deltaTime;
            yield return null;
        }
    }
}
