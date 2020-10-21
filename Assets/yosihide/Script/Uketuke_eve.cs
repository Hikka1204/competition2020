using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uketuke_eve : MonoBehaviour
{
    private GameObject Key1;
    public Text Uketuke;
    
    void Start()
    {
        Uketuke = GameObject.Find("Text").GetComponent<Text>();
        Uketuke.enabled = false;
        Key1 = GameObject.Find("rust_key");
        gameObject.SetActive(false);
    }

    void Update()
    {
        
        //オブジェクトの個数(count)が0になった時
        if(Input.GetKeyDown("e")&& Key1 ==null)
        //if(Destroy(obj))
        {
            Uketuke.enabled = true;
            
        }
        
    }
    
    
}
