using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 特定の場所で特定のコメントを出すスクリプト */

public class Come_Flg : SingletonMonoBehaviour<Come_Flg>
{
    int _ReactionNum;
    int _EscapeNum;
    int _HintNum = 0;

    GameObject ComeObj;
    [SerializeField] GameObject Com_Prehub;
    Come_List Lists;

    void Start()
    {
        ComeObj = GameObject.Find("Comment"); // UI「Comment」を入れいている

        //Com_Prehub = GameObject.Find("Comments");// プレファブ「Comments」を入れいている
        Lists = Com_Prehub.GetComponent<Come_List>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*** リアクション系の生成しにいく ***/
        if (other.tag == "Reaction")
        {
            _ReactionNum = Random.Range(0, Lists.Reaction.Count); 
            ComeObj.GetComponent<Come_Generate>().AddComment_Reaction(_ReactionNum);
        }
        /*** 逃げる系の生成しにいく ***/
        if (other.tag == "Escape")
        {
            _EscapeNum = Random.Range(0, Lists.Escape.Count); 
            ComeObj.GetComponent<Come_Generate>().AddComment_Escape(_EscapeNum);
        }
        /*** ヒント系の生成しにいく ***/
        if (other.tag == "Hint")
        {
            ComeObj.GetComponent<Come_Generate>().AddComment_Hint(_HintNum);
            _HintNum++;
        }
        // ナースコール
        // ナースコール止めて扉の音が鳴ったあと
        // ズームで幽霊を見た後
    }

}
