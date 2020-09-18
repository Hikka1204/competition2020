using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    byte keyFlg;    //キーのフラグ　数字で制御

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Key" && Input.GetKeyDown("e"))
        {
            Destroy(other.gameObject);
            
        }
    }

}
