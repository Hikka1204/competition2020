using UnityEngine;
using System.Collections;

public class FlagManager : MonoBehaviour
{
	private static FlagManager instance = null;
	public static FlagManager Instance 
	{
		get{
			if( instance == null){
				instance = FindObjectOfType<FlagManager>();

				if( instance == null )
				{
					instance = new GameObject("FlagManager").AddComponent<FlagManager>();
				}
			}
			return instance;
		}
	}

	void Awake()
	{
		if( Instance == this )
		{
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy (gameObject);
		}
	}

    public bool[] flags = new bool[30]; // プレイヤーのセリフフラグ
    //public string[] Co_Name = new string[10];   // コメントしてる人の名前一覧
    //public string[] Co_Talk = new string[30];       // 会話系のコメント一覧
    //public string[] Co_Reaction = new string[10];   // リアクション系のコメント一覧
    //public string[] Co_Escape = new string[10];     // 追いかけられている時のコメント一覧 
    //public string[] Co_Hint = new string[30];       // ヒント系のコメント一覧 

    [ContextMenu("ResetFlags")]
	public void ResetFlags()
	{
		flags = new bool[flags.Length];
        //Co_Name = new string[Co_Name.Length];
        //Co_Talk = new string[Co_Talk.Length];
        //Co_Reaction = new string[Co_Reaction.Length];
        //Co_Escape = new string[Co_Escape.Length];
        //Co_Hint = new string[Co_Hint.Length];
	}
}