using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    GameObject ManageObject;
    SceneFadeManager fadeManager;
    AudioSource audio;
    private bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        //SceneFadeManagerがアタッチされているオブジェクトを取得
        ManageObject = GameObject.Find("ManageObject");
        //オブジェクトの中のSceneFadeManagerを取得
        fadeManager = ManageObject.GetComponent<SceneFadeManager>();
        audio = GetComponent<AudioSource>();
        isStart = false;
    }

    public void OnClick()
    {
        if (!isStart)
        {
            audio.Play();
            isStart = true;
            fadeManager.fadeOutStart(0, 0, 0, 0, "Master_OP_Text");
        }
        
    }

    public void OnClickQuit()
    {
        audio.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
