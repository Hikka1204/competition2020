using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 特定の場所で特定のコメントを出すスクリプト */

public class Come_Flg : SingletonMonoBehaviour<Come_Flg>
{
    bool once_esc;
    int _HintNum = 0;

    public bool EscapeFlg; // true=逃げている、false=通常時

    GameObject ComeObj;
    [SerializeField] GameObject Com_Prehub;
    Come_List Lists;

    void Start()
    {
        ComeObj = GameObject.Find("Comment"); // UI「Comment」を入れいている
        EscapeFlg = false;
        once_esc = false;

        //Com_Prehub = GameObject.Find("Comments");// プレファブ「Comments」を入れいている
        Lists = Com_Prehub.GetComponent<Come_List>();
    }

    void Update()
    {
        // 逃げている間だけ逃げる系のコメントを生成
        if (EscapeFlg){
            if (!once_esc){
                once_esc = true;
                EscapeFlgCome();
            }
        }
        else{
            if (once_esc){
                once_esc = false;
                Invoke("addcomment", 3); 
            }
        }
    }

    // 敵から逃げきった後に通常会話を生成するためだけの関数
    void addcomment()
    {
        ComeObj.GetComponent<Come_Generate>().AddComment();
    }

    public void EscapeFlgCome()
    {
        if (EscapeFlg)
        {
            ComeObj.GetComponent<Come_Generate>().AddComment_Escape(Random.Range(0, CommentManager.Instance.Co_Escape.Length));
            Invoke("EscapeFlgCome", Random.Range(1, 3));
        }
    }

    public void ReactionCome()
    {
        //_ReactionNum = Random.Range(0, Lists.Reaction.Count);
        ComeObj.GetComponent<Come_Generate>().AddComment_Reaction(Random.Range(0, CommentManager.Instance.Co_Reaction.Length));
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    /*** リアクション系の生成しにいく ***/
    //    if (other.tag == "Reaction")
    //    {
    //    }
    //    /*** 逃げる系の生成しにいく ***/
    //    if (other.tag == "Escape")
    //    {
    //    }
    //    /*** ヒント系の生成しにいく ***/
    //    if (other.tag == "Hint")
    //    {
    //        ComeObj.GetComponent<Come_Generate>().AddComment_Hint(_HintNum);
    //        _HintNum++;
    //    }
    //    // ナースコール
    //    // ナースコール止めて扉の音が鳴ったあと
    //    // ズームで幽霊を見た後
    //}

}
