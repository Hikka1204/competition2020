using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Come_Generate : MonoBehaviour
{
    public GameObject canvas;//キャンバス
    public GameObject TextPrefab; // テキストプレファブをいれる変数
    private List<GameObject> TextList = new List<GameObject>(); // 今出ているコメント
    RectTransform[] rect;

    int ComNum = 0; // 今出ているコメントの数
    int Delcnt = 0; // 削除したコメントの数
    int MoveCnt = 0;  // コメントを動かすためのカウント
    int ccc = 0;

    const float x = 5f; // 次のコメントの出現座標
    const float y = 17f;

    bool Move_flg = false;

    void Start()
    {
        TextList.Clear(); //Listの初期化
        InvokeRepeating("AddComment", 1, 3); // 1秒後に3秒間隔でコメント追加する
        
    }

    void Update()
    {
        //Debug.Log(Move_flg);
        //Debug.Log(ComNum);

        // 次のコメントが決まったら動く処理をする
        if (Move_flg)
        {
            for(int i= Delcnt; i< ComNum; i++)
                TextList[i].transform.position += new Vector3(0f, 0.5f, 0f);
            
            MoveCnt += 1;
            if (MoveCnt == 60)
            {
                Move_flg = false;
                MoveCnt = 0;
            }
        }
    }


    /*** コメントを追加する処理 ***/
    void AddComment()
    {
        Move_flg = true;
        TextList.Add((GameObject)Instantiate(TextPrefab));
        TextList[ComNum].transform.position = new Vector3(x, y-24f, 0f);
        TextList[ComNum].transform.SetParent(canvas.transform, false);

         ComNum += 1;
        //if(ccc != 6) ccc += 1;
        if (ComNum > 6) DeleteComment();
    }

    /*** コメントを消す処理 ***/
    void DeleteComment() 
    {
        Destroy(TextList[Delcnt]);
        //ComNum = 0;
        Delcnt += 1;
        //if (Delcnt != 5) Delcnt += 1;
        //else Delcnt = 0;
    }
}
