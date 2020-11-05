using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Come_List : MonoBehaviour
{
    const float WaitTime = 3f; // セリフの表示時間

    [SerializeField] List<string> Name = new List<string>(); // コメントしてる人の名前リスト

    [SerializeField] List<string> Talk = new List<string>(); // あいさつ系のコメント一覧
    public List<string> Reaction = new List<string>(); // リアクション系のコメント一覧
    public List<string> Escape = new List<string>();   // 追いかけられている時のコメント一覧 
    public List<string> Hint = new List<string>();     // ヒント系のコメント一覧 

    //public int[][] aiu = new int[10][];

    struct ComeData{
        public string Name;
        public string[] Comment;
    }
    [System.NonSerialized] ComeData[] Audience;
    //ComeData[] Audience = new ComeData[10];

    void Start()
    {
        Audience[0].Name = "かおり";
            Audience[0].Comment[0] = "怖くないの？";
            Audience[0].Comment[1] = "初見です。";
            Audience[0].Comment[2] = "気を付けてください";
            Audience[0].Comment[3] = "チャンネル登録しました";
            Audience[0].Comment[4] = "無理しないでくださいね";
    }

    void Update()
    {

    }



    //public void RandomComment()
    //{
    //    // コメントした人の名前をランダムで入力
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    // あいさつ系を入力
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Talk[Random.Range(0, CommentManager.Instance.Co_Talk.Length)];
    //}

    ///*** リアクション系の生成 ***/
    //public void ReactionCommnet(int index)
    //{
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Reaction[index];
    //}

    ///*** 逃げる系の生成 ***/
    //public void EscapeCommnet(int index)
    //{
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Escape[index];
    //}

    ///*** ヒント系の生成 ***/
    //public void HintCommnet(int index)
    //{
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Hint[index];
    //}

    public void RandomComment()
    {
        // コメントした人の名前をランダムで入力
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        // あいさつ系を入力
        this.GetComponent<Text>().text += Talk[Random.Range(0, Talk.Count)];
    }

    /*** リアクション系の生成 ***/
    public void ReactionCommnet()
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Reaction[Random.Range(0, Reaction.Count)];
    }

    /*** 逃げる系の生成 ***/
    public void EscapeCommnet()
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Escape[Random.Range(0, Escape.Count)];
    }

    /*** ヒント系の生成 ***/
    public void HintCommnet(int index)
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Hint[index];
    }


}
