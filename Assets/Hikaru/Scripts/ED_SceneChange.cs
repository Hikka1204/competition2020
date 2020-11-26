using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_SceneChange : MonoBehaviour
{
    GameObject ManageObject;
    SceneFadeManager fadeManager;
    [SerializeField] private float FadeRate;
    // Start is called before the first frame update
    void Start()
    {
        //SceneFadeManagerがアタッチされているオブジェクトを取得
        ManageObject = GameObject.Find("ManageObject");
        //オブジェクトの中のSceneFadeManagerを取得
        fadeManager = ManageObject.GetComponent<SceneFadeManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(FadeRate > 0)
        {
            FadeRate -= Time.deltaTime;
            if(FadeRate <= 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    fadeManager.fadeOutStart(0, 0, 0, 0, "Master_OP_Text");
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Quit();
                }
            }
        }

    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}