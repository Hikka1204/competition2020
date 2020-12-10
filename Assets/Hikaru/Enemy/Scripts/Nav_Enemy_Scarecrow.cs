﻿using System.Collections;
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
    [SerializeField] private Transform _Player_tr;
    [SerializeField] private Player_BGM _player_BGM;
    [SerializeField] private float _SearchRate; //探索時間が過ぎるとまた別の目的地に行く
    [SerializeField] private Vector3[] Location_Nav;
    [SerializeField] private float _TrackingRate;   //追いかける時間
    [SerializeField] private AudioClip _TrackingSE; //追いかけるときのSE
    [SerializeField] private AudioClip _DeathSE;    //プレイヤーを捕まえた時のSE
    [SerializeField] private float MaxSpeed = 4.5f; //エネミーの最大スピード
    [SerializeField] private float MinSpeed = 2.5f; //エネミーの最小スピード
    [SerializeField] private float Deceleration_speed = 0.01f;  //エネミーのスピードを毎フレーム減らす
    private float EnemySpeed;

    private AudioSource audio;  //AudioSource Component格納用
    NavMeshAgent Enemy_Nav;     //このオブジェクトについてるナビメッシュ
    private Animator Anim;      //アニメーション格納
    private bool Over_Flg;      //ゲームオーバーフラグ
    private bool Player_Get; //このスクリプトをaddcomponent時にplayerを発見した状態にするか
    private int Number;  //目的地のナンバー
    private bool Player_flg;    //playerを見つけたか見つけてないか
    private bool TrackingStatus;    //エネミーの追いかける状態 true:追いかけてる状態 false:追いかけてない状態
    private byte Move_Status;   //探索の状態
    private float SearchTime;   //_SearchRateの取得
    private float TrackingTime; //_TrackingRateの取得
    private bool ForeverTrackingflg;    //ずっと追いかけるかどうか
    private GameObject TrackingEnemy;   //子のプレイヤー索敵用オブジェクトの格納
    private bool floorChenge = false;   //false:地下 teue:一階
    private bool WaitEvent = false;     //一時待機させる
    private Quaternion IntRo;           //初期の向きを取得

    void Start()
    {
        //プレイヤーのNavMeshAgentを取得
        Enemy_Nav = GetComponent<NavMeshAgent>();
        audio = gameObject.GetComponent<AudioSource>();
        EnemySpeed = Enemy_Nav.speed;
        //目的地のオブジェクトを取得
        //Destination = GameObject.Find("Goal");
        Anim = GetComponent<Animator>();
        //目的地を設定
        //Enemy_Nav.SetDestination(Destination.position);
        TrackingEnemy = gameObject.transform.GetChild(5).gameObject;
        Over_Flg = false;
        Player_flg = false;
        TrackingStatus = false;
        ForeverTrackingflg = false;
        SearchTime = _SearchRate;
        Number = 0;
        Anim.SetFloat("speed", Enemy_Nav.speed);
        IntRo = transform.localRotation;
        SetSearchLocation();
        floorChenge = false;
    }

    void Update()
    {
        if (!WaitEvent)
        {

            Anim.SetFloat("speed", Enemy_Nav.speed);

            if (Over_Flg == false)
            {
                if (ForeverTrackingflg)
                {
                    SetPlayerLocation();
                }

                else if (!ForeverTrackingflg)
                {
                    if (Player_Get == false && TrackingTime > 0)
                    {
                        TrackingTime -= Time.deltaTime;
                        SetPlayerLocation();
                        if (TrackingTime <= 0)
                        {
                            TrackingStatus = false;
                            CommentManager.Instance.Escape_Flg = false;
                            SetSearchLocation();
                            _player_BGM.GetComponent<Player_BGM>().BGMPlay(0);
                            audio.Stop();
                        }
                    }
                    else if (Player_Get == true)
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
            }
        }

    }

    public void FloorChenge(bool a)
    {
        floorChenge = a;
    }

    public void Respawn()
    {
        TrackingEnemy.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        Over_Flg = false;
        Player_flg = false;
        Player_Get = false;
        TrackingStatus = false;
        CommentManager.Instance.Escape_Flg = false;
        ForeverTrackingflg = false;
        SearchTime = _SearchRate;
        TrackingTime = 0;
        Number = 0;
        Anim.SetFloat("speed", Enemy_Nav.speed);
        _player_BGM.GetComponent<Player_BGM>().BGMPlay(0);
        SetSearchLocation();
        TrackingEnemy.GetComponent<BoxCollider>().enabled = true;
    }

    public bool Get_Over_Flg()
    {
        return Over_Flg;
    }

    private void SetPlayerLocation()
    {
        Enemy_Nav.SetDestination(_Player_tr.gameObject.transform.position);
        if(EnemySpeed >= MinSpeed)
        {
            EnemySpeed -= Deceleration_speed;
            Enemy_Nav.speed = EnemySpeed;
        }
        
    }

    private void SetSearchLocation()
    {
        Enemy_Nav.speed = MinSpeed;
        int RandomNumber;   //ランダムな値を取得
        while (true)
        {
            RandomNumber = Random.Range(0, Location_Nav.Length);
            if (Number != RandomNumber)
            {
                Number = RandomNumber;
                Enemy_Nav.SetDestination(Location_Nav[Number]);
                SearchTime = _SearchRate;
                Anim.SetFloat("speed", Enemy_Nav.speed);
                break;
            }
        }
        
    }

    

    public bool GetTrackingStatus()
    {
        return TrackingStatus;
    }

    public void SetForeverTracking(bool a)
    {
        ForeverTrackingflg = a;
        _player_BGM.GetComponent<Player_BGM>().BGMPlay(1);
        Anim.SetFloat("speed", Enemy_Nav.speed);
        audio.clip = _TrackingSE;
        audio.Play();
    }

    public void GetPlayer(int Get)
    {
        switch (Get)
        {
            case 0:
                SetPlayerLocation();
                if (Player_Get == false && TrackingTime <= 0)
                {
                    TrackingStatus = true;
                    CommentManager.Instance.Escape_Flg = true;
                    _player_BGM.GetComponent<Player_BGM>().BGMPlay(1);
                    Anim.SetFloat("speed", Enemy_Nav.speed);
                    audio.clip = _TrackingSE;
                    audio.Play();
                    EnemySpeed = MaxSpeed;
                    WaitEvent = false;
                }
                break;
            case 1:
                if(Player_Get == true) TrackingTime = _TrackingRate;
                break;
            case 2:
                if(TrackingTime > 0 || Player_Get == true)
                {
                    _player_BGM.GetComponent<Player_BGM>().BGMPlay(0);
                    audio.Stop();
                }
                TrackingTime = 0;
                SetSearchLocation();
                break;

            case 4:
                Anim.SetFloat("speed", 0.0f);
                Enemy_Nav.SetDestination(gameObject.transform.position);
                WaitEvent = true;
                break;
            case 5:
                Anim.SetFloat("speed", 1.0f);
                WaitEvent = false;
                break;
            case 6:
                Anim.SetTrigger("attack");
                Enemy_Nav.SetDestination(gameObject.transform.position);
                WaitEvent = true;
                break;
        }
        //Player_Get = Get;
        if(Get == 0)
        {
            Player_Get = true;
        }
        else if(Get == 1 || Get == 2) Player_Get = false;
    }

    public void PlayerSpawn()
    {
        //目的地を設定
        //Enemy_Nav.SetDestination(Destination.position);
        Over_Flg = false;
        Player_flg = false;
        TrackingStatus = false;
        CommentManager.Instance.Escape_Flg = false;
        ForeverTrackingflg = false;
        Player_Get = false;
        SearchTime = 1;
        Number = 0;
        Anim.SetFloat("speed", Enemy_Nav.speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (Over_Flg == false && collision.gameObject.tag == "Player") 
        {
            var aim = collision.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = new Quaternion(IntRo.x,look.y, IntRo.z, IntRo.w);
            Enemy_Nav.SetDestination(gameObject.transform.position);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            TrackingStatus = false;
            CommentManager.Instance.Escape_Flg = false;
            //SetSearchLocation();
            _player_BGM.GetComponent<Player_BGM>().BGMPlay(0);
            audio.Stop();
            Anim.SetBool("attack", true);
            Over_Flg = true;
            audio.clip = _DeathSE;
            audio.Play();
        }
    }
}
