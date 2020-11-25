using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Cheat : MonoBehaviour
{


    private bool Hflg;
    private bool Iflg;
    private bool K1flg;
    private bool K2flg;
    private bool isCheat;


    [SerializeField] private GameObject _cheat_Text;
    [SerializeField] private GameObject _cheat_Help;
    [SerializeField] private GameObject _hand;
    [SerializeField] private GameObject _Enemy;
    [SerializeField] private GameObject _FPSCo;
    [SerializeField] private FlgManeger flgm;

    // Start is called before the first frame update
    void Start()
    {
        Hflg = false;
        Iflg = false;
        K1flg = false;
        K2flg = false;
        isCheat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCheat)
        {
            if (Hflg == false && Input.GetKey(KeyCode.H)) Hflg = true;
            else if (Hflg == true && Iflg == false && Input.GetKey(KeyCode.I)) Iflg = true;
            else if (Iflg == true && K1flg == false && Input.GetKey(KeyCode.K)) K1flg = true;
            else if (K1flg == true && K2flg == false && Input.GetKey(KeyCode.K)) K2flg = true;
            else if (K2flg == true && isCheat == false && Input.GetKey(KeyCode.A))
            {
                isCheat = true;
                _cheat_Text.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Alpha1))//チート一覧の表示
            {
                _cheat_Text.SetActive(!_cheat_Text.activeSelf);
                _cheat_Help.SetActive(!_cheat_Help.activeSelf);
            }
            if (Input.GetKey(KeyCode.Alpha2))//プレイヤーのスピードを速くする
            {
                _FPSCo.GetComponent<FirstPersonController>().SpeedDouble();
            }
            if (Input.GetKey(KeyCode.Alpha3))//敵がいるときに消す　イベント発生時出現することがある
            {
                _Enemy.SetActive(false);
            }
            if (Input.GetKey(KeyCode.Alpha4))//カギが７つ持っている
            {
                _hand.GetComponent<Hand>().SetKey(7);
            }
            if (Input.GetKey(KeyCode.Alpha5))//フラグを持ってるオブジェクトをすべて出現させる
            {
                flgm.ObjectFlgActive();
            }


        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            _FPSCo.GetComponent<FirstPersonController>().IntSpeed();
            Hflg = false;
            Iflg = false;
            K1flg = false;
            K2flg = false;
            isCheat = false;
            _cheat_Text.SetActive(false);
            _cheat_Help.SetActive(false);
        }

        

    }
}
