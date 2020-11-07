using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Come_List : MonoBehaviour
{
    [SerializeField] List<string> Name = new List<string>(); // コメントしてる人の名前リスト

    [SerializeField] List<string> Talk = new List<string>(); // あいさつ系のコメント一覧
    public List<string> Reaction = new List<string>(); // リアクション系のコメント一覧
    public List<string> Escape = new List<string>();   // 追いかけられている時のコメント一覧 
    public List<string> Hint = new List<string>();     // ヒント系のコメント一覧 

    struct ComeData
    {
        public string Name;
        public string[] Comment_1; // 序盤
        public string[] Comment_2; // 中盤
        public string[] Comment_3; // 終盤
    }
    ComeData[] Audience = new ComeData[10];
    bool First_flg = false;

    int Status = 0;

    void Start()
    {


    }

    void Update()
    {

    }



    //public void RandomComment()
    //{
    //    // コメントした人の名前をランダムで入力
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    // あいさつ系を入力
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Talk[Random.Range(0, CommentManager.Instance.Co_Talk.Length)];
    //}

    ///*** リアクション系の生成 ***/
    //public void ReactionCommnet(int index)
    //{
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Reaction[index];
    //}

    ///*** 逃げる系の生成 ***/
    //public void EscapeCommnet(int index)
    //{
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Escape[index];
    //}

    ///*** ヒント系の生成 ***/
    //public void HintCommnet(int index)
    //{
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Name[Random.Range(0, CommentManager.Instance.Co_Name.Length)];
    //    this.GetComponent<Text>().text += CommentManager.Instance.Co_Hint[index];
    //}
    void CommentSet()
    {
        for (int i = 0; i < Audience.Length; i++)
        {
            Audience[i].Comment_1 = new string[5];
            Audience[i].Comment_2 = new string[5];
            Audience[i].Comment_3 = new string[5];
        }

        Debug.Log("aaaaaa");
        Audience[0].Name = "かおり：";
        Audience[0].Comment_1[0] = "怖くないの？";
        Audience[0].Comment_1[1] = "初見です。";
        Audience[0].Comment_1[2] = "気を付けてください";
        Audience[0].Comment_1[3] = "チャンネル登録しました";
        Audience[0].Comment_1[4] = "無理しないでくださいね";
        Audience[0].Comment_2[0] = "写ってるじゃん。";
        Audience[0].Comment_2[1] = "大丈夫?";
        Audience[0].Comment_2[2] = "気を付けてー";
        Audience[0].Comment_3[0] = "怖くないの?";
        Audience[0].Comment_3[1] = "もう無理、怖すぎ…。";
        Audience[0].Comment_3[2] = "がんばれー";
        Audience[0].Comment_3[3] = "これやばいよ。";

        Audience[1].Name = "ちょんまげ男：";
        Audience[1].Comment_1[0] = "体張りすぎｗ？";
        Audience[1].Comment_1[1] = "期待。";
        Audience[1].Comment_1[2] = "ここどこ??";
        Audience[1].Comment_1[3] = "やばいな";
        Audience[1].Comment_2[0] = "死ぬなよ～";
        Audience[1].Comment_2[1] = "神回!!";
        Audience[1].Comment_2[2] = "もっといけー";
        Audience[1].Comment_2[3] = "止まんなーｗ";
        Audience[1].Comment_2[4] = "やべぇｗｗ";
        Audience[1].Comment_3[0] = "俺も行こうかな…助けにｗ";
        Audience[1].Comment_3[1] = "絶対死ぬ奴コレ";
        Audience[1].Comment_3[2] = "登録したから生きて帰ってこいよ";
        Audience[1].Comment_3[3] = "死ぬなよ～";

        Audience[2].Name = "卵かけライス：";
        Audience[2].Comment_1[0] = "言っとく、ここはやめとけ";
        Audience[2].Comment_1[1] = "気を付けて";
        Audience[2].Comment_1[2] = "ひとり?";
        Audience[2].Comment_1[3] = "見守ってます";
        Audience[2].Comment_2[0] = "気を付けて";
        Audience[2].Comment_2[1] = "気、抜かないで";
        Audience[2].Comment_2[2] = "周りよく見て";
        Audience[2].Comment_2[3] = "死ぬな";
        Audience[2].Comment_3[0] = "チャンネル登録したから無事に帰ってこい";
        Audience[2].Comment_3[1] = "頑張れ！";
        Audience[2].Comment_3[2] = "死ぬな";
        Audience[2].Comment_3[3] = "周りをよく見て";

        Audience[3].Name = "みさき：";
        Audience[3].Comment_1[0] = "こんばんは～";
        Audience[3].Comment_1[1] = "ここどこ??";
        Audience[3].Comment_1[2] = "ひとり?";
        Audience[3].Comment_1[3] = "やばぁｗ";
        Audience[3].Comment_1[4] = "じわるｗ";
        Audience[3].Comment_2[0] = "気を付けてー";
        Audience[3].Comment_2[1] = "神回！";
        Audience[3].Comment_2[2] = "こわぁ…";
        Audience[3].Comment_2[3] = "チャンネル登録したー";
        Audience[3].Comment_3[0] = "無理、怖すぎ…";
        Audience[3].Comment_3[1] = "死ぬな―！";
        Audience[3].Comment_3[2] = "がんばってー";
        Audience[3].Comment_3[3] = "みつからないでー";

        Audience[4].Name = "りんご星人：";
        Audience[4].Comment_1[0] = "初見です";
        Audience[4].Comment_1[1] = "こんばんわ";
        Audience[4].Comment_1[2] = "雰囲気あるね";
        Audience[4].Comment_1[3] = "ほんとに何か出るのかな";
        Audience[4].Comment_2[0] = "気を付けて";
        Audience[4].Comment_2[1] = "大丈夫？";
        Audience[4].Comment_2[2] = "どうすか？雰囲気は";
        Audience[4].Comment_2[3] = "なんか気持ち悪いなここ";
        Audience[4].Comment_3[0] = "やばいやばい";
        Audience[4].Comment_3[1] = "見つからないように";
        Audience[4].Comment_3[2] = "どうなるんだよこれ";

        Audience[5].Name = "みかママ：";
        Audience[5].Comment_1[0] = "こんばんわ";
        Audience[5].Comment_1[1] = "ここはどこですか？";
        Audience[5].Comment_1[2] = "怖い雰囲気でてるね";
        Audience[5].Comment_1[3] = "暗いね";
        Audience[5].Comment_2[0] = "気を付けてください";
        Audience[5].Comment_2[1] = "チャンネル登録したよー";
        Audience[5].Comment_2[2] = "怖いね…";
        Audience[5].Comment_2[3] = "今日は冷えるので体に気つけてください";
        Audience[5].Comment_3[0] = "やばい、怖すぎる―";
        Audience[5].Comment_3[1] = "早く出よう！";
        Audience[5].Comment_3[2] = "もう無理、見れない";

        Audience[6].Name = "あげパン：";
        Audience[6].Comment_1[0] = "こんばんわ";
        Audience[6].Comment_1[1] = "一人ですか？";
        Audience[6].Comment_1[2] = "雰囲気やばいですね";
        Audience[6].Comment_2[0] = "ここやばいね";
        Audience[6].Comment_2[1] = "怖すぎ";
        Audience[6].Comment_2[2] = "無理はしないでください";
        Audience[6].Comment_3[0] = "やばいよここ、どうなってんの？";
        Audience[6].Comment_3[1] = "警察呼んだら？";
        Audience[6].Comment_3[2] = "早く出ましょう";

        Audience[7].Name = "アレン：";
        Audience[7].Comment_1[0] = null;
        Audience[7].Comment_2[0] = "こんばんわ";
        Audience[7].Comment_2[1] = "今来ました";
        Audience[7].Comment_2[2] = "何してるんですか";
        Audience[7].Comment_2[3] = "こわっ";
        Audience[7].Comment_3[0] = "もう寝れない";
        Audience[7].Comment_3[1] = "怖いよ";
        Audience[7].Comment_3[2] = "今部屋で音がした気がする";
        Audience[7].Comment_3[3] = "やばい怖い";

        Audience[8].Name = "さちこ：";
        Audience[8].Comment_1[0] = "こんばんは";
        Audience[8].Comment_1[1] = "初めて見ます";
        Audience[8].Comment_1[2] = "なんだか怖そうですね";
        Audience[8].Comment_1[3] = "ここはどこなんですか？";
        Audience[8].Comment_2[0] = "怖すぎますねここ";
        Audience[8].Comment_2[1] = "ひとりですか？";
        Audience[8].Comment_2[2] = "頑張ってください";
        Audience[8].Comment_3[0] = null;

        Audience[9].Name = "きな粉：";
        Audience[9].Comment_1[0] = "こんばんは";
        Audience[9].Comment_1[1] = "初見です";
        Audience[9].Comment_1[2] = "何してるんですか";
        Audience[9].Comment_1[3] = "心霊スポットは怖過ぎて行けない…";
        Audience[9].Comment_2[0] = "やばいですねここ";
        Audience[9].Comment_2[1] = "気を付けて進んでください";
        Audience[9].Comment_2[2] = "死なないでー";
        Audience[9].Comment_3[0] = "うわぁ…";
        Audience[9].Comment_3[1] = "怖すぎ…";
        Audience[9].Comment_3[2] = "大丈夫ですか?";
        Audience[9].Comment_3[3] = "こんなとこ早く出ましょう。";

    }

    public void RandomComment()
    {
        if (!First_flg)
        {
            First_flg = true;
            CommentSet();
        }
        
        // コメントする人をランダムで決める
        int i = Random.Range(0, Audience.Length);
        int j;
        string Check = null;

        // コメントした人の名前入力
        this.GetComponent<Text>().text += Audience[i].Name;
        // コメントの内容を入力
        switch (Status)
        {
            case 0:// 序盤
                    // 序盤のコメントがない人だと人を変える
                while (Audience[i].Comment_1[0] == null)
                        i = Random.Range(0, Audience.Length);
                    
                do
                {
                    j = Random.Range(0, Audience[i].Comment_1.Length);
                } while (Check == Audience[i].Name + Audience[i].Comment_1[j]);
                // ひとつ前のコメントと同じが調べている

                this.GetComponent<Text>().text += Audience[i].Comment_1[j];
                Check = this.GetComponent<Text>().text;
                break;
            case 1:// 中盤
                this.GetComponent<Text>().text += Audience[i].Comment_2[Random.Range(0, Audience[i].Comment_2.Length)];
                break;
            case 2:// 終盤
                this.GetComponent<Text>().text += Audience[i].Comment_3[Random.Range(0, Audience[i].Comment_3.Length)];
                break;
        }


        //// コメントした人の名前をランダムで入力
        //this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        //// あいさつ系を入力
        //this.GetComponent<Text>().text += Talk[Random.Range(0, Talk.Count)];
    }

    /*** リアクション系の生成 ***/
    public void ReactionCommnet()
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Reaction[Random.Range(0, Reaction.Count)];
    }

    /*** 逃げる系の生成 ***/
    public void EscapeCommnet()
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Escape[Random.Range(0, Escape.Count)];
    }

    /*** ヒント系の生成 ***/
    public void HintCommnet(int index)
    {
        this.GetComponent<Text>().text += Name[Random.Range(0, Name.Count)];
        this.GetComponent<Text>().text += Hint[index];
    }


}
