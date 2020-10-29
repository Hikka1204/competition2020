using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* **************************
 * ・
 * ・コメントが上に流れる処理
 * ・コメントのON/Off処理
 ***************************/

public class Come_Generate : MonoBehaviour
{
    public GameObject canvas;//キャンバス
    public GameObject TextPrefab; // テキストプレファブをいれる変数
    private List<GameObject> TextList = new List<GameObject>(); // 今出ているコメント

    public float startPosition;//上の移動限界値
    public float endPosition;//下の移動限界値
    [SerializeField] private float OnOffSpeed;//表示.非表示の移動速度
    [SerializeField] private float MoveSpeed;//コメントが流れる速度

    RectTransform window;//UIの座標変更
    bool MoveDecision = true;//今のウィンドウがどこにあるかの判定　trueなら上
    float nowPosition;//現在のウィンドウ座標

    int ComNum = 0; // 今出ているコメントの数
    int Delcnt = 0; // 削除したコメントの数
    int MoveCnt = 0;  // コメントを動かすためのカウント

    const float x = 5f; // 次のコメントの出現座標
    const float y = 17f;

    bool Move_flg = false;
    bool OnOff_flg = false;

    GameObject Player;
    Come_Flg comeflg;

    void Start()
    {
        Player = GameObject.Find("FPSController");
        comeflg = Player.GetComponent<Come_Flg>();
        TextList.Clear(); //Listの初期化
        //InvokeRepeating("AddComment", 1, 3); // 1秒後に3秒間隔でコメント追加する
        Invoke("AddComment", 1); // 1秒後にコメント追加する
        window = canvas.GetComponent<RectTransform>();//取得
    }

    void Update()
    {
        //Debug.Log(Move_flg);
        nowPosition = window.transform.position.y;//現在座標の取得

        // Cキーを押してコメントの表示/非表示の切り替え
        if (Input.GetKeyDown(KeyCode.C)) OnOff_flg = !OnOff_flg;

        if (MoveDecision && OnOff_flg) OnMove();        // 非表示の処理
        else if(!MoveDecision && !OnOff_flg) OffMove(); // 表示の処理
                    

        // 次のコメントが決まったら動く処理をする
        if (Move_flg)
        {
            for(int i= Delcnt; i< ComNum; i++)
                TextList[i].transform.position += new Vector3(0f, MoveSpeed, 0f);
            
            MoveCnt += 1;
            if (MoveCnt == 40)// MoveCnt(60) = MoveSpeed(0.5)
            {
                Move_flg = false;
                MoveCnt = 0;
            }
        }
    }


    /*** コメントを追加する処理 ***/
    public void AddComment()
    {
        if (!comeflg.EscapeFlg){
            if (!Move_flg)
            {
                Move_flg = true;
                TextList.Add((GameObject)Instantiate(TextPrefab));
                TextList[ComNum].transform.position = new Vector3(x, y - 24f, 0f);
                TextList[ComNum].transform.SetParent(canvas.transform, false);
                //TextList[ComNum].GetComponent<Come_List>().RandomComment();
                TextList[ComNum].gameObject.GetComponentInChildren<Come_List>().RandomComment();

                ComNum ++;
                if (ComNum > 6) DeleteComment();
            }
            Invoke("AddComment", Random.Range(3, 7));
        }
    }

    public void AddComment_Reaction()
    {
        if (!Move_flg)
        {
            Move_flg = true;
            TextList.Add((GameObject)Instantiate(TextPrefab));
            TextList[ComNum].transform.position = new Vector3(x, y - 24f, 0f);
            TextList[ComNum].transform.SetParent(canvas.transform, false);
            TextList[ComNum].GetComponent<Come_List>().ReactionCommnet();

            ComNum++;
            if (ComNum > 6) DeleteComment();
        }
    }

    public void AddComment_Escape()
    {
        if (!Move_flg)
        {
            Move_flg = true;
            TextList.Add((GameObject)Instantiate(TextPrefab));
            TextList[ComNum].transform.position = new Vector3(x, y - 24f, 0f);
            TextList[ComNum].transform.SetParent(canvas.transform, false);
            TextList[ComNum].GetComponent<Come_List>().EscapeCommnet();

            ComNum++;
            if (ComNum > 6) DeleteComment();
        }
    }

    public void AddComment_Hint(int index)
    {
        if (!Move_flg)
        {
            Move_flg = true;
            TextList.Add((GameObject)Instantiate(TextPrefab));
            TextList[ComNum].transform.position = new Vector3(x, y - 24f, 0f);
            TextList[ComNum].transform.SetParent(canvas.transform, false);
            TextList[ComNum].GetComponent<Come_List>().HintCommnet(index);

            ComNum++;
            if (ComNum > 6) DeleteComment();
        }
    }

    /*** コメントを消す処理 ***/
    void DeleteComment() 
    {
        Destroy(TextList[Delcnt]);
        Delcnt += 1;
    }


    /*** コメントを表示する処理 ***/
    void OnMove()
    {
        if (nowPosition > startPosition)//この座標になるまで
            window.transform.position -= new Vector3(0, OnOffSpeed, 0);//下に移動する
        
        else if (nowPosition <= startPosition)//制限より移動したら
            MoveDecision = false;//下についたと知らせる
    }

    /*** コメントを非表示する処理 ***/
    void OffMove()
    {
        if (nowPosition < endPosition)//この座標になるまで
            window.transform.position += new Vector3(0, OnOffSpeed, 0);//上に移動する
        
        else if (nowPosition >= endPosition)//制限より移動したら
            MoveDecision = true;//上についたと知らせる
    }
}
