using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] private float _changeRate = 0.5f;
    [SerializeField] private float R = 0.2f;
    [SerializeField] private float G = 0.2f;
    [SerializeField] private float B = 0.2f;
    [SerializeField] private float A = 1;

    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        StartCoroutine(BlinkerCoroutine());
    }

    IEnumerator BlinkerCoroutine()
    {
        //こちらは動く例
        //変更前のマテリアルのコピーを保存
        var originalMaterial = new Material(_renderer.material);
        for (; ; )
        {
            _renderer.material.EnableKeyword("_EMISSION"); //キーワードの有効化を忘れずに
            _renderer.material.SetColor("_EmissionColor", new Color(R, G, B, A)); //色を変える
            yield return new WaitForSeconds(_changeRate); //1秒待って
            _renderer.material = originalMaterial; //元に戻す
            yield return new WaitForSeconds(_changeRate); //また1秒待ってくりかえし
        }
    }
}
