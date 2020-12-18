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

    const float timeOut = 10f; // イベントコメントのインターバル(秒)
    float timeElapsed; // 経過時間を入れる変数

    GameObject ComeObj;
    [SerializeField] GameObject Com_Prehub;
    private CommentManager commentManager;

    void Start()
    {
        ComeObj = GameObject.FindGameObjectWithTag("Comment"); // UI「Comment」を入れいている
        _EventNum = 0;
        _EventComeNum = 0;
        _EnemyNum = 0;
        FlagManager.Instance.Eventroop = true;
        once_esc = false;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime; // 経過秒を計算

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

        // イベントコメントを0～順生成させている
        if (FlagManager.Instance.Co_Event[_EventNum] && !CommentManager.Instance.Event_Flg)
        {
            CommentManager.Instance.Event_Flg = true;
            _EventNum++;
            Invoke("HintCome", Random.Range(1, 2));
            timeElapsed = 0.0f; // カウントリセット
        }
        // 一定間隔でイベントコメントを生成
        if(timeElapsed >= timeOut)
        {
            if(_EventNum-1 == 0 || _EventNum-1 == 1 ||
               _EventNum-1 == 3 || _EventNum-1 == 10 ||
               (_EventNum-1 == 7 && FlagManager.Instance.Eventroop)||
               (_EventNum-1 == 9 && FlagManager.Instance.Eventroop)) HintCome();
            timeElapsed = 0.0f; // カウントリセット
        }

        // 敵のコメントを0～順に生成させている
        if (FlagManager.Instance.Co_Enemy[_EnemyNum])
        {
            //Invoke("EnemyflgCome", 1);
            _EnemyNum++;
            EnemyflgCome();
        }
    }

    /*--------------------------------------------------------------------------------*/

    void HintCome()
    {
        ComeObj.GetComponent<nico>().AddComment_Hint(_EventNum-1, _EventComeNum);

        if (CommentManager.Instance.Event[_EventNum-1].E_Comment[_EventComeNum+1] != null)
        {
            switch (_EventNum-1)
            {
                case 4:// 地下に落ちたタイミング
                case 6:// 資料室でのイベント中
                case 8:// 手術室に入ったら 
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
            //once_esc = false;
            _EventComeNum = 0;
            Invoke("addcomment", Random.Range(2, 4));
        }
        _EventComeNum++;
        
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
