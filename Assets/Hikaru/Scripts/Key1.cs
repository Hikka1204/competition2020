﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{

    [SerializeField]private byte _KeyFlg = 2;
    [SerializeField] private FlgManeger fmg;

    public byte GetKey()
    {
        fmg.GetFlg(_KeyFlg);
        return _KeyFlg;
    }
}