﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nicoMove : MonoBehaviour
{
    float MoveSpeed = 2f;


    void Start()
    {
        // 文字数に応じて流れる速度を変更している
        if (this.GetComponent<Text>().text.Length >= 12) MoveSpeed = 2.5f;
        else if (this.GetComponent<Text>().text.Length >= 15) MoveSpeed = 3f;
        else if (this.GetComponent<Text>().text.Length >= 17) MoveSpeed = 3.5f;
    }

    void Update()
    {
        this.transform.position -= new Vector3(MoveSpeed, 0f, 0f);
    }
}
