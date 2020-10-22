using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_OP : MonoBehaviour
{
    [SerializeField] private GameObject _rubble;
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _smoke;
    [SerializeField] private AudioClip _rockBreakSE;
    private AudioSource audio;
    [SerializeField] private float _rockSEPlayRate = 3;
    private float RockSEPlayTime;
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
                //Destroy(gameObject);
            }
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        _rubble.gameObject.SetActive(true);
        _floor.gameObject.SetActive(false);
        _smoke.gameObject.SetActive(true);
        audio.clip = _rockBreakSE;
        RockSEPlayTime = _rockSEPlayRate;
        //Destroy(gameObject);
    }
}
