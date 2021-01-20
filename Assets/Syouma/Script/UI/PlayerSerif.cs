using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSerif : MonoBehaviour
{

    const float WaitTime = 3f; // セリフの表示時間
    private bool ispushE = false;
    private bool isDoor = false;
    private Vector3 Intpo;  //初期場所
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;

    void Start()
    {
        ispushE = false;
        isDoor = false;
        Intpo = gameObject.transform.position;
    }

    void Update()
    {
        Serif();
        Key();
    }

    private void Serif()
    {
        // No.0 : 鍵がない状態で出口を調べた時のセリフ
        if (FlagManager.Instance.SerifFlg[0] == true)
        {
            
            if (isDoor == true)
            {
                this.GetComponent<Text>().text = "カギがかかってる…探さなきゃ…！…";
            }
            if (isDoor == false)
            {
                isDoor = true;
                this.GetComponent<Text>().text = "カギがかかってる…";
                FlagManager.Instance.SerifFlg[0] = false;
            }
            //this.GetComponent<Text>().text = "鍵がかかっているようだ";
            TextControl(0);
        }

        // No.1 : 
        else if (FlagManager.Instance.SerifFlg[1] == true)
        {
            this.GetComponent<Text>().text = "何だあれは！";
            TextControl(1);
        }

        if (FlagManager.Instance.SerifFlg[2] == true)
        {
            this.GetComponent<Text>().text = "入口が塞がれてしまった";
            TextControl(2);
        }

        if (FlagManager.Instance.SerifFlg[3] == true)
        {
            this.GetComponent<Text>().text = "どこかで「出口」を探さないと！";
            TextControl(3);
        }

        if (FlagManager.Instance.SerifFlg[4] == true)
        {
            this.GetComponent<Text>().text = "非常口にカギがかかってる…\nカギを探さないとここから出られない…？";
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 90, po.z);
            TextControl(4);
        }
    }

    


    private void Key()
    {
        if (FlagManager.Instance.Key_Text[0] == true)
        {

            if (isDoor == true)
            {
                this.GetComponent<Text>().text = "カギがかかってる…探さなきゃ…！";
            }
            if (isDoor == false)
            {
                isDoor = true;
                this.GetComponent<Text>().text = "カギがかかってる…";
                FlagManager.Instance.Key_Text[0] = false;
            }

            //this.GetComponent<Text>().text = "カギがかかっている";

            KeyControl(0);
        }
        if (FlagManager.Instance.Key_Text[1] == true)
        {
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 60, po.z);
            this.GetComponent<Text>().text = "皆さん、地下の更衣室のカギだって、\nなるほどこの病院は二階じゃなくて地下があるんすね";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                //_p_Chara.enabled = true;
                //_p_Fir.enabled = true;
                ispushE = false;
                FlagManager.Instance.Key_Text[1] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
            //StartCoroutine(e_PlayerSerif("「ここは二階じゃなくて地下があるのか…」", 1));
        }
        if (FlagManager.Instance.Key_Text[2] == true)
        {
            //this.GetComponent<Text>().text = "中央の階段のカギを手に入れた";
            //StartCoroutine(e_PlayerSerif("「これで戻れそうだ」", 2));
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 90, po.z);
            this.GetComponent<Text>().text = "診察室のカギがありました\n確か入ってきたところのすぐ横でしたよね？\n階段のカギもあったし行ってみましょうか。";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                _p_Chara.enabled = true;
                _p_Fir.enabled = true;
                ispushE = false;
                FlagManager.Instance.Key_Text[2] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
        }
        if (FlagManager.Instance.Key_Text[3] == true)
        {
            //this.GetComponent<Text>().text = "１階の診察室のカギを手に入れた";
            //StartCoroutine(e_PlayerSerif("「確か入り口の横の部屋だ」", 3));
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 90, po.z);
            this.GetComponent<Text>().text = "診察室のカギがありました\n確か入ってきたところのすぐ横でしたよね？\n階段のカギもあったし行ってみましょうか。";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                _p_Chara.enabled = true;
                _p_Fir.enabled = true;
                ispushE = false;
                FlagManager.Instance.Key_Text[3] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
        }
        if (FlagManager.Instance.Key_Text[4] == true)
        {
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            //this.GetComponent<Text>().text = "地下の資料室のカギを手に入れた";
            //StartCoroutine(e_PlayerSerif("「地下に落ちた場所のすぐ近くだったような…」", 4));
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 90, po.z);
            this.GetComponent<Text>().text = "資料室のカギです…\n地下に落ちた所のすぐ近くの部屋でしたよね？\nあそこは危ないんで階段で行きます。";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                _p_Chara.enabled = true;
                _p_Fir.enabled = true;
                ispushE = false;
                FlagManager.Instance.Key_Text[4] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
        }
        if (FlagManager.Instance.Key_Text[5] == true)
        {
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            //this.GetComponent<Text>().text = "１階の手術室のカギを手に入れた";
            //StartCoroutine(e_PlayerSerif("「確か受付の前の部屋のはずだ」", 5));
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 90, po.z);
            this.GetComponent<Text>().text = "手術室のカギ…\n受付の前のところでしたよね？\n早めに非常口のカギ見つけてここから出たいと思います…。";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                _p_Chara.enabled = true;
                _p_Fir.enabled = true;
                ispushE = false;
                FlagManager.Instance.Key_Text[5] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
        }
        if (FlagManager.Instance.Key_Text[6] == true)
        {
            //_p_Chara.enabled = false;
            //_p_Fir.enabled = false;
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 120, po.z);
            this.GetComponent<Text>().text = "霊安室のカギ…\n確か地下の奥…長い廊下の先だったと思います。\nこれかなりやばい方向に進んでませんか…？\n無事に出られるんですかね？";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                //_p_Chara.enabled = true;
                //_p_Fir.enabled = true;
                ispushE = false;
                FlagManager.Instance.Key_Text[6] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
            //StartCoroutine(e_PlayerSerif("「ここは二階じゃなくて地下があるのか…」", 1));
        }
        if (FlagManager.Instance.Key_Text[7] == true)
        {
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            //this.GetComponent<Text>().text = "１階の非常口のカギを手に入れた";
            //StartCoroutine(e_PlayerSerif("「やった！これで出られる…!!」", 7));
            var po = GetComponent<Text>().transform.position;
            GetComponent<Text>().transform.position = new Vector3(po.x, 90, po.z);
            this.GetComponent<Text>().text = "非常口のカギ…！\nやった…やった！皆さん！\nこれでやっと出られます…！ありがとうございます!!";
            if (Input.GetKeyDown(KeyCode.E) && ispushE == true)
            {
                _p_Chara.enabled = true;
                _p_Fir.enabled = true;
                ispushE = false;
                FlagManager.Instance.Key_Text[7] = false;
                GetComponent<Text>().transform.position = new Vector3(po.x, po.y, po.z);
                TextClear();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E) && ispushE == false) ispushE = true;
        }
        if (FlagManager.Instance.Key_Text[8] == true)
        {
            this.GetComponent<Text>().text = "カギを開けた";
            KeyControl(8);
        }
        if (FlagManager.Instance.Key_Text[9] == true)
        {
            this.GetComponent<Text>().text = "…？開かない…";
            KeyControl(9);
        }
    }

    void TextControl (int i)
    {
        Invoke("TextClear", WaitTime);
        FlagManager.Instance.SerifFlg[i] = false;
    }

    void KeyControl(int i)
    {
        Invoke("TextClear", WaitTime);
        FlagManager.Instance.Key_Text[i] = false;
    }

    void TextClear()
    {
        this.GetComponent<Text>().text = "";
        GetComponent<Text>().transform.position = new Vector3(Intpo.x, Intpo.y, Intpo.z);
    }
}
