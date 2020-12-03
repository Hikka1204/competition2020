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
    private bool Player_flg = false;      //ゲームオーバーフラグ
    [SerializeField] GlitchEffect camera;
    [SerializeField] private float Timedes = 5f;    //即デストロイしないようにするための変数
    private float TimedesTime;  //Timedesのセット用変数
    private Staging_Enemy StaEne;
    [SerializeField] GameObject PlayerOb;   //playerのオブジェクト
    [SerializeField] GameObject CameraOb;   //cameraのオブジェクト

    Zoom zoom;
    private Vector3 IntPo;
    private Vector3 IntRo;

    void Start()
    {
        //最初のポジション取得
        IntPo = transform.position;
        //最初の方向取得
        IntRo = gameObject.transform.localEulerAngles;
        //カメラのZoomスクリプトを取得
        zoom = CameraOb.GetComponent<Zoom>();
        //プレイヤーのNavMeshAgentを取得
        Enemy_Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        //Destination = GameObject.Find("Goal");
        Anim = GetComponent<Animator>();
        //Script格納
        StaEne = gameObject.GetComponent<Staging_Enemy>();
        //目的地を設定
        Enemy_Nav.SetDestination(Destination);
        Player_flg = false;
        TimedesTime = Timedes;
    }

    private void OnEnable()
    {
        if (Player_flg)
        {
            Enemy_Nav.enabled = false;
            //最初のポジションを格納
            transform.position = IntPo;
            transform.localEulerAngles = IntRo;
            Player_flg = false;
            Enemy_Nav.enabled = true;
            Enemy_Nav.SetDestination(Destination);
            TimedesTime = Timedes;
        }
    }

    void Update()
    {
        

        if(TimedesTime > 0)
        {
            TimedesTime -= Time.deltaTime;
            Anim.SetFloat("speed", Enemy_Nav.speed);
        }
        if (TimedesTime <= 0)
        {
            Player_flg = true;
            gameObject.SetActive(false);
        }

    }


}
