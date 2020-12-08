using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnToiletDoorMove : MonoBehaviour
{

    private Door_OpenClose _doc;
    private OnToiletDoorMove _OnToDoMo;
    [SerializeField] private GameObject Door_Gimmick;

    // Start is called before the first frame update
    void Start()
    {
        _doc = Door_Gimmick.GetComponent<Door_OpenClose>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _doc.StartAnim();
            gameObject.SetActive(false);
        }
    }

}
