using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    [SerializeField] private GameObject _enemy;  //エネミーを参照
    [SerializeField] private Vector3 _spawnPo;    //エネミーのスポーン位置
    [SerializeField] private GlitchEffect _p_CameraGl;  //カメラエフェクト
    private Animator Anim;      //アニメーション格納

    private bool isEvent;

    // Start is called before the first frame update
    void Start()
    {
        isEvent = false;
        Anim = _enemy.gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        isEvent = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isEvent)
        {
            isEvent = true;
            StartCoroutine("Event");
        }
    }

    IEnumerator Event()
    {
        _enemy.SetActive(false);
        _p_CameraGl.enabled = true;
        yield return new WaitForSeconds(0.5f); //待つ
        _enemy.transform.position = _spawnPo;
        _enemy.SetActive(true);
        yield return new WaitForSeconds(0.2f); //待つ
        _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(0);
        Anim.SetFloat("speed", 1);
        _p_CameraGl.enabled = false;
        yield return new WaitForSeconds(0.2f); //待つ
        gameObject.SetActive(false);
        yield break;
    }


}
