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
    private Staging_Enemy StaEne;
    [SerializeField] GameObject PlayerOb;   //playerのオブジェクト
    [SerializeField] GameObject CameraOb;   //cameraのオブジェクト
    Zoom zoom;

    void Start()
    {
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
                PlayerOb.GetComponent<CharacterController>().enabled = true;
                PlayerOb.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                camera.enabled = false;
                //gameObject.GetComponent<Staging_Enemy>().
                Destroy(gameObject);
                gameObject.SetActive(false);
                StaEne.enabled = false;
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(Player_flg == false && other.gameObject.tag == "Player")
        {
            Enemy_Nav.SetDestination(Destination);
            PlayerOb.GetComponent<CharacterController>().enabled = false;
            PlayerOb.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Player_flg = true;
            Destroy(_StaColi);
            Anim.SetFloat("speed", Enemy_Nav.speed);
            camera.enabled = true;

            // ズームさせる処理
            zoom.Zoomflg = true;

        }
    }
}
