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

    public bool[] SerifFlg = new bool[30]; // プレイヤーのセリフフラグ
    public bool[] Co_Event = new bool[11];       // イベント系のコメントフラグ
    public bool[] Co_Enemy = new bool[11];       // 敵のコメンフラグ
    public bool[] Key_Text = new bool[30];       // ヒント系のコメント一覧 
    public int Status = 0;  // [0=序盤,1=中盤,2=終盤]


    [ContextMenu("ResetFlags")]
	public void ResetFlags()
	{
        SerifFlg = new bool[SerifFlg.Length];
        Key_Text = new bool[Key_Text.Length];
        //Co_Name = new string[Co_Name.Length];
        //Co_Talk = new string[Co_Talk.Length];
        //Co_Reaction = new string[Co_Reaction.Length];
        //Co_Escape = new string[Co_Escape.Length];
        //Co_Hint = new string[Co_Hint.Length];
    }
}