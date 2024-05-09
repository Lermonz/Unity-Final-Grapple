using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    GameObject _canvas;
    void Start() {
        _canvas = GameObject.Find("ChangeMenu");
    }
    public void MoveMenu() {
        _canvas.transform.localPosition = Vector3.zero;
    }
}
