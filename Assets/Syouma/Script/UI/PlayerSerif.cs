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
        // No.0 : 鍵がない状態で出口を調べた時のセリフ
        if (FlagManager.Instance.flags[0] == true){
            this.GetComponent<Text>().text = "鍵がかかっているようだ";
            TextControl(0);
        }
        // No.1 : 
        else if (FlagManager.Instance.flags[1] == true)
        {
            this.GetComponent<Text>().text = "何だあれは！";
            TextControl(1);
        }

    }

    void TextControl (int i)
    {
        Invoke("TextClear", WaitTime);
        FlagManager.Instance.flags[i] = false;
    }

    void TextClear()
    {
        this.GetComponent<Text>().text = "";
    }
}
