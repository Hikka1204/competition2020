using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // 通常時のコメントを入れる配列
    public struct ComeData
    {
        public string Name;
        public string[] Comment_1; // 序盤
        public string[] Comment_2; // 中盤
        public string[] Comment_3; // 終盤
    }
    [System.NonSerialized] public ComeData[] Audience = new ComeData[15];
    [System.NonSerialized] public string Previous = null; // ひとつ前のコメントを入れる変数

    // イベント時のコメントを入れる配列
    public struct ComeEvent
    {
        public string[] E_Comment;
    }
    [System.NonSerialized] public ComeEvent[] Event = new ComeEvent[10];

    public bool Escape_Flg; // true=逃げている、false=通常時
    // 逃げている間のコメント集
    [System.NonSerialized] public string[] Escape = new string[39];
    // 敵のコメント集
    [System.NonSerialized] public string[] Enemy = new string[5];


    void Start()
    {
        CommentSet();
        EscapeComeSet();
        EnemyCommentSet();
        EventCommentSet();
        Escape_Flg = false;
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
    void EscapeComeSet()
    {
        Escape[0]  = "かおり：逃げて！";
        Escape[1]  = "かおり：なんなの？！";
        Escape[2]  = "かおり：何あれ！！";
        Escape[3]  = "ちょんまげ男：走れ！";
        Escape[4]  = "ちょんまげ男：走れ走れ走れ";
        Escape[5]  = "ちょんまげ男：なんだよあれ！";
        Escape[6]  = "卵かけライス：だからやめとけって...";
        Escape[7]  = "卵かけライス：捕まるなよ";
        Escape[8]  = "卵かけライス：助からないかもな";
        Escape[9]  = "みさき：ええええええ！";
        Escape[10]  = "みさき：やばいいい";
        Escape[11]  = "みさき：死なないで！";
        Escape[12] = "りんご星人：なんだこいつっ！";
        Escape[13] = "りんご星人：すごいもの見てるわ";
        Escape[14] = "りんご星人：逃げきれ！";
        Escape[15] = "みかママ：え？";
        Escape[16] = "みかママ：お願い逃げて";
        Escape[17] = "みかママ：逃げ切って！";
        Escape[18] = "あげパン：やばいやばい";
        Escape[19] = "あげパン：早く逃げて";
        Escape[20] = "あげパン：すごくない";

        Escape[21] = "さちこ：早く出て";
        Escape[22] = "さちこ：逃げてください！";
        Escape[23] = "さちこ：もう無理です";
        Escape[24] = "きな粉：死なないで";
        Escape[25] = "きな粉：えええ";
        Escape[26] = "きな粉：こわ";
        Escape[27] = "もち：早く出よ！！！";
        Escape[28] = "もち：怖い怖い怖い";
        Escape[29] = "もち：無理無理";
        Escape[30] = "目黒：ヤバヤバ";
        Escape[31] = "目黒：捕まらないで";
        Escape[32] = "目黒：ガチカコレ";
        Escape[33] = "ぼたん飴：こわっｗ";
        Escape[34] = "ぼたん飴：本物の幽霊？！";
        Escape[35] = "ぼたん飴：これ本当ですか？";
        Escape[36] = "髪の毛ほしい：まじ？";
        Escape[37] = "髪の毛ほしい：もっと走って！";
        Escape[38] = "髪の毛ほしい：来てるって！！";
        //Escape[39] = "たか：";
        //Escape[40] = "たか：";
        //Escape[41] = "たか：";
    }
    void EnemyCommentSet()
    {
        Enemy[0] = "";
        Enemy[1] = "";
        Enemy[2] = "";
        Enemy[3] = "";
        Enemy[4] = "";
    }
    void EventCommentSet()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            Event[i].E_Comment = new string[9];
        }

        // OPムービーが終わった後で
        Event[0].E_Comment[0] = "かおり：ここからじゃ出れないよね？";
        Event[0].E_Comment[1] = "りんご星人：何が起きたんだ！？";
        Event[0].E_Comment[2] = "あげぱん：出口を探そう";
        // 非常口のドアが開かずナースコールが鳴りだしたら
        Event[1].E_Comment[0] = "ちょんまげ男：なんか聞こえるぞ";
        Event[1].E_Comment[1] = "りんご星人：音なってるぞ？";
        Event[1].E_Comment[2] = "みかママ：そういえば受付にナースコールあったよ";
        // ナースコールを止めて受付から出る、遠くで扉の音が鳴ったタイミング
        Event[2].E_Comment[0] = "きな粉：音しなかった？";
        Event[2].E_Comment[1] = "りんご星人：ドアが開く音したよね？";
        Event[2].E_Comment[2] = "かおり：遠くで音したよ";
        // 地下に落ちたタイミング
        Event[3].E_Comment[0] = "りんご星人：何が起きたんだ！？";
        Event[3].E_Comment[1] = "ちょんまげ男：びっくりした！！";
        Event[3].E_Comment[2] = "もち：ええええええ";
        Event[3].E_Comment[3] = "目黒：危なっ！";
        Event[3].E_Comment[4] = "髪の毛ほしい：くずれんのか！";
        Event[3].E_Comment[5] = "かおり：大丈夫ですか？";
        Event[3].E_Comment[6] = "卵かけライス：早く帰ったほうがいい";
        Event[3].E_Comment[7] = "みさき：あぶなかった～";
        Event[3].E_Comment[8] = "アレン：うわ大丈夫か？";
        //C_Event[18] = "せいや：FF外から失礼するゾ＾～　この放送面白スギィ！自分、お気に入り登録とコテハン登録とTwitterフォローとYoutubeチャンネル登録と高評価と通知ONとツイートのファボいいすか？淫夢のリストにもぶちこんでやるぜ";
        // 診察室でのイベント中
        Event[4].E_Comment[0] = "目黒：なんだこれ！";
        Event[4].E_Comment[1] = "きな粉：なになになに！！";
        Event[4].E_Comment[2] = "りんご星人：血じゃん！";
        Event[4].E_Comment[3] = "髪の毛ほしい：まじかよ";
        Event[4].E_Comment[4] = "アレン：おいおいおいおい";
        Event[4].E_Comment[5] = "ぼたん飴：やばすぎでしょ";
        Event[4].E_Comment[6] = "もち：手が・・・";
        // 資料室でのイベント中
        Event[5].E_Comment[0] = "みさき：うわ！";
        Event[5].E_Comment[1] = "みかママ：いるいる";
        Event[5].E_Comment[2] = "りんご星人：怒ってる？";
        Event[5].E_Comment[3] = "卵かけライス：近い近い！";
        // 資料室でのイベント4後
        Event[6].E_Comment[0] = "りんご星人：あいつカギ落としたぞ";
        Event[6].E_Comment[1] = "もち：あれなんか落ちてる";
        // 手術室に入ったら 2
        Event[7].E_Comment[0] = "りんご星人：ここはやばい";
        Event[7].E_Comment[1] = "ちょんまげ男：不気味だ";
        Event[7].E_Comment[2] = "あげぱん：カギがある！";
        // 霊安室に入ったら
        Event[8].E_Comment[0] = "りんご星人：全員男…？";
        Event[8].E_Comment[1] = "さちこ：あっ…カギある";
        Event[8].E_Comment[2] = "あげぱん：死体じゃん…";
        Event[8].E_Comment[3] = "さちこ：本物じゃないですよね";
        Event[8].E_Comment[4] = "卵かけライス：カギがあるぞ！";
        // 霊安室でのイベント中
        Event[9].E_Comment[0] = "アレン：やばいやばい";
        Event[9].E_Comment[1] = "髪の毛ほしい：うわ！きた！";
        Event[9].E_Comment[2] = "目黒：早くここでよ！！";
        Event[9].E_Comment[3] = "みかママ：逃げ切って！";
        Event[9].E_Comment[4] = "りんご星人：非常口までそのまま突っ切れ！";
    }                      

}
