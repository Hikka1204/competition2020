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
        TextSwitch(_KeyFlg);
        return _KeyFlg;
    }

    private void TextSwitch(byte key)
    {
        //FlagManager.Instance.Key_Text[key] = true;

        if(_KeyFlg != 2 && _KeyFlg != 3)
        {
            FlagManager.Instance.Key_Text[key] = true;
        }
        
        // 敵コメント表示
        switch (key)
        {
            case 1:
                FlagManager.Instance.Co_Enemy[1] = true;
                break;
            case 2:
                FlagManager.Instance.Co_Enemy[3] = true;
                break;
            case 7:
                FlagManager.Instance.Co_Enemy[10] = true;
                break;
        }
    }
}