using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentManager : MonoBehaviour
{
    public struct ComeData
    {
        public string Name;
        public string[] Comment_1; // 序盤
        public string[] Comment_2; // 中盤
        public string[] Comment_3; // 終盤
    }
    [System.NonSerialized] public ComeData[] Audience = new ComeData[15];
    [System.NonSerialized] public string Previous = null; // ひとつ前のコメントを入れる変数

    void Start()
    {
        CommentSet();
    }

    void Update()
    {
        
    }

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
        Audience[7].Comment_1[0] = "";
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

        Audience[10].Name = "もち：";
        Audience[10].Comment_1[0] = "廃病院的なところですか？";
        Audience[10].Comment_1[1] = "今日は何しに来たの？";
        Audience[10].Comment_1[2] = "不気味だ…";
        Audience[10].Comment_2[0] = "ガチじゃん";
        Audience[10].Comment_2[1] = "やっばぁ…";
        Audience[10].Comment_2[2] = "もう帰ろう";
        Audience[10].Comment_3[0] = "帰ろう…";
        Audience[10].Comment_3[1] = "無理だってやばいじゃん";
        Audience[10].Comment_3[2] = "ドア壊しちゃえ";

        Audience[11].Name = "目黒：";
        Audience[11].Comment_1[0] = "ここってガチですか？？";
        Audience[11].Comment_1[1] = "めっちゃ雰囲気ありますね";
        Audience[11].Comment_2[0] = "うわ…ガチやん";
        Audience[11].Comment_2[1] = "身体とか大丈夫ですか？";
        Audience[11].Comment_3[0] = "まじでやばいじゃん";
        Audience[11].Comment_3[1] = "応援してるから死ぬなー";

        Audience[12].Name = "ぼたん飴：";
        Audience[12].Comment_1[0] = "雰囲気ありますねー";
        Audience[12].Comment_1[1] = "うわ…真っ暗";
        Audience[12].Comment_1[2] = "幽霊見たい！";
        Audience[12].Comment_2[0] = "最悪";
        Audience[12].Comment_2[1] = "成仏してくれよー";
        Audience[12].Comment_2[3] = "怖すぎてわろた";
        Audience[12].Comment_3[0] = "笑えない…";
        Audience[12].Comment_3[1] = "気持ち悪い…";
        Audience[12].Comment_3[1] = "これ以上見れないかも";

        Audience[13].Name = "髪の毛ほしい：";
        Audience[13].Comment_1[0] = "うわ…怖そうｗ";
        Audience[13].Comment_1[1] = "ライト無いと無理だな";
        Audience[13].Comment_1[2] = "暗ッ！";
        Audience[13].Comment_2[0] = "こんなにハッキリ写るんだ";
        Audience[13].Comment_2[1] = "やべぇなおい";
        Audience[13].Comment_2[3] = "うわ…";
        Audience[13].Comment_3[0] = "こんなの配信していいのかよ";
        Audience[13].Comment_3[1] = "BANされねぇのか心配だ";
        Audience[13].Comment_3[1] = "ケガしないようにしなよ";

        Audience[14].Name = "たか：";
        Audience[14].Comment_1[0] = "こんちわー";
        Audience[14].Comment_1[1] = "うっわ、暗ッ！";
        Audience[14].Comment_1[2] = "うせやん";
        Audience[14].Comment_1[3] = "いぇいいぇい";
        Audience[14].Comment_2[0] = "居るやん！あ、ちゃうか…";
        Audience[14].Comment_2[1] = "タバコ吸わせて";
        Audience[14].Comment_3[0] = "休憩";
        Audience[14].Comment_3[1] = "来るな来いよボケッ！";
        Audience[14].Comment_3[1] = "あーもう、なんかやだなぁ";

    }
}
