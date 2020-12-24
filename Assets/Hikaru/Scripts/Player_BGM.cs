using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BGM : MonoBehaviour
{
    [SerializeField] private AudioClip _NormalBGM;
    [SerializeField] private AudioClip _TrackingBGM;
    
    private AudioSource audio;
    private int BGMflg;


    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        //BGMPlay(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMPlay(int a)
    {
        if(audio.clip != null) audio.Stop();
        switch (a)
        {
            case 0:
                //audio.clip = _NormalBGM;
                //audio.Play();
                break;
            case 1:
                audio.clip = _TrackingBGM;
                audio.Play();
                break;
        }
    }

}
