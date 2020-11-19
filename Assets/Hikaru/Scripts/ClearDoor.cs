﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDoor : MonoBehaviour
{

    //　ドアエリアに入っているかどうか
    private bool isNear;
    [SerializeField] GameObject clearUI;  //ゲームクリアUI

    [SerializeField] byte _KeyFlg = 6;  //キーフラグ用
    [SerializeField] GameObject Hand;
    private byte GetKeyFlg;     //プレイヤーのキーを取得する変数


    // Start is called before the first frame update
    void Start()
    {
        GetKeyFlg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isNear)
        {    //eキーが押されたら
            if(_KeyFlg == GetKeyFlg)
            {
                //Clear
                clearUI.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hand")
        {
            isNear = true;
            if (_KeyFlg > 0)
            {
                GetKeyFlg = Hand.GetComponent<Hand>().GetKey();
            }
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
