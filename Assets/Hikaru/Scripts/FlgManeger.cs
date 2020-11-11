using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlgManeger : MonoBehaviour
{
    private int flg = 0;
    [SerializeField] private GameObject _EnemyObject;   //エネミー
    [SerializeField] private GameObject _Uketuke_eve;   //地下室へ誘導するテキスト
    [SerializeField] private GameObject _Key1;  //最初の鍵
    [SerializeField] private GameObject _breakFloor; //壊れるオブジェクトの追加
    [SerializeField] private GameObject _destroyFloor;  //デストロイする床
    [SerializeField] private GameObject _exitDoorOpenSE;    //離れたらドアが開く音を鳴らすオブジェクト
    [SerializeField] private GameObject _stagingEnemy;  //演出用エネミー
    [SerializeField] private AudioSource _keyAudio;     //鍵の音
    [SerializeField] private GameObject _exitEvent;     //範囲外に出た時
    [SerializeField] private GameObject _ExampleOb;     //カメラ回す用オブジェクト イベントに使う
    [SerializeField] private GameObject _bloodHandP;    //血の手の親オブジェクト
    [SerializeField] private GameObject _NoteOb;        //ノートオブジェクト

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
                _Key1.SetActive(true);
                _keyAudio.Play();
                _Uketuke_eve.SetActive(true);
                break;
            case 2: //更衣室の鍵を拾った時
                _breakFloor.SetActive(true);
                _exitDoorOpenSE.SetActive(true);
                _stagingEnemy.SetActive(true);
                Destroy(_destroyFloor);
                break;
            case 3: //更衣室の手紙を読んだ時
                _exitEvent.SetActive(true);
                _NoteOb.SetActive(false);
                break;
            case 4: //診察室のノートを読んだ時
                
                _ExampleOb.SetActive(true);
                _bloodHandP.SetActive(true);
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
