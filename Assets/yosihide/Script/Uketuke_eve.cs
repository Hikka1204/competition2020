using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uketuke_eve : MonoBehaviour
{
    private GameObject Key1;
    public Text Uketuke;
    [SerializeField] private float _notActivRate = 5;
    private float NotActivTime;


    void Start()
    {
        Uketuke = GameObject.Find("Text").GetComponent<Text>();
        Uketuke.enabled = false;
        Key1 = GameObject.Find("rust_key");
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(NotActivTime > 0)
        {
            NotActivTime -= Time.deltaTime;
            if (NotActivTime <= 0) Destroy(gameObject);
        }
        
        //オブジェクトの個数(count)が0になった時
        if(Input.GetKeyDown("e")&& Key1 ==null && Uketuke.gameObject.activeInHierarchy != true)
        //if(Destroy(obj))
        {
            Uketuke.enabled = true;
            NotActivTime = _notActivRate;
        }
        
    }
    
    
}
