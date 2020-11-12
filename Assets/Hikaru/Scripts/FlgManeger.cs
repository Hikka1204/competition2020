using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlgManeger : MonoBehaviour
{
    private int flg = 0;
    //[SerializeField] private GameObject _EnemyObject;   //エネミー
    [SerializeField] private GameObject _Uketuke_eve;   //地下室へ誘導するテキスト
    [SerializeField] private GameObject _Changing_room_rust_key;    //更衣室のカギ
    [SerializeField] private GameObject _Examination_room_rust_key; //診察室のカギ
    [SerializeField] private GameObject _Stairs_rust_key; //階段のカギ
    [SerializeField] private GameObject _Operating_room_rust_key; //手術室のカギ
    [SerializeField] private GameObject _Morgue_rust_key; //霊安室のカギ
    [SerializeField] private GameObject _Emergency_exit_rust_key; //非常口のカギ
    [SerializeField] private GameObject _breakFloor; //壊れるオブジェクトの追加
    [SerializeField] private GameObject _floor65_Des;  //デストロイする床
    [SerializeField] private GameObject _exitDoorOpenSE;    //離れたらドアが開く音を鳴らすオブジェクト
    [SerializeField] private GameObject _Event_Enter_Reference_room;    //資料室のイベント
    [SerializeField] private GameObject _stagingEnemy;  //演出用エネミー
    [SerializeField] private AudioSource _keyAudio;     //鍵の音
    [SerializeField] private GameObject _EnterEvent;     //範囲外に出た時
    [SerializeField] private GameObject _cameraRoll;     //カメラ回す用オブジェクト イベントに使う
    [SerializeField] private GameObject _bloodHandP;    //血の手の親オブジェクト
    [SerializeField] private GameObject _letter;        //手紙
    [SerializeField] private GameObject _NoteOb;        //ノートオブジェクト
    [SerializeField] private GameObject operating_room_lighting;  //手術室の点灯

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetFlg(int gflg)
    {
        if(flg < gflg)
        {
            flg = gflg;
            InitObject();
        }
        
    }

    private void InitObject()
    {
        switch (flg)
        {
            case 1: //音を止めた時
                _Changing_room_rust_key.gameObject.SetActive(true);
                _keyAudio.Play();
                _Uketuke_eve.gameObject.SetActive(true);
                break;
            case 2: //更衣室の鍵を拾った時
                _breakFloor.gameObject.SetActive(true);
                _exitDoorOpenSE.gameObject.SetActive(true);
                _stagingEnemy.gameObject.SetActive(true);
                _Examination_room_rust_key.gameObject.SetActive(true);
                _Stairs_rust_key.gameObject.SetActive(true);
                _letter.gameObject.SetActive(true);
                Destroy(_floor65_Des);
                break;
            case 3: //更衣室の手紙を読んだ時
                _EnterEvent.gameObject.SetActive(true);
                _NoteOb.gameObject.SetActive(true);
                break;
            case 4: //診察室のノートを読んだ時
                _cameraRoll.gameObject.SetActive(true);
                _bloodHandP.SetActive(true);
                break;
            case 5: //資料室でイベントが起きた時
                _Event_Enter_Reference_room.gameObject.SetActive(true);
                _Operating_room_rust_key.gameObject.SetActive(true);
                operating_room_lighting.GetComponent<op_room_lighting>().enabled = true;
                break;
            case 6: //手術室のカギを取ったら
                _Morgue_rust_key.gameObject.SetActive(true);
                break;
            case 7: //霊安室のカギを取ったら
                _Emergency_exit_rust_key.gameObject.SetActive(true);
                
                break;

            default:
                break;
        }
    }

    public void PlayerSpawn()
    {
        switch (flg)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    } 

}
