using System.Collections;
using UnityEngine;

public class FlashHurt : MonoBehaviour
{
    Material _defaultColor;
    [SerializeField] Material _flashingColor;
    MeshRenderer _meshRenderer;
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material;
    }
    public void Flash()
    {
        StartCoroutine(FlashCoro());
    }
    IEnumerator FlashCoro() {
        _meshRenderer.material = _flashingColor;
        yield return new WaitForSeconds(0.5f);
        _meshRenderer.material = _defaultColor;
    }
}
