using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//アニメパラメーター
/*
 * speed float  //速度によって歩くか歩かないか
 * attack bool  //攻撃
 * damege bool  //ダメージ
 * death bool   //死亡
 */

public class Nav_Enemy_Scarecrow : MonoBehaviour
{
    NavMeshAgent Enemy_Nav;     //このオブジェクトについてるナビメッシュ
    [SerializeField] GameObject Destination;    //目的地
    private Animator Anim;      //アニメーション格納
    private bool Over_Flg;      //ゲームオーバーフラグ


    void Start()
    {
        //プレイヤーのNavMeshAgentを取得
        Enemy_Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        //Destination = GameObject.Find("Goal");
        Anim = GetComponent<Animator>();
        //目的地を設定
        Enemy_Nav.SetDestination(Destination.transform.position);
        Over_Flg = false;
    }

    void Update()
    {
        if (Over_Flg == false)
        {
            //目的地を設定
            Enemy_Nav.SetDestination(Destination.transform.position);
            Anim.SetFloat("speed", Enemy_Nav.speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Over_Flg == false && collision.gameObject.tag == "Player") 
        {
            Enemy_Nav.SetDestination(gameObject.transform.position);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Anim.SetBool("attack", true);
            Over_Flg = true;
        }
    }
}
