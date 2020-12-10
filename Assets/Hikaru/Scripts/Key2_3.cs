using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2_3 : MonoBehaviour
{
    private bool colflg = false;
    [SerializeField] private GameObject key;    //相方のキー

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDisable()
    {
        if (key.activeSelf == false)
        {
            FlagManager.Instance.Key_Text[2] = true;
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (key.activeSelf == false && colflg == true && Input.GetKeyDown("e"))
    //    {
    //            colflg = false;
    //            FlagManager.Instance.Key_Text[2] = true;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Hand")
    //    {
    //        colflg = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Hand")
    //    {
    //        colflg = false;
    //    }
    //}


}
