using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WC_BlowAway : MonoBehaviour
{
    //スクリプト取得
    ChairBlowAway cba;
    WC_BlowAway wc_ba;
    WheelChair_Go wc_g;

    //車椅子の座標
    private Vector3 Wheelpos;

    bool move = false;
    bool five = false;

    // Start is called before the first frame update
    void Start()
    {
        cba = gameObject.GetComponent<ChairBlowAway>();
        wc_ba = gameObject.GetComponent<WC_BlowAway>();
        wc_g = gameObject.GetComponent<WheelChair_Go>();
        Wheelpos = this.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーが範囲に入ったか
        if(other.gameObject.tag == "Player" && !five)
        {
            wc_g.enabled = true;
            Debug.Log(move);
            
            if (move && !five)       //プレイヤーが目の前に来たか
            {
                five = true;
                wc_g.enabled = false;
                Invoke("Release", 2.0f);
            }
            move = true;
        }
    }

    //どっちのトリガーからもプレイヤーが離れたか
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"&& move && !five)
        {
            move = false;
            Debug.Log(move);
            wc_g.enabled = false;
            this.transform.position = Wheelpos;
        }
    }

    void Release()
    {
        if (move)
        {
            cba.enabled = true;
            Destroy(gameObject.GetComponent<WheelChair_Go>());
            Destroy(gameObject.GetComponent<WC_BlowAway>());
            
        }
    }
}
