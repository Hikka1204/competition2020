using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOver : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOver;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] FlgManeger _flgManeger;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Restart()
    {
        audio.Play();
        _p_CameraGl.enabled = false;
        _flgManeger.PlayerSpawn();
        CanvasOver.SetActive(false);
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

}
