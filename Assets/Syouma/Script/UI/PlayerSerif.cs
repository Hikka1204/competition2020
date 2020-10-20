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
        if (FlagManager.Instance.flags[0] == true){
            this.GetComponent<Text>().text += "鍵がかかっているようだ";
            FlagManager.Instance.flags[0] = false;
        }

    }
}
