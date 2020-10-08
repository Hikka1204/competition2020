using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Come_List : MonoBehaviour
{
    [SerializeField] List<string> Name = new List<string>(); // コメントしてる人の名前リスト

    [SerializeField] List<string> Sayhello = new List<string>(); // あいさつ系のコメント一覧
    [SerializeField] List<string> Reaction = new List<string>(); // リアクション系のコメント一覧
    [SerializeField] List<string> Escape = new List<string>();     // 追いかけられている時のコメント一覧 
    [SerializeField] List<string> Hint = new List<string>();     // ヒント系のコメント一覧 


    //[System.NonSerialized] public string Comment;// 次に表示するコメントを入れる変数

    void Start()
    {
        // 各リストの要素数を記憶
        //int Name_cnt = Name.Count;
        //int Say_cnt = Sayhello.Count;
        //int Rea_cnt = Reaction.Count;
        //int Esc_cnt = Escape.Count;
        //int Hint_cnt = Hint.Count;

        // コメントした人の名前をランダムで入力
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        // あいさつ系を入力
        this.GetComponent<Text>().text += Sayhello[Random.Range(0, Sayhello.Count)]; 

    }

    void Update()
    {
        
    }
}
