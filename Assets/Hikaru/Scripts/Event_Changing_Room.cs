using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event_Changing_Room : MonoBehaviour
{

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector3 _spawnPo;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private EventCamera _eventCamera;
    private bool isEvent = false;

    // Start is called before the first frame update
    void Start()
    {
        isEvent = false;
    }

    private void OnEnable()
    {
        if (isEvent)
        {
            isEvent = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"|| other.gameObject.tag == "Hand") && !isEvent)
        {
            isEvent = true;
            StartCoroutine("Event");
        }
    }

    IEnumerator Event()
    {
        _enemy.SetActive(false);
        _p_CameraGl.enabled = true;
        _p_Chara.enabled = false;
        _p_Fir.enabled = false;
        _enemy.SetActive(true);
        yield return new WaitForSeconds(1.0f); //待つ
        _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(0);
        _p_CameraGl.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(0);
        _enemy.transform.position = _spawnPo;
        yield return new WaitForSeconds(2.0f); //待つ
        _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(4);
        yield return new WaitForSeconds(1.0f); //待つ
        _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(5);
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        gameObject.SetActive(false);
        yield break;
    }


}
