using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Come_List : MonoBehaviour
{
    [SerializeField] List<string> Name = new List<string>(); // コメントしてる人の名前リスト

    [SerializeField] List<string> Talk = new List<string>(); // あいさつ系のコメント一覧
    public List<string> Reaction = new List<string>(); // リアクション系のコメント一覧
    public List<string> Escape = new List<string>();   // 追いかけられている時のコメント一覧 
    public List<string> Hint = new List<string>();     // ヒント系のコメント一覧 


    //[System.NonSerialized] public string Comment;// 次に表示するコメントを入れる変数

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void RandomComment()
    {
        // コメントした人の名前をランダムで入力
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        // あいさつ系を入力
        this.GetComponent<Text>().text += Talk[Random.Range(0, Talk.Count)];
    }

    /*** リアクション系の生成 ***/
    public void ReactionCommnet(int index)
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Reaction[index];
    }

    /*** 逃げる系の生成 ***/
    public void EscapeCommnet(int index)
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Escape[index];
    }

    /*** ヒント系の生成 ***/
    public void HintCommnet(int index)
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Hint[index];
    }


}
