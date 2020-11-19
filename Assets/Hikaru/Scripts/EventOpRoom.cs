using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EventOpRoom : MonoBehaviour
{

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector3 _spawnPo;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private EventCamera _eventCamera;
    [SerializeField] private GameObject AddForce_Rubble;
    [SerializeField] private GameObject WallDes;    //消す壁


    private bool isEvent;
    // Start is called before the first frame update
    void Start()
    {
        isEvent = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEvent == true)
        {
            isEvent = false;
            StartCoroutine("Event");
        }
    }

    IEnumerator Event()
    {
        _enemy.SetActive(false);
        _p_CameraGl.enabled = true;
        _p_Chara.enabled = false;
        _p_Fir.enabled = false;
        yield return new WaitForSeconds(0.5f); //待つ
        AddForce_Rubble.SetActive(true);
        Destroy(WallDes);
        _enemy.transform.position = _spawnPo;
        _enemy.SetActive(true);
        yield return new WaitForSeconds(0.2f); //待つ
        _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(true);
        _p_CameraGl.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(0);
        yield return new WaitForSeconds(2.0f); //待つ
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        Destroy(gameObject);
        yield break;
    }

}
