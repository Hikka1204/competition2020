using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOver : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOver;
    [SerializeField] GlitchEffect _p_CameraGl;
    //[SerializeField] FlgManeger _flgManeger;
    [SerializeField] FadeController fadeController;
    AudioSource audio;
    private bool isFade = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Restart()
    {
        if (isFade == true) return;
        audio.Play();
        _p_CameraGl.enabled = false;
        CanvasOver.SetActive(false);
        fadeController.isFadeOut = true;
        //_flgManeger.PlayerSpawn();
    }

    public void End()
    {
        audio.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif

    }

    private void Fade()
    {

    }

}
