using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDoor : MonoBehaviour
{

    //　ドアエリアに入っているかどうか
    private bool isNear;
    [SerializeField] GameObject clearUI;  //ゲームクリアUI

    [SerializeField] byte _KeyFlg = 7;  //キーフラグ用
    [SerializeField] GameObject Hand;
    private byte GetKeyFlg;     //プレイヤーのキーを取得する変数
    GameObject ManageObject;
    SceneFadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        GetKeyFlg = 0;
        //SceneFadeManagerがアタッチされているオブジェクトを取得
        ManageObject = GameObject.Find("ManageObject");
        //オブジェクトの中のSceneFadeManagerを取得
        fadeManager = ManageObject.GetComponent<SceneFadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isNear)
        {    //eキーが押されたら
            if(_KeyFlg == GetKeyFlg)
            {
                //Clear
                //clearUI.SetActive(true);
                fadeManager.fadeOutStart(0, 0, 0, 0, "Master_Ending_Text");
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
