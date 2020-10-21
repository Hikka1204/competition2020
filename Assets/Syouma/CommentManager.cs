using UnityEngine;
using System.Collections;

public class CommentManager : MonoBehaviour
{
    private static CommentManager instance = null;
    public static CommentManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CommentManager>();

                if (instance == null)
                {
                    instance = new GameObject("CommentManager").AddComponent<CommentManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string[] Co_Name = new string[10];   // コメントしてる人の名前一覧
    public string[] Co_Talk = new string[30];       // 会話系のコメント一覧
    public string[] Co_Reaction = new string[10];   // リアクション系のコメント一覧
    public string[] Co_Escape = new string[10];     // 追いかけられている時のコメント一覧 
    public string[] Co_Hint = new string[30];       // ヒント系のコメント一覧 

    [ContextMenu("ResetFlags")]
    public void ResetFlags()
    {
        Co_Name = new string[Co_Name.Length];
        Co_Talk = new string[Co_Talk.Length];
        Co_Reaction = new string[Co_Reaction.Length];
        Co_Escape = new string[Co_Escape.Length];
        Co_Hint = new string[Co_Hint.Length];
    }
}