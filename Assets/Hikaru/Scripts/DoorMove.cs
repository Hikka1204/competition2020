using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour {

    //　ドアエリアに入っているかどうか
    private bool isNear;
    //　ドアのアニメーター
    private Animator animator;

    [SerializeField] private float _speed = 1;  //ドアのアニメーション速度

    void Start()
    {
        isNear = false;
        animator = transform.GetComponent<Animator>();
        animator.speed = _speed;
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && isNear)
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isNear = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isNear = false;
        }
    }

    //   [SerializeField] private float _speed;   //動くスピード
    //   [SerializeField] private float _angle_Y;  //Yの方角 ドアの傾きをどこまで増やすか
    //   [SerializeField] private float _waitRate;    //ドアの待機時間入力
    //   private float WaitTime; //ドアを開いた後の閉まるまでの待機時間 
    //   private bool OpenFlag;      //TRUE:開く   FALSE:閉まる
    //   private Transform IntObjectTr;  //このスクリプトのトランスフォームを取得

    //   // Use this for initialization
    //   void Start () {
    //       IntObjectTr = gameObject.transform;     //オブジェクトのトランスフォームの初期値を追加
    //       OpenFlag = false;

    //   }

    //// Update is called once per frame
    //void Update () {
    //       if (WaitTime > 0)
    //       {
    //           WaitTime -= Time.deltaTime;
    //       }

    //       if(OpenFlag == true && IntObjectTr.localEulerAngles.y + _angle_Y >= transform.localEulerAngles.y)
    //       {
    //           var Angle = transform.localEulerAngles;
    //           transform.Rotate(0, _speed, 0);
    //           if(OpenFlag == true && IntObjectTr.localEulerAngles.y + _angle_Y <= transform.localEulerAngles.y)
    //           {
    //               OpenFlag = false;
    //               Debug.Log("とまれ？");
    //               transform.localEulerAngles = new Vector3(Angle.x, IntObjectTr.localEulerAngles.y + _angle_Y, Angle.z);
    //           }
    //       }

    //   }

    //   private void OnTriggerStay(Collider other)  //当たり判定の中にいる時に
    //   {
    //       if(OpenFlag == false && other.gameObject.tag == "Player" && Input.GetKey("e"))    //Eキーを押すと開く
    //       {
    //           OpenFlag = true;
    //           Debug.Log("開け？");
    //       }
    //   }

}
