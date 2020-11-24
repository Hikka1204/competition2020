using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nico : MonoBehaviour
{
    public GameObject TextPrefab; // テキストプレファブをいれる変数
    private List<GameObject> TextList = new List<GameObject>(); // 今出ているコメント

    int ComNum = 0; // 今出ているコメントの数
    int Delcnt = 0; // 削除したコメントの数

    // コメントの出現座標
    const float x = 770f;
    float y;
    const float Step0 = 510f; // 各階層のY座標
    const float Step1 = 480f;
    const float Step2 = 450f;
    const float Step3 = 420f;
    bool[] StepShift; 


    void Start()
    {
        TextList.Clear(); //Listの初期化
        StepShift = new bool[4];
        Invoke("AddComment", 1); // 1秒後にコメント追加する
    }

    void Update()
    {
        if (StepShift[0]) Invoke("Step0Reset", 2);
        if (StepShift[1]) Invoke("Step1Reset", 1);
        if (StepShift[2]) Invoke("Step2Reset", 2);
        if (StepShift[3]) Invoke("Step3Reset", 3);

    }

    /*** コメントを追加する処理 ***/
    public void AddComment()
    {
        if (!CommentManager.Instance.Escape_Flg)
        {
            Generate();
            //TextList[ComNum].GetComponent<Come_List>().RandomComment();
            TextList[ComNum].gameObject.GetComponentInChildren<Come_List>();
            ComNum++;
            if (ComNum > 10) DeleteComment();

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
        if (ComNum > 6) DeleteComment();

    }

    void Generate()
    {
        TextList.Add((GameObject)Instantiate(TextPrefab));
        if (!StepShift[0]) { y = Step0; StepShift[0] = true; }
        else if (!StepShift[1]) { y = Step1; StepShift[1] = true; }
        else if (!StepShift[2]) { y = Step2; StepShift[2] = true; }
        else if (!StepShift[3]) { y = Step3; StepShift[3] = true; }

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
