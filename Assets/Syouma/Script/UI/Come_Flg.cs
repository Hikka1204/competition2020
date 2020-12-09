using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 特定の場所で特定のコメントを出すスクリプト */

public class Come_Flg : SingletonMonoBehaviour<Come_Flg>
{
    bool once_esc;
    int _EventNum; // イベント番号を入れている
    int _EventComeNum; // イベントコメント番号を入れている
    int _EnemyNum; // 敵コメントのフラグ番号を入れている

    GameObject ComeObj;
    [SerializeField] GameObject Com_Prehub;
    private CommentManager commentManager;

    void Start()
    {
        ComeObj = GameObject.FindGameObjectWithTag("Comment"); // UI「Comment」を入れいている
        _EventNum = 0;
        _EventComeNum = 0;
        _EnemyNum = 0;
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

        // ヒント系コメントを0～順にコメントさせている
        if (FlagManager.Instance.Co_Event[_EventNum] && !CommentManager.Instance.Event_Flg)
        {
            CommentManager.Instance.Event_Flg = true;
            Invoke("HintCome", Random.Range(1, 2));
        }
        if (FlagManager.Instance.Co_Enemy[_EnemyNum])
        {
            Invoke("EnemyflgCome", 1);
            _EnemyNum++;
        }
    }

    /*--------------------------------------------------------------------------------*/

    void HintCome()
    {
        if (CommentManager.Instance.Event_Flg)
        {
            Debug.Log("イベント中");
            ComeObj.GetComponent<nico>().AddComment_Hint(_EventNum, _EventComeNum);

            if (CommentManager.Instance.Event[_EventNum].E_Comment[_EventComeNum+1] != null)
            {
                switch (_EventNum)
                {
                    case 4:
                    case 6:
                    case 8:
                        Invoke("HintCome", Random.Range(1, 2));
                        break;
                    default:
                        Invoke("HintCome", Random.Range(1, 3));
                        break;
                }
            }
            else
            {
                CommentManager.Instance.Event_Flg = false;
                //FlagManager.Instance.Co_Event[_EventNum] = false;
                once_esc = false;
                _EventNum++;
                _EventComeNum = 0;
                Invoke("addcomment", Random.Range(2, 4));
            }
            _EventComeNum++;
        }
    }

    public void EscapeFlgCome()
    {
        if (CommentManager.Instance.Escape_Flg)
        {
            ComeObj.GetComponent<nico>().AddComment_Escape();
            Invoke("EscapeFlgCome", Random.Range(1, 3));
        }
    }

    public void EnemyflgCome()
    {
        ComeObj.GetComponent<nico>().AddComment_Enemy(_EnemyNum - 1);
    }

    // 敵から逃げきった後に通常会話を生成するためだけの関数
    void addcomment()
    {
        ComeObj.GetComponent<nico>().AddComment();
    }

    public void ReactionCome()
    {
        //_ReactionNum = Random.Range(0, Lists.Reaction.Count);
        //ComeObj.GetComponent<Come_Generate>().AddComment_Reaction();
    }

}
