using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorMove : MonoBehaviour {

    //　ドアエリアに入っているかどうか
    private bool isNear;
    //　ドアのアニメーター
    private Animator animator;
    [SerializeField] private float _CloseRate = 2f;   //開いて閉まるまでの時間
    private float CloseTime;    //上の変数の格納用

    [SerializeField] byte _KeyFlg;  //キーフラグ用
    private byte IntKey;
    private byte GetKeyFlg;     //プレイヤーのキーを取得する変数
    [SerializeField] private float _speed = 1f;  //ドアのアニメーション速度

    private AudioSource audioSource;

    [SerializeField] GameObject Hand;

    [SerializeField] AudioClip _OpenSE;
    [SerializeField] AudioClip _CloseSE;
    [SerializeField] AudioClip _KeyInSE;
    [SerializeField] AudioClip _KeyOutSE;

    void Start()
    {
        isNear = false;
        animator = transform.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.speed = _speed;
        IntKey = _KeyFlg;
    }

    void Update()
    {
        if (CloseTime > 0)   //開いた後に閉まるまでの処理
        {
            CloseTime -= Time.deltaTime;

            if (CloseTime <= 0 && animator.GetBool("Open") == true)
            {
                animator.SetBool("Open", false);
            }
        }


        if (Input.GetKeyDown("e") && isNear )    //eキーが押されたら開くか閉まる
        {
            if (_KeyFlg == 0)   //鍵無しドアなら
            {
                animator.SetBool("Open", !animator.GetBool("Open"));
                //if (animator.GetBool("Open") == true)    //開くなら閉まる時間を格納する
                //{
                //    CloseTime = _CloseRate;
                //}
                //else //閉まるドアの音
                //{
                //    CloseTime = 0;
                //}
            }
            else if (_KeyFlg <= GetKeyFlg)  //鍵付きなら鍵を持ってるか判断する
            {
                _KeyFlg = 0;    //鍵無しドアにする
                FlagManager.Instance.SerifFlg[8] = true;
                audioSource.clip = _KeyInSE;
                audioSource.Play();
            }
            else //鍵を持たずに鍵付きドアを開けようとしたとき
            {
                FlagManager.Instance.SerifFlg[0] = true;
                audioSource.clip = _KeyOutSE;
                audioSource.Play();
            }
        }

        if(IntKey != 0 && Input.GetKey(KeyCode.R) && IntKey >= Hand.GetComponent<Hand>().GetKey())
        {
            if (_KeyFlg != IntKey)
            {
                _KeyFlg = IntKey;
            }
            
        }
        
    }

    public void OpenSE()    //アニメーションに関数を追加している //ドアが開く音
    {
        this.tag = "DoorOpen";
        audioSource.clip = _OpenSE;
        audioSource.Play();
    }

    public void CloseSE()   //アニメーションに関数を追加している //ドアが閉まる音
    {
        this.tag = "DoorClose";
        audioSource.clip = _CloseSE;
        audioSource.Play();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player"|| col.gameObject.tag == "Hand")
        {
            isNear = true;
            if(_KeyFlg > 0)
            {
                GetKeyFlg = Hand.GetComponent<Hand>().GetKey();
            }
            return;
        }

        if(col.gameObject.tag == "Enemy_Anim" || (col.gameObject.tag == "Enemy" && col.gameObject.GetComponent<Nav_Enemy_Scarecrow>().GetTrackingStatus() == true))
        {
            animator.SetBool("Open", true);
            CloseTime = _CloseRate;
            return;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hand")
        {
            isNear = false;
        }
    }


}
