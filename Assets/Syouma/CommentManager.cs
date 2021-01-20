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
    [System.NonSerialized] public ComeEvent[] Event = new ComeEvent[11];

    public bool Escape_Flg; // true=逃げている、false=通常時
    public bool Event_Flg; // true=逃げている、false=通常時
    // 逃げている間のコメント集
    [System.NonSerialized] public string[] Escape = new string[39];
    // 敵のコメント集
    [System.NonSerialized] public string[] Enemy = new string[11];


    void Start()
    {
        CommentSet();
        EscapeComeSet();
        EnemyCommentSet();
        EventCommentSet();
        Escape_Flg = false;
        Event_Flg = false;
    }

    void Update()
    {
    }

    public void CommentSet()
    {
        for (int i = 0; i < Audience.Length; i++)
        {
            Audience[i].Comment_1 = new string[5];
            Audience[i].Comment_2 = new string[5];
            Audience[i].Comment_3 = new string[5];
        }

        Audience[0].Name = "かおり：";
        Audience[0].Comment_1[0] = "怖くないの？";
        Audience[0].Comment_1[1] = "無事帰れますように";
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
        Audience[4].Comment_1[0] = "結構暗いね";
        Audience[4].Comment_1[1] = "こわいな～";
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
        Audience[6].Comment_1[0] = "結構もろくなってるな";
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
        Audience[8].Comment_3[0] = "";

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
            Audience[12].Comment_2[2] = "怖すぎてわろた";
        Audience[12].Comment_3[0] = "笑えない…";
        Audience[12].Comment_3[1] = "気持ち悪い…";
        Audience[12].Comment_3[2] = "これ以上見れないかも";

        Audience[13].Name = "髪の毛ほしい：";
        Audience[13].Comment_1[0] = "うわ…怖そうｗ";
        Audience[13].Comment_1[1] = "ライト無いと無理だな";
        Audience[13].Comment_1[2] = "暗ッ！";
            Audience[13].Comment_2[0] = "こんなにハッキリ写るんだ";
            Audience[13].Comment_2[1] = "やべぇなおい";
            Audience[13].Comment_2[2] = "うわ…";
        Audience[13].Comment_3[0] = "こんなの配信していいのかよ";
        Audience[13].Comment_3[1] = "BANされねぇのか心配だ";
        Audience[13].Comment_3[2] = "ケガしないようにしなよ";

        Audience[14].Name = "たか：";
        Audience[14].Comment_1[0] = "こんちわー";
        Audience[14].Comment_1[1] = "うっわ、暗ッ！";
        Audience[14].Comment_1[2] = "うせやん";
        Audience[14].Comment_1[3] = "いぇいいぇい";
            Audience[14].Comment_2[0] = "居るやん！あ、ちゃうか…";
            Audience[14].Comment_2[1] = "タバコ吸わせて";
        Audience[14].Comment_3[0] = "休憩";
        Audience[14].Comment_3[1] = "来るな来いよボケッ！";
        Audience[14].Comment_3[2] = "あーもう、なんかやだなぁ";

        if (FlagManager.Instance.projectD) {
            Audience[0].Name = "藤原　拓海：";
            Audience[1].Name = "藤原　文太：";
            Audience[2].Name = "池谷先輩：";
            Audience[3].Name = "高橋　啓介：";
            Audience[4].Name = "高橋　涼介：";
            Audience[5].Name = "沙雪：";
            Audience[6].Name = "須藤　京一：";
            Audience[7].Name = "岩城　清次：";
            Audience[8].Name = "佐藤 真子：";
            Audience[9].Name = "庄司 慎吾：";
            Audience[10].Name = "茂木 なつき：";
            Audience[11].Name = "中村 賢太：";
            Audience[12].Name = "秋山　渉：";
            Audience[13].Name = "中里　毅：";
            Audience[14].Name = "武内 樹：";
        }
    }
    public void EscapeComeSet()
    {
        if (!FlagManager.Instance.projectD)
        {
            Escape[0] = "かおり：逃げて！";
            Escape[1] = "かおり：なんなの？！";
            Escape[2] = "かおり：何あれ！！";
            Escape[3] = "ちょんまげ男：走れ！";
            Escape[4] = "ちょんまげ男：走れ走れ走れ";
            Escape[5] = "ちょんまげ男：なんだよあれ！";
            Escape[6] = "卵かけライス：だからやめとけって...";
            Escape[7] = "卵かけライス：捕まるなよ";
            Escape[8] = "卵かけライス：助からないかもな";
            Escape[9] = "みさき：ええええええ！";
            Escape[10] = "みさき：やばいいい";
            Escape[11] = "みさき：死なないで！";
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
        else
        {
            Escape[0] = "藤原　拓海：バカおやじ ハチロク返せ～っ!!!";
            Escape[1] = "藤原　拓海：曲がる!曲がってくれ俺のハチロク!";
            Escape[2] = "藤原　拓海：ベンツのカレシと仲良くやれよ、オレにかまうな";
            Escape[3] = "藤原　拓海：ガソリン満タン忘れんなよ！";
            Escape[4] = "藤原　文太：一万一千回転まできっちり回せ！！";
            Escape[5] = "藤原　文太：いや煙草すいたくなった。";
            Escape[6] = "藤原　文太：勝って来い";
            Escape[7] = "池谷先輩：マジか～拓海～ハイオク飲んでみるか～お前は～!?";
            Escape[8] = "池谷先輩：あつあげ・・ください・・";
            Escape[9] = "高橋　啓介：セカンダリータービンが止まってんじゃねーのか！？";
            Escape[10] = "高橋　啓介：オレのFDが・・行けると教えてくれてる・・!";
            Escape[11] = "高橋　啓介：バックミラーから消してみせるぜ！";
            Escape[12] = "高橋　啓介：オレはGT-Rがだいっ嫌いなんだよ!!";
            Escape[13] = "高橋　啓介：あと一つ、死ぬ気で突っ込め!!";
            Escape[14] = "高橋　啓介：アドレナリン全開の最大ブーストでぶっちぎってやらぁ!!";
            Escape[15] = "高橋　啓介：俺は秋名で死んだ走りやの幽霊でも見たのか";
            Escape[16] = "高橋　涼介：右コーナーがヘタクソだってことさ!!";
            Escape[17] = "高橋　涼介：お前は速かったよ。また会おう";
            Escape[18] = "高橋　涼介：俺の最速理論に、ゆるぎは無い!";
            Escape[19] = "中里　毅：俺のRについてこれるか？！";
            Escape[20] = "中里　毅：なめてんじゃねーぞ!外から行かすかよぉ!!";

            Escape[21] = "中里　毅：また板金７万円コースかな・・・";
            Escape[22] = "中里　毅：インか?アウトか?・・・アウトだとっ!!!";
            Escape[23] = "須藤　京一：アクセル全開が四駆の基本だ！";
            Escape[24] = "須藤　京一：俺のエボⅢは曲がる!";
            Escape[25] = "岩城　清次：アウト・オブ・眼中！！";
            Escape[26] = "岩城　清次：峠の王者はランエボだ!!";
            Escape[27] = "岩城　清次：このままバックミラーからけしてやるぜ！";
            Escape[28] = "秋山　渉：アドレナリンどっぱどぱだぜ";
            Escape[29] = "秋山　渉：ここは追い抜きとか、そういうのは、なしなんだよ!!";
            Escape[30] = "秋山　渉：峠で速い奴が一番かっこいいんだ イケてるぜおまえ";
            Escape[31] = "秋山　渉：貧乏でも努力した奴が勝ってこそドラマじゃねーのか";
            Escape[32] = "庄司 慎吾：二人で仲良くダブルクラッシュといこうぜ！";
            Escape[33] = "庄司 慎吾：俺だって、ホンダがFR作ったら乗り換えるよ";
            Escape[34] = "庄司 慎吾：俺の、EG6・・・";
            Escape[35] = "沙雪：うまい走り屋は常にわずかな安全マージンを残すことを忘れない";
            Escape[36] = "沙雪：外から見れば限界ギリギリのハイペースに見えても……少しだけ余力を残す……";
            Escape[37] = "沙雪：対向車なし!全開でいくよっ!";
            Escape[37] = "佐藤 真子：もうバックミラーなんか、二度と見ない！";
            Escape[38] = "佐藤 真子：悔いだけは残さない。碓氷最速のプライドに賭けて。";

        }
    }
    void EnemyCommentSet()
    {
        Enemy[0] = "にがさない…"; // 非常口のドアに触れたら
        Enemy[1] = "うぅぅ゛"; // ナースコールが止まって、カギを取ったら
        Enemy[2] = "見つけた…"; // 地下に落ちて最初の曲がり角を曲がったら  
        Enemy[3] = "あ゛あぁ゛"; // 更衣室でカギを取ったら
        Enemy[4] = "どうして"; // 地上に戻ったら
        Enemy[5] = "許さない…"; //階段で地下に行ったら
        Enemy[6] = "あ゛あぁぁ゛"; // 地上に戻り、手術室に向かっている途中で
        Enemy[7] = "あの人も…"; // 霊安室に向かうまで
        Enemy[8] = "あの女も…";
        Enemy[9] = "皆いなくなればいい…";
        Enemy[10] = "あなたもにがさない"; // 最後のカギを取り
    }
    void EventCommentSet()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            Event[i].E_Comment = new string[10];
        }

        // OPムービーが終わった後で
        Event[0].E_Comment[0] = "かおり：ここからじゃ出れないよね？";
        Event[0].E_Comment[1] = "りんご星人：何が起きたんだ！？";
        Event[0].E_Comment[2] = "あげぱん：出口を探そう";
        // 非常口のドアが開かずナースコールが鳴りだしたら
        Event[1].E_Comment[0] = "ちょんまげ男：なんか聞こえるぞ";
        Event[1].E_Comment[1] = "りんご星人：音なってるぞ？";
        Event[1].E_Comment[2] = "みかママ：そういえば受付にナースコールあったよ";
        // 幽霊と初対面した際
        Event[2].E_Comment[0] = "きな粉：ついて行ってみません？";
        Event[2].E_Comment[1] = "りんご星人：バレないように追いかけよう！";
        Event[2].E_Comment[2] = "ちょんまげ男：お前も行けｗ";
        Event[2].E_Comment[3] = "あげぱん：完全に見えてますが…";
        Event[2].E_Comment[4] = "かおり：もう嫌なんだけど！";
        // ナースコールを止めて受付から出る、遠くで扉の音が鳴ったタイミング
        Event[3].E_Comment[0] = "きな粉：さっきの奴じゃない？";
        Event[3].E_Comment[1] = "りんご星人：ドアが開く音したよね？";
        Event[3].E_Comment[2] = "かおり：遠くで音したよ";
        // 地下に落ちたタイミング
        Event[4].E_Comment[0] = "りんご星人：何が起きたんだ！？";
        Event[4].E_Comment[1] = "ちょんまげ男：びっくりした！！";
        Event[4].E_Comment[2] = "もち：ええええええ";
        Event[4].E_Comment[3] = "目黒：危なっ！";
        Event[4].E_Comment[4] = "髪の毛ほしい：くずれんのか！";
        Event[4].E_Comment[5] = "かおり：大丈夫ですか？";
        Event[4].E_Comment[6] = "卵かけライス：早く帰ったほうがいい";
        Event[4].E_Comment[7] = "みさき：あぶなかった～";
        Event[4].E_Comment[8] = "アレン：うわ大丈夫か？";
        //C_Event[18] = "せいや：FF外から失礼するゾ＾～　この放送面白スギィ！自分、お気に入り登録とコテハン登録とTwitterフォローとYoutubeチャンネル登録と高評価と通知ONとツイートのファボいいすか？淫夢のリストにもぶちこんでやるぜ";
        // 診察室でのイベント中
        Event[5].E_Comment[0] = "目黒：なんだこれ！";
        Event[5].E_Comment[1] = "きな粉：なになになに！！";
        Event[5].E_Comment[2] = "りんご星人：血じゃん！";
        Event[5].E_Comment[3] = "髪の毛ほしい：まじかよ";
        Event[5].E_Comment[4] = "アレン：おいおいおいおい";
        Event[5].E_Comment[5] = "ぼたん飴：やばすぎでしょ";
        Event[5].E_Comment[6] = "もち：手が・・・";
        // 資料室でのイベント中
        Event[6].E_Comment[0] = "みさき：うわ！";
        Event[6].E_Comment[1] = "卵かけライス：近い近い！";
        Event[6].E_Comment[2] = "みかママ：いるいる";
        Event[6].E_Comment[3] = "りんご星人：怒ってる？";
        // 資料室でのイベント後
        Event[7].E_Comment[0] = "りんご星人：あいつカギ落としたぞ";
        Event[7].E_Comment[1] = "もち：あれなんか落ちてる";
        // 手術室に入ったら 
        Event[8].E_Comment[0] = "りんご星人：ここはやばい";
        Event[8].E_Comment[1] = "ちょんまげ男：不気味だ";
        Event[8].E_Comment[2] = "あげぱん：カギがある！";
        // 霊安室に入ったら
        Event[9].E_Comment[0] = "りんご星人：全員男…？";
        Event[9].E_Comment[1] = "さちこ：あっ…カギある";
        Event[9].E_Comment[2] = "あげぱん：死体じゃん…";
        Event[9].E_Comment[3] = "さちこ：本物じゃないですよね";
        Event[9].E_Comment[4] = "卵かけライス：カギがあるぞ！";
        // 霊安室でのイベント中
        Event[10].E_Comment[0] = "アレン：やばいやばい";
        Event[10].E_Comment[1] = "髪の毛ほしい：うわ！きた！";
        Event[10].E_Comment[2] = "目黒：早くここでよ！！";
        Event[10].E_Comment[3] = "みかママ：逃げ切って！";
        Event[10].E_Comment[4] = "りんご星人：非常口までそのまま突っ切れ！";
    }                      

}
