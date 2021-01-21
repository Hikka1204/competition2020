using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_Tork : MonoBehaviour
{
    [SerializeField] GameObject Takumi;
    [SerializeField] GameObject Keisuke;
    [SerializeField] GameObject Bunta;
    AudioSource Audio;
    [SerializeField] AudioClip Se;
    int TKnum;
    int TBnum;
    int num;
    bool TKflg; // TakumiとKeisukeの会話フラグ
    bool TBflg; // TakumiとBuntaの会話フラグ
    bool Feadflg;

    Color[] Colors = new Color[ 6 ];

    float Alfa = 1f; //A値を操作するための変数
    public float Speed = 0.01f;  //透明化の速さ  
    public Sprite Bunta2;


    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        TKnum = 0;
        TBnum = 0;
        num = 0;
        TKflg = false;
        TBflg = true;
        Feadflg = false;

        //拓海Imageの色を取得
        Colors[0].r = Takumi.GetComponent<Image>().color.r;
        Colors[0].g = Takumi.GetComponent<Image>().color.g;
        Colors[0].b = Takumi.GetComponent<Image>().color.b;
        //拓海Textの色を取得
        Colors[1].r = Takumi.transform.GetChild(0).GetComponent<Text>().color.r;
        Colors[1].g = Takumi.transform.GetChild(0).GetComponent<Text>().color.g;
        Colors[1].b = Takumi.transform.GetChild(0).GetComponent<Text>().color.b;

        //啓介Imageの色を取得
        Colors[2].r = Keisuke.GetComponent<Image>().color.r;
        Colors[2].g = Keisuke.GetComponent<Image>().color.g;
        Colors[2].b = Keisuke.GetComponent<Image>().color.b;
        //啓介Textの色を取得
        Colors[3].r = Keisuke.transform.GetChild(0).GetComponent<Text>().color.r;
        Colors[3].g = Keisuke.transform.GetChild(0).GetComponent<Text>().color.g;
        Colors[3].b = Keisuke.transform.GetChild(0).GetComponent<Text>().color.b;

        //文太Imageの色を取得
        Colors[4].r = Bunta.GetComponent<Image>().color.r;
        Colors[4].g = Bunta.GetComponent<Image>().color.g;
        Colors[4].b = Bunta.GetComponent<Image>().color.b;
        //文太Textの色を取得
        Colors[5].r = Bunta.transform.GetChild(0).GetComponent<Text>().color.r;
        Colors[5].g = Bunta.transform.GetChild(0).GetComponent<Text>().color.g;
        Colors[5].b = Bunta.transform.GetChild(0).GetComponent<Text>().color.b;
    }

    void Update()
    {
        if (!TKflg && FlagManager.Instance.projectD && TKnum <= 5)
        {
            StartCoroutine("TKtark");
            num = 1;
        }
        if (!TBflg && FlagManager.Instance.projectD && TBnum <= 7)
        {
            StartCoroutine("TBtark");
            num = 2;
        }

        if (Feadflg)
        {
            if (num == 1)
            {
                switch (TKnum)
                {
                    case 0:
                    case 2:
                    case 3:
                        TakumiFead();
                        break;
                    case 1:
                    case 4:
                    case 5:
                        KeisukeFead();
                        break;
                }
            }else if(num == 2)
            {
                switch (TBnum)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 5:
                        TakumiFead();
                        break;
                    case 0:
                    case 4:
                    case 6:
                    case 7:
                        BuntaFead();
                        break;
                }
            }
            Alfa -= Speed;
            if(Alfa <= 0.01f)
            {
                if (num == 1) {
                    TKflg = false; // セリフを表示するフラグ
                    TKnum++; // 次のセリフを選択
                }
                else if(num == 2)
                {
                    TBflg = false; // セリフを表示するフラグ
                    TBnum++; // 次のセリフを選択
                }
                Feadflg = false;
            }
        }

    }

    IEnumerator TBtark()
    {
        TBflg = true;
        //1秒停止
        yield return new WaitForSeconds(1);
        Alfa = 1; // 透明度セット
        switch (TBnum)
        {
            case 0:
                BuntaFead();
                Bunta.transform.GetChild(0).GetComponent<Text>().text =
                    "なんだよ？";
                break;
            case 1:
                TakumiFead();
                Takumi.transform.GetChild(0).GetComponent<Text>().text =
                    "俺さ、今夜この車でバトルするんだ";
                break;
            case 2:
                TakumiFead();
                Takumi.transform.GetChild(0).GetComponent<Text>().text =
                    "タコメーター付け替えたんだ\nどこまで上げていいか教えてくれ";
                break;
            case 3:
                TakumiFead();
                Takumi.transform.GetChild(0).GetComponent<Text>().text =
                    "頼む！";
                break;
            case 4:
                BuntaFead();
                Bunta.transform.GetChild(0).GetComponent<Text>().text =
                    "・・・・・・";
                break;
            case 5:
                TakumiFead();
                Takumi.transform.GetChild(0).GetComponent<Text>().text =
                    "   ・・・・・・";
                break;
            case 6:
                Bunta.GetComponent<Image>().sprite = Bunta2;
                BuntaFead();
                Bunta.transform.GetChild(0).GetComponent<Text>().text =
                    "11000まできっちり回せ！！";
                break;
            case 7:
                BuntaFead();
                Bunta.transform.GetChild(0).GetComponent<Text>().text =
                    "勝って来いよ";
                break;
        }
        Audio.clip = Se; // SEセット
        Audio.Play();   // SE再生

        StartCoroutine("Feadout");
    }

    IEnumerator TKtark()
    {
        TKflg = true;
        //1秒停止
        yield return new WaitForSeconds(1);

        Alfa = 1; // 透明度セット
        Debug.Log(TKnum);
        switch (TKnum)
        {
            case 0:
                TakumiFead();
                Takumi.transform.GetChild(0).GetComponent<Text>().text = 
                    "うちのくそ親父め、あの車を抜かいないと\n勝ったと認めてもらえないだろうな";
                break;
            case 1:
                KeisukeFead();
                Keisuke.transform.GetChild(0).GetComponent<Text>().text = 
                    "どうしたんだ！\n今日に限ってFDがやけにのろく感じる\nセカンダリータービンが\n止まってんじゃねーのか！？";
                break;
            case 2:
                TakumiFead();
                Takumi.transform.GetChild(0).GetComponent<Text>().text =
                    "しょうがねぇ、あれやるか！\nガソリン満タンかかってるからな";
                break;
            case 3:
                TakumiFead();
                Takumi.transform.GetChild(0).GetComponent<Text>().text =
                    "仕掛けるポイントはこの先の\n5連続ヘアピンカーブだ！！";
                break;
            case 4:
                KeisukeFead();
                Keisuke.transform.GetChild(0).GetComponent<Text>().text =
                    "       ヘアピンなのに減速しねぇ？\n       何考えてやがる！";
                break;
            case 5:
                KeisukeFead();
                Keisuke.transform.GetChild(0).GetComponent<Text>().text =
                    "                                           ！？";
                StartCoroutine("Nexttark");
                break;
        }
        Audio.clip = Se; // SEセット
        Audio.Play();   // SE再生

        StartCoroutine("Feadout");
    }

    IEnumerator Feadout()
    {
        //3秒停止
        yield return new WaitForSeconds(3);
        Feadflg = true;
    }

    IEnumerator Nexttark()
    {
        //10秒停止
        yield return new WaitForSeconds(10);
        num = 2;
        StartCoroutine("TBtark");
    }

    void TakumiFead()
    {
        Takumi.GetComponent<Image>().color = new Color(Colors[0].r, Colors[0].g, Colors[0].b, Alfa);
        Takumi.transform.GetChild(0).GetComponent<Text>().color = new Color(Colors[1].r, Colors[1].g, Colors[1].b, Alfa);
    }
    void KeisukeFead()
    {
        Keisuke.GetComponent<Image>().color = new Color(Colors[2].r, Colors[2].g, Colors[2].b, Alfa);
        Keisuke.transform.GetChild(0).GetComponent<Text>().color = new Color(Colors[3].r, Colors[3].g, Colors[3].b, Alfa);
    }
    void BuntaFead()
    {
        Bunta.GetComponent<Image>().color = new Color(Colors[4].r, Colors[4].g, Colors[4].b, Alfa);
        Bunta.transform.GetChild(0).GetComponent<Text>().color = new Color(Colors[5].r, Colors[5].g, Colors[5].b, Alfa);
    }

}