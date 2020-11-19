using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Event_Reference_room : MonoBehaviour
{
    [SerializeField] private GameObject[] Shelf = new GameObject[7];
    [SerializeField] private byte _fmgFlg = 5;
    [SerializeField] private FlgManeger fmg;
    [SerializeField] private GameObject Event_Enter_Reference_Enemy;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private EventCamera _eventCamera;

    private bool isEvent;

    // Start is called before the first frame update
    void Start()
    {
        isEvent = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !isEvent)
        {
            isEvent = true;
            AddForce();
            StartCoroutine("Event");
        }
    }

    private void AddForce()
    {
        for(int i = 0; i < Shelf.Length; i++)
        {
            GameObject child7 = Shelf[i].gameObject.transform.GetChild(7).gameObject;
            GameObject child8 = Shelf[i].gameObject.transform.GetChild(8).gameObject;
            for(int j = 0; j < 5; j++)
            {
                child7.transform.GetChild(j).gameObject.GetComponent<BlowOff>().enabled = true;
                child8.transform.GetChild(j).gameObject.GetComponent<BlowOff>().enabled = true;
            }
            Shelf[i].gameObject.GetComponent<BlowOff>().enabled = true;
        }
        fmg.GetFlg(_fmgFlg);
        //Destroy(gameObject);
    }

    IEnumerator Event()
    {
        _p_CameraGl.enabled = true;
        _p_Chara.enabled = false;
        _p_Fir.enabled = false;
        yield return new WaitForSeconds(0.5f); //待つ
        Event_Enter_Reference_Enemy.SetActive(true);
        _p_CameraGl.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(2);
        yield return new WaitForSeconds(2.5f); //待つ
        Destroy(Event_Enter_Reference_Enemy);
        _eventCamera.CameraStop();
        yield return new WaitForSeconds(1.0f); //待つ
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;

        yield break;
    }
}
