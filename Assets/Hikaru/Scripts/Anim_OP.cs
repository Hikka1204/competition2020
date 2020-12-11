using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_OP : MonoBehaviour
{
    [SerializeField] private GameObject _rubble;
    //[SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _smoke;
    [SerializeField] private AudioClip _rockBreakSE;
    private AudioSource audio;
    [SerializeField] private float _rockSEPlayRate = 3;
    private float RockSEPlayTime;
    [SerializeField] GameObject Player_SerifOP;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RockSEPlayTime > 0)
        {
            RockSEPlayTime -= Time.deltaTime;
            if(RockSEPlayTime <= 0)
            {
                audio.Play();
                _smoke.gameObject.SetActive(true);
                //Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Self();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelfOut();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        _rubble.gameObject.SetActive(true);
        //_floor.gameObject.SetActive(false);
        
        audio.clip = _rockBreakSE;
        RockSEPlayTime = _rockSEPlayRate;
        GetComponent<BoxCollider>().enabled = false;
        //Destroy(gameObject);
    }

    void Self()
    {
        Player_SerifOP.SetActive(true);
    }

    void SelfOut()
    {
        Player_SerifOP.SetActive(false);
    }

    //IEnumerator Serif()
    //{
    //    yield return new WaitForSeconds(0.5f); //待つ
    //    yield break;
    //}

}
