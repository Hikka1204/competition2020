using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSerif : MonoBehaviour
{
    const float WaitTime = 3f; // セリフの表示時間

    void Start()
    {

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
            this.GetComponent<Text>().text = "地下の更衣室のカギが手に入れた";
            KeyControl(1);
        }
        if (FlagManager.Instance.Key_Text[2] == true)
        {
            this.GetComponent<Text>().text = "中央の階段のカギを手に入れた";
            KeyControl(2);
        }
        if (FlagManager.Instance.Key_Text[3] == true)
        {
            this.GetComponent<Text>().text = "１階の診察室のカギを手に入れた";
            KeyControl(3);
        }
        if (FlagManager.Instance.Key_Text[4] == true)
        {
            this.GetComponent<Text>().text = "地下の資料室のカギを手に入れた";
            KeyControl(4);
        }
        if (FlagManager.Instance.Key_Text[5] == true)
        {
            this.GetComponent<Text>().text = "１階の手術室のカギを手に入れた";
            KeyControl(5);
        }
        if (FlagManager.Instance.Key_Text[6] == true)
        {
            this.GetComponent<Text>().text = "地下の霊安室のカギを手に入れた";
            KeyControl(6);
        }
        if (FlagManager.Instance.Key_Text[7] == true)
        {
            this.GetComponent<Text>().text = "１階の非常口のカギを手に入れた";
            KeyControl(7);
        }
        if (FlagManager.Instance.Key_Text[8] == true)
        {
            this.GetComponent<Text>().text = "扉のカギが開いた！";
            KeyControl(8);
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

    void KeyPlayerText(int i)
    {
        
        switch (i)
        {

        }
        //Invoke("TextClear", WaitTime);
    }

    private IEnumerator e_PlayerSerif(string character)
    {


        yield return new WaitForSeconds(0.5f); //待つ


        yield break;
    }

    void TextClear()
    {
        this.GetComponent<Text>().text = "";
    }
}
