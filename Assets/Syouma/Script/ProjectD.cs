using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ProjectD : MonoBehaviour
{
    bool i_flg;
    bool n_flg;
    bool i2_flg;
    bool once_flg;

    [SerializeField] GameObject _FPSCo;
    [SerializeField] GameObject _BGMObject;

    void Start()
    {
        i_flg = false;
        n_flg = false;
        i2_flg = false;
        FlagManager.Instance.projectD = false;
        once_flg = false;
    }

    void Update()
    {
        // projectD始動
        if (!FlagManager.Instance.projectD)
        {
            if (i_flg == false && Input.GetKey(KeyCode.I)) i_flg = true;
            else if (i_flg && !n_flg && Input.GetKey(KeyCode.N)) n_flg = true;
            else if (n_flg && !i2_flg && Input.GetKey(KeyCode.I)) i2_flg = true;
            else if (i2_flg && !FlagManager.Instance.projectD && Input.GetKey(KeyCode.D))
            {
                Debug.Log("projectD 始動");
                FlagManager.Instance.projectD = true;
            }
        }
        else if(!once_flg)
        {
            once_flg = true;
            CommentManager.Instance.EscapeComeSet(); // 逃走中のコメント名
            CommentManager.Instance.CommentSet(); // コメント名
            _BGMObject.GetComponent<Player_BGM>().BGMPlay(2); // BGM
            _FPSCo.GetComponent<FirstPersonController>().m_WalkSpeed = 17; // 歩く速さ
            _FPSCo.GetComponent<FirstPersonController>().m_RunSpeed = 34;  // 走る速さ
            _FPSCo.GetComponent<AudioSource>().volume = 0; // 足音を消した
        }

    }

}
