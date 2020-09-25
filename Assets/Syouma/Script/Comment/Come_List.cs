using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Come_List : MonoBehaviour
{
    [SerializeField] List<string> Sayhello = new List<string>(); // あいさつ系のコメント一覧
    [SerializeField] List<string> Reaction = new List<string>(); // リアクション系のコメント一覧
    [SerializeField] List<string> Hint = new List<string>();     // ヒント系のコメント一覧 


    //[System.NonSerialized] public string Comment;// 次に表示するコメントを入れる変数

    void Start()
    {
        // 各リストの要素数を記憶
        int Count1 = Sayhello.Count;
        int Count2 = Reaction.Count;
        int Count3 = Hint.Count;

        // あいさつ系を入力
        this.GetComponent<Text>().text += Sayhello[Random.Range(0, Count1)]; 

    }

    void Update()
    {
        
    }
}
