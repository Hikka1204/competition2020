using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 特定の場所で特定のコメントを出すスクリプト */

public class Come_Flg : SingletonMonoBehaviour<Come_Flg>
{
    bool once_esc;
    int _HintNum;   // ヒント系のコメントを順番に出すため

    GameObject ComeObj;
    [SerializeField] GameObject Com_Prehub;
    private CommentManager commentManager;

    void Start()
    {
        ComeObj = GameObject.FindGameObjectWithTag("Comment"); // UI「Comment」を入れいている
        _HintNum = 0;
        once_esc = false;

    }

    void Update()
    {
        
        // 逃げている間だけ逃げる系のコメントを生成
        if (CommentManager.Instance.Escape_Flg)
        {
            if (!once_esc){
                once_esc = true;
                EscapeFlgCome();
            }
        }
        else{
            if (once_esc){
                once_esc = false;
                Invoke("addcomment", Random.Range(3, 5)); 
            }
        }

        //// ヒント系コメントを0～順にコメントさせている
        //if (FlagManager.Instance.Co_Hint[_HintNum] == true)
        //{
        //    ComeObj.GetComponent<Come_Generate>().AddComment_Hint(_HintNum);
        //    FlagManager.Instance.Co_Hint[_HintNum] = false;
        //    _HintNum++;
        //}

        // 

        //if (FlagManager.Instance.Co_Hint[0])
        //{
        //    ComeObj.GetComponent<Come_Generate>().AddComment_Hint(0);
        //    FlagManager.Instance.Co_Hint[0] = false;
        //    _HintNum++;
        //}  // No.1:ナースコールが鳴った時のコメント
        //if (FlagManager.Instance.Co_Hint[1])
        //{
        //    ComeObj.GetComponent<Come_Generate>().AddComment_Hint(_HintNum);
        //    Invoke("HintCome", 2); 
        //    FlagManager.Instance.Co_Hint[1] = false;
        //}
    }

    void HintCome()
    {
        _HintNum++;
        //ComeObj.GetComponent<Come_Generate>().AddComment_Hint(_HintNum);
    }

    // 敵から逃げきった後に通常会話を生成するためだけの関数
    void addhint()
    {
        ComeObj.GetComponent<nico>().AddComment();
    }

    void addcomment()
    {
        ComeObj.GetComponent<nico>().AddComment();
    }

    public void EscapeFlgCome()
    {
        if (CommentManager.Instance.Escape_Flg)
        {
            Debug.Log("逃走中");
            ComeObj.GetComponent<nico>().AddComment_Escape();
            Invoke("EscapeFlgCome", Random.Range(1, 3));
        }
    }

    public void ReactionCome()
    {
        //_ReactionNum = Random.Range(0, Lists.Reaction.Count);
        //ComeObj.GetComponent<Come_Generate>().AddComment_Reaction();
    }

   
    //    // ナースコール
    //    // ナースコール止めて扉の音が鳴ったあと
    //    // ズームで幽霊を見た後
    //}

}
