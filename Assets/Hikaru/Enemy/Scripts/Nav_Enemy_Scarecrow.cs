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
    [SerializeField] private Transform Player_Tr;
    [SerializeField] private float _SearchRate; //探索時間が過ぎるとまた別の目的地に行く
    [SerializeField] private Vector3[] Location_Nav;
    [SerializeField] private float _TrackingRate;   //追いかける時間
    [SerializeField] private AudioClip _NormalBGM;
    [SerializeField] private AudioClip _TrackingBGM;
    [SerializeField] private AudioClip _DeathSE;

    private AudioSource audio;
    NavMeshAgent Enemy_Nav;     //このオブジェクトについてるナビメッシュ
    private Animator Anim;      //アニメーション格納
    private bool Over_Flg;      //ゲームオーバーフラグ
    private bool Player_Get; //このスクリプトをaddcomponent時にplayerを発見した状態にするか
    private int Number;  //目的地のナンバー
    private bool Player_flg;    //playerを見つけたか見つけてないか
    private byte Move_Status;   //探索の状態
    private float SearchTime;   //_SearchRateの取得
    private float TrackingTime; //_TrackingRateの取得


    void Start()
    {
        //プレイヤーのNavMeshAgentを取得
        Enemy_Nav = GetComponent<NavMeshAgent>();
        audio = gameObject.GetComponent<AudioSource>();
        //目的地のオブジェクトを取得
        //Destination = GameObject.Find("Goal");
        Anim = GetComponent<Animator>();
        //目的地を設定
        //Enemy_Nav.SetDestination(Destination.position);
        Over_Flg = false;
        Player_flg = false;
        SearchTime = _SearchRate;
        Number = 0;
        Anim.SetFloat("speed", Enemy_Nav.speed);
        SetSearchLocation();
        audio.clip = _NormalBGM;
        audio.Play();
    }

    void Update()
    {
        if(Over_Flg == false)
        {
            if (Player_Get == false && TrackingTime > 0)
            {
                TrackingTime -= Time.deltaTime;
                SetPlayerLocation();
                if (TrackingTime <= 0)
                {
                    SetSearchLocation();
                    audio.clip = _NormalBGM;
                    audio.Play();
                }
            }
            else if(Player_Get == true)
            {
                SetPlayerLocation();
            }
            

            if (Player_Get == false && SearchTime > 0 && TrackingTime <= 0)
            {
                SearchTime -= Time.deltaTime;
                if (SearchTime <= 0)
                {
                    SetSearchLocation();
                }
            }
        }

        //if (Over_Flg == false)
        //{
        //    //目的地を設定
        //    //Enemy_Nav.SetDestination(Destination);
        //    Anim.SetFloat("speed", Enemy_Nav.speed);
        //}
    }


    private void SetPlayerLocation()
    {
        Enemy_Nav.SetDestination(Player_Tr.position);
    }

    private void SetSearchLocation()
    {
        int RandomNumber;   //ランダムな値を取得
        while (true)
        {
            RandomNumber = Random.Range(0, Location_Nav.Length);
            if (Number != RandomNumber)
            {
                Number = RandomNumber;
                Enemy_Nav.SetDestination(Location_Nav[Number]);
                SearchTime = _SearchRate;
                break;
            }
        }
        
    }

    public void GetPlayer(bool Get)
    {
        Player_Get = Get;
        switch (Player_Get)
        {
            case true:
                SetPlayerLocation();
                if (audio.clip != _TrackingBGM)
                {
                    audio.clip = _TrackingBGM;
                    audio.Play();
                }
                break;
            case false:
                TrackingTime = _TrackingRate;
                break;
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
            audio.clip = _DeathSE;
            audio.Play();
        }
    }
}
