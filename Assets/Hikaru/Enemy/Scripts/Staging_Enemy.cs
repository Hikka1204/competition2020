using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Staging_Enemy : MonoBehaviour
{
    NavMeshAgent Enemy_Nav;     //このオブジェクトについてるナビメッシュ
    //[SerializeField] GameObject Destination;    //目的地
    [SerializeField] Vector3 Destination;
    private Animator Anim;      //アニメーション格納
    private bool Player_flg;      //ゲームオーバーフラグ
    [SerializeField] GlitchEffect camera;
    [SerializeField] GameObject _StaColi;
    [SerializeField] private float Timedes = 5f;    //即デストロイしないようにするための変数

    void Start()
    {
        //プレイヤーのNavMeshAgentを取得
        Enemy_Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        //Destination = GameObject.Find("Goal");
        Anim = GetComponent<Animator>();
        //目的地を設定
        Enemy_Nav.SetDestination(gameObject.transform.position);
        Player_flg = false;
    }

    void Update()
    {
        

        if (Player_flg == true) { //目的に行きついたとき
            if(Timedes > 0)
            {
                Timedes -= Time.deltaTime;
                
            }
            if (Timedes <= 0)
            {
                camera.enabled = false;
                Destroy(gameObject);
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(Player_flg == false && other.gameObject.tag == "Player")
        {
            Enemy_Nav.SetDestination(Destination);
            Player_flg = true;
            Destroy(_StaColi);
            Anim.SetFloat("speed", Enemy_Nav.speed);
            camera.enabled = true;
        }
    }
}
