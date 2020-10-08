using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    [SerializeField] private int minute;
    [SerializeField] private float seconds;

    private float oldSeconds; //　前のUpdateの時の秒数
    private Text timerText;   //　タイマー表示用テキスト

    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = "00" + ":" + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
}
