
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRollScript : MonoBehaviour
{
    //　テキストのスクロールスピード
    [SerializeField]
    private float textScrollSpeed = 30f;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 600f;
    //　テキストの表示させるまでの時間
    [SerializeField]
    private float TextCount = 2f;
    //　エンドロールが終了したかどうか
    private bool isStopEndRoll;
    //　シーン移動用コルーチン
    private Coroutine endRollCoroutine;
    //シーン移動用スクリプト
    [SerializeField]
    private ED_SceneChange ed_sc;
    //テキスト表示
    [SerializeField]
    private GameObject ClickText;

    private float speed;    //格納用textScrollSpeed

    // Update is called once per frame
    void Update()
    {
        //　エンドロールが終了した時
        if (isStopEndRoll)
        {
            endRollCoroutine = StartCoroutine(GoToNextScene());
            
        }
        else
        {
            //　エンドロール用テキストがリミットを越えるまで動かす
            if (transform.position.y <= limitPosition)
            {
                speed = textScrollSpeed;
                if (Input.GetMouseButton(0))
                {

                    speed = textScrollSpeed * 5;
                }

                transform.position = new Vector2(transform.position.x, transform.position.y + speed);
            }
            else
            {
                isStopEndRoll = true;
            }
        }

    }

    IEnumerator GoToNextScene()
    {
        //　TextCount秒間待つ
        yield return new WaitForSeconds(TextCount);

        ClickText.SetActive(true);
        ed_sc.enabled = true;

        //if (Input.GetKeyDown("space"))
        //{
        //    StopCoroutine(endRollCoroutine);
        //    SceneManager.LoadScene("EndRollStartScene");
        //}

        yield return null;
    }
}
