using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSerif : MonoBehaviour
{
    const float WaitTime = 3f; // セリフの表示時間
    private bool ispushE = false;

    void Start()
    {
        ispushE = false;
    }

    void Update()
    {
        Serif();
        Key();
    }

    private void Serif()
    {
        // No.0 : 鍵がない状態で出口を調べた時のセリフ
        if (FlagManager.Instance.SerifFlg[0] == true)
        {
            this.GetComponent<Text>().text = "鍵がかかっているようだ";
            TextControl(0);
        }

        // No.1 : 
        else if (FlagManager.Instance.SerifFlg[1] == true)
        {
            this.GetComponent<Text>().text = "何だあれは！";
            TextControl(1);
        }

        if (FlagManager.Instance.SerifFlg[2] == true)
        {
            this.GetComponent<Text>().text = "入口が塞がれてしまった";
            TextControl(2);
        }

        if (FlagManager.Instance.SerifFlg[3] == true)
        {
            this.GetComponent<Text>().text = "どこかで「出口」を探さないと！";
            TextControl(3);
        }
    }

    private void Key()
    {
        if (FlagManager.Instance.Key_Text[0] == true)
        {
            this.GetComponent<Text>().text = "カギがかかっている";

            KeyControl(0);
        }
        if (FlagManager.Instance.Key_Text[1] == true)
        {
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 60, po.z);
            this.GetComponent<Text>().text = "地下の更衣室のカギが手に入れた\n「ここは二階じゃなくて地下があるのか…」";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                ispushE = false;
                FlagManager.Instance.Key_Text[1] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
            //StartCoroutine(e_PlayerSerif("「ここは二階じゃなくて地下があるのか…」", 1));
        }
        if (FlagManager.Instance.Key_Text[2] == true)
        {
            this.GetComponent<Text>().text = "中央の階段のカギを手に入れた";
            StartCoroutine(e_PlayerSerif("「これで戻れそうだ」", 2));
        }
        if (FlagManager.Instance.Key_Text[3] == true)
        {
            this.GetComponent<Text>().text = "１階の診察室のカギを手に入れた";
            StartCoroutine(e_PlayerSerif("「確か入り口の横の部屋だ」", 3));
        }
        if (FlagManager.Instance.Key_Text[4] == true)
        {
            this.GetComponent<Text>().text = "地下の資料室のカギを手に入れた";
            StartCoroutine(e_PlayerSerif("「地下に落ちた場所のすぐ近くだったような…」", 4));
        }
        if (FlagManager.Instance.Key_Text[5] == true)
        {
            this.GetComponent<Text>().text = "１階の手術室のカギを手に入れた";
            StartCoroutine(e_PlayerSerif("「確か受付の前の部屋のはずだ」", 5));
        }
        if (FlagManager.Instance.Key_Text[6] == true)
        {
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 60, po.z);
            this.GetComponent<Text>().text = "地下の霊安室のカギを手に入れた\n「地下の奥…長い一本道を進んだところにあったような」";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                ispushE = false;
                FlagManager.Instance.Key_Text[6] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
            //StartCoroutine(e_PlayerSerif("「ここは二階じゃなくて地下があるのか…」", 1));
        }
        if (FlagManager.Instance.Key_Text[7] == true)
        {
            this.GetComponent<Text>().text = "１階の非常口のカギを手に入れた";
            StartCoroutine(e_PlayerSerif("「やった！これで出られる…!!」", 7));
        }
        if (FlagManager.Instance.Key_Text[8] == true)
        {
            this.GetComponent<Text>().text = "カギを開けた";
            KeyControl(8);
        }
        if (FlagManager.Instance.Key_Text[9] == true)
        {
            this.GetComponent<Text>().text = "…？開かない…";
            KeyControl(9);
        }
    }

    void TextControl (int i)
    {
        Invoke("TextClear", WaitTime);
        FlagManager.Instance.SerifFlg[i] = false;
    }

    void KeyControl(int i)
    {
        Invoke("TextClear", WaitTime);
        FlagManager.Instance.Key_Text[i] = false;
    }


    private IEnumerator e_PlayerSerif(string P_serif,int i)
    {
        FlagManager.Instance.Key_Text[i] = false;
        yield return new WaitForSeconds(WaitTime); //待つ
        this.GetComponent<Text>().text = P_serif;
        yield return new WaitForSeconds(WaitTime); //待つ
        TextClear();
        yield break;
    }

    void TextClear()
    {
        this.GetComponent<Text>().text = "";
    }
}
