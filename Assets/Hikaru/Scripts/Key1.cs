using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{

    [SerializeField]private byte _KeyFlg = 1;
    [SerializeField] private byte _fmgFlg = 2;
    [SerializeField] private FlgManeger fmg;
    [SerializeField] private bool StartSetActive = true;

    private void Start()
    {
        if (StartSetActive == false)
        {
            gameObject.SetActive(false);
        }
    }

    public byte GetKey()
    {
        fmg.GetFlg(_fmgFlg);
        return _KeyFlg;
    }
}