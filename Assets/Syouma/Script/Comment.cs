using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 秒間でコメント表示
// オンオフのフラグを作る

public class Comment : MonoBehaviour
{
    private Text targetText;

    void Start()
    {
        this.targetText = this.GetComponent<Text>();
        InvokeRepeating("AddComment", 1, 3); // 1秒後に3秒間隔でコメント追加する
    }

    void Update()
    {
        
        
    }

    void AddComment()
    {
        // ここにフラグを追加する
        this.targetText.text += "\nChangeText"; // コメント追加
    }
}
