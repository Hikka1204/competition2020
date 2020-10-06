using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlgManeger : MonoBehaviour
{
    private int flg = 0;
    [SerializeField] private GameObject _Key1;  //最初の鍵
    [SerializeField] private GameObject _breakFloor; //壊れるオブジェクトの追加
    [SerializeField] private GameObject _destroyFloor;  //デストロイする床
    [SerializeField] private GameObject _exitDoorOpenSE;    //離れたらドアが開く音を鳴らすオブジェクト
    [SerializeField] private GameObject _stagingEnemy;  //演出用エネミー
    [SerializeField] private AudioSource _keyAudio;     //鍵の音

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
            case 1:
                _Key1.SetActive(true);
                _keyAudio.Play();
                break;
            case 2:
                _breakFloor.SetActive(true);
                _breakFloor.gameObject.AddComponent<FloorBreak>();
                _exitDoorOpenSE.SetActive(true);
                _stagingEnemy.SetActive(true);
                Destroy(_destroyFloor);
                break;
        }

        
    }
}
