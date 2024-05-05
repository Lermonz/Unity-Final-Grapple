using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] int _health = 5;
    public TextMeshProUGUI TextBox;
    bool _iframes;
    void Start() {
        TextBox = GameObject.Find("Health Display").GetComponent<TextMeshProUGUI>();
        TextBox.text = _health.ToString()+" HP";
    }

    public void Hurt(int damage)
    {
        if(!_iframes) {
            _health -= damage;
            TextBox.text = _health.ToString()+" HP";
            StartCoroutine(IFrames());
        }
    }
    IEnumerator IFrames() {
        _iframes = true;
        yield return new WaitForSeconds(0.2f);
        _iframes = false;
    }
}
