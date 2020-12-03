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
    [SerializeField] private Transform _Player_tr;
    [SerializeField] private Player_BGM _player_BGM;
    [SerializeField] private float _SearchRate; //探索時間が過ぎるとまた別の目的地に行く
    [SerializeField] private Vector3[] Location_Nav;
    [SerializeField] private float _TrackingRate;   //追いかける時間
    [SerializeField] private AudioClip _TrackingSE;
    [SerializeField] private AudioClip _DeathSE;

    private AudioSource audio;
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
        TrackingStatus = false;
        ForeverTrackingflg = false;
        SearchTime = _SearchRate;
        Number = 0;
        Anim.SetFloat("speed", Enemy_Nav.speed);
        SetSearchLocation();
    }

    void Update()
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

        //if (Over_Flg == false)
        //{
        //    //目的地を設定
        //    //Enemy_Nav.SetDestination(Destination);
        //    Anim.SetFloat("speed", Enemy_Nav.speed);
        //}
    }

    public void Respawn()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        Over_Flg = false;
        Player_flg = false;
        Player_Get = false;
        TrackingStatus = false;
        CommentManager.Instance.Escape_Flg = false;
        ForeverTrackingflg = false;
        SearchTime = 0.1f;
        TrackingTime = 0;
        Number = 0;
        Anim.SetFloat("speed", Enemy_Nav.speed);
        SetSearchLocation();
    }

    public bool Get_Over_Flg()
    {
        return Over_Flg;
    }

    private void SetPlayerLocation()
    {
        Enemy_Nav.SetDestination(_Player_tr.gameObject.transform.position);
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

    public void GetPlayer(bool Get)
    {
        switch (Get)
        {
            case true:
                SetPlayerLocation();
                if (Player_Get == false && TrackingTime <= 0)
                {
                    TrackingStatus = true;
                    CommentManager.Instance.Escape_Flg = true;
                    _player_BGM.GetComponent<Player_BGM>().BGMPlay(1);
                    Anim.SetFloat("speed", Enemy_Nav.speed);
                    audio.clip = _TrackingSE;
                    audio.Play();
                }
                break;
            case false:
                TrackingTime = _TrackingRate;
                break;
        }
        Player_Get = Get;
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
