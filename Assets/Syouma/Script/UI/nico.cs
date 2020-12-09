using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nico : MonoBehaviour
{
    public GameObject TextPrefab; // テキストプレファブをいれる変数
    private List<GameObject> TextList = new List<GameObject>(); // 今出ているコメント

    int ComNum = 0; // 今出ているコメントの数
    int Delcnt = 0; // 削除したコメントの数
    const int COMEMAX = 10; // 画面に表示せる最大コメント数

    // コメントの出現座標
    const float x =　0f;
    float y;
    const float Step0 = 0f; // 各階層のY座標
    const float Step1 = -30f;
    const float Step2 = -60f;
    const float Step3 = -90f;
    bool[] StepShift; 

    void Start()
    {
        TextList.Clear(); //Listの初期化
        StepShift = new bool[4];
        Invoke("AddComment", 1); // 1秒後にコメント追加する
    }

    void Update()
    {

    }

    /*** 通常コメントを追加する処理 ***/
    public void AddComment()
    {
        if (!CommentManager.Instance.Escape_Flg && !CommentManager.Instance.Event_Flg)
        {
            Generate();
            //TextList[ComNum].GetComponent<Come_List>().RandomComment();
            TextList[ComNum].gameObject.GetComponentInChildren<Come_List>().Comment();
            ComNum++;
            if (ComNum > COMEMAX) DeleteComment();

            Invoke("AddComment", Random.Range(1, 6));
            //Invoke("AddComment", 1); /*デバッグ用*/
        }
    }

    /*** 逃げている間のコメントを追加する処理 ***/
    public void AddComment_Escape()
    {
        Generate();
        TextList[ComNum].gameObject.GetComponentInChildren<Come_List>().EscapeCommnet();

        ComNum++;
        if (ComNum > COMEMAX) DeleteComment();
    }

    /*** イベント時の特定コメントを追加する処理 ***/
    public void AddComment_Hint(int index,int _index)
    {
        Generate();
        TextList[ComNum].gameObject.GetComponentInChildren<Come_List>().HintCommnet(index, _index);

        ComNum++;
        if (ComNum > COMEMAX) DeleteComment();
    }

    /*** 敵のコメントを追加する処理 ***/
    public void AddComment_Enemy(int index)
    {
        Generate();
        TextList[ComNum].gameObject.GetComponentInChildren<Come_List>().EnemyComment(index);

        ComNum++;
        if (ComNum > COMEMAX) DeleteComment();
    }


    void Generate()
    {
        TextList.Add((GameObject)Instantiate(TextPrefab));
        if (!StepShift[0]) {
            y = Step0;
            StepShift[0] = true;
            Invoke("Step0Reset", Random.Range(3, 4));
        }
        else if (!StepShift[1]) {
            y = Step1;
            StepShift[1] = true;
            Invoke("Step1Reset", Random.Range(2, 3));
        }
        else if (!StepShift[2]) {
            y = Step2;
            StepShift[2] = true;
            Invoke("Step2Reset", 2);
        }
        else if (!StepShift[3]) {
            y = Step3;
            StepShift[3] = true;
            Invoke("Step3Reset", 1);
        }

        TextList[ComNum].transform.position = new Vector3(x, y, 0f);
        TextList[ComNum].transform.SetParent(this.transform, false);
    }



    /*** コメントを消す処理 ***/
    void DeleteComment()
    {
        Destroy(TextList[Delcnt]);
        Delcnt += 1;
    }

    void Step0Reset()
    {
        StepShift[0] = false;
    }
    void Step1Reset()
    {
        StepShift[1] = false;
    }
    void Step2Reset()
    {
        StepShift[2] = false;
    }
    void Step3Reset()
    {
        StepShift[3] = false;
    }
}
