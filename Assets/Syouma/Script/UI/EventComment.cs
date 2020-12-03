﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComment : MonoBehaviour
{
    bool once; // 一回だけ通る用
    void Start()
    {
        once = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!once)
        {
            FlagManager.Instance.Co_Event[8] = true; // イベントコメント表示
            once = true;
        }
    }
}
