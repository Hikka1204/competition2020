using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BGM : MonoBehaviour
{
    [SerializeField] private AudioClip _NormalBGM;
    [SerializeField] private AudioClip _TrackingBGM;
    [SerializeField] AudioClip[] DMusic = new AudioClip[5];

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
        if (FlagManager.Instance.projectD)
        {
            if (Input.GetKey(KeyCode.F1)){
                audio.clip = DMusic[0];
                audio.Play();
            }
            if (Input.GetKey(KeyCode.F2))
            {
                audio.clip = DMusic[1];
                audio.Play();
            }
            if (Input.GetKey(KeyCode.F3))
            {
                audio.clip = DMusic[2];
                audio.Play();
            }
            if (Input.GetKey(KeyCode.F4))
            {
                audio.clip = DMusic[3];
                audio.Play();
            }
            if (!audio.isPlaying)
            {
                audio.clip = DMusic[Random.Range(0, 3)];
                audio.Play();
            }
        }

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
                if(!FlagManager.Instance.projectD)
                    audio.clip = _TrackingBGM;
                else
                    audio.clip = DMusic[4];
                audio.Play();
                break;
            case 2:
                audio.clip = DMusic[Random.Range(0, 3)];
                audio.Play();
                break;
        }
    }

}
