using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    GameObject ManageObject;
    SceneFadeManager fadeManager;
    [SerializeField] private float FadeRate;
    [SerializeField] private byte SceneNumber = 1;
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
            if(FadeRate <= 0 || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                switch (SceneNumber)
                {
                    case 1:
                        fadeManager.fadeOutStart(0, 0, 0, 0, "protOP");
                    break;
                    case 2:
                        fadeManager.fadeOutStart(0, 0, 0, 0, "MainGame");
                    break;
                }
            }
                
            
        }

    }
}