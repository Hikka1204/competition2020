using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Come_List : MonoBehaviour
{
    [SerializeField] List<string> Sayhello = new List<string>(); // あいさつ系のコメント一覧
    [SerializeField] List<string> Reaction = new List<string>(); // リアクション系のコメント一覧
    [SerializeField] List<string> Hint = new List<string>();     // ヒント系のコメント一覧 

    void Start()
    {
        this.GetComponent<Text>().text += Sayhello[Random.Range(0, 3)]; // コメント追加
    }

    void Update()
    {
        
    }
}
