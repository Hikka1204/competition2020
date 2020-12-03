using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Come_List : MonoBehaviour

{   
    int Status = 0; // [0=序盤,1=中盤,2=終盤]
    int NameNum; // 名前用　要素数格納変数
    int ComeNum; // コメント用　要素数格納変数
    string Check = null; // 作ったコメントをチェックために入れる変数

    //CommentManager C_manager;

    void Start()
    {
        if (!CommentManager.Instance.Escape_Flg && !CommentManager.Instance.Event_Flg)
        {
            // CommentManagerの変数を使えるようにしている
            //C_manager = GameObject.FindGameObjectWithTag("CommentManager").GetComponent<CommentManager>();
            // コメントする人をランダムで決める
            NameNum = Random.Range(0, CommentManager.Instance.Audience.Length);

            // コメントの内容を入力
            switch (Status)
            {
                case 0:// 序盤
                    do
                    {
                        // 序盤のコメントがない人だと人を変える
                        if (CommentManager.Instance.Audience[NameNum].Comment_1[0] == "") NameNum = 14;
                        do
                        {
                            ComeNum = Random.Range(0, CommentManager.Instance.Audience[NameNum].Comment_1.Length);
                        } while (CommentManager.Instance.Audience[NameNum].Comment_1[ComeNum] == null);
                        Check = CommentManager.Instance.Audience[NameNum].Name + CommentManager.Instance.Audience[NameNum].Comment_1[ComeNum];
                    }
                    while (Check == CommentManager.Instance.Previous); // ひとつ前のコメントと同じが調べている

                    this.GetComponent<Text>().text += CommentManager.Instance.Audience[NameNum].Name + CommentManager.Instance.Audience[NameNum].Comment_1[ComeNum];
                    CommentManager.Instance.Previous = this.GetComponent<Text>().text;
                    break;
                case 1:// 中盤
                    this.GetComponent<Text>().text += CommentManager.Instance.Audience[NameNum].Comment_2[Random.Range(0, CommentManager.Instance.Audience[NameNum].Comment_2.Length)];
                    break;
                case 2:// 終盤
                    this.GetComponent<Text>().text += CommentManager.Instance.Audience[NameNum].Comment_3[Random.Range(0, CommentManager.Instance.Audience[NameNum].Comment_3.Length)];
                    break;
            }
        }
    }

    /*** 逃げる系の生成 ***/
    public void EscapeCommnet()
    {
        do
        {
            Check = CommentManager.Instance.Escape[Random.Range(0, CommentManager.Instance.Escape.Length)];
        } while (Check == CommentManager.Instance.Previous); // ひとつ前のコメントと同じが調べている
        this.GetComponent<Text>().text = CommentManager.Instance.Escape[Random.Range(0, CommentManager.Instance.Escape.Length)];
    }

    /*** ヒント系の生成 ***/
    public void HintCommnet(int index, int _index)
    {
        this.GetComponent<Text>().text = CommentManager.Instance.Event[index].E_Comment[_index];
    }

    void Update()
    {

    }

    

    //public void RandomComment()
    //{

    //    // コメントする人をランダムで決める
    //    int i = Random.Range(0, Audience.Length);
    //    int j;

    //    // コメントした人の名前入力
    //    this.GetComponent<Text>().text += Audience[i].Name;
    //    // コメントの内容を入力
    //    switch (Status)
    //    {
    //        case 0:// 序盤
    //            do
    //            {
    //                // 序盤のコメントがない人だと人を変える
    //                while (Audience[i].Comment_1[0] == null)
    //                    i = Random.Range(0, Audience.Length);
    //                do
    //                {
    //                    j = Random.Range(0, Audience[i].Comment_1.Length);
    //                } while (Audience[i].Comment_1[j] == null);
    //                Debug.Log("koko");
    //            } while (Check == (Audience[i].Name + Audience[i].Comment_1[j])); // ひとつ前のコメントと同じが調べている
    //            this.GetComponent<Text>().text += Audience[i].Comment_1[j];
    //            Check = this.GetComponent<Text>().text;
    //            EndFlg = true;
    //            break;
    //        case 1:// 中盤
    //            this.GetComponent<Text>().text += Audience[i].Comment_2[Random.Range(0, Audience[i].Comment_2.Length)];
    //            break;
    //        case 2:// 終盤
    //            this.GetComponent<Text>().text += Audience[i].Comment_3[Random.Range(0, Audience[i].Comment_3.Length)];
    //            break;
    //    }

    //}
    //    //// コメントした人の名前をランダムで入力
    //    //this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
    //    //// あいさつ系を入力
    //    //this.GetComponent<Text>().text += Talk[Random.Range(0, Talk.Count)];
    //}

    ///*** リアクション系の生成 ***/
    //public void ReactionCommnet()
    //{
    //    this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
    //    this.GetComponent<Text>().text += Reaction[Random.Range(0, Reaction.Count)];
    //}






}
