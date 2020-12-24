using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController2 : MonoBehaviour
{
    void Start()
    {
        if(this.gameObject.name.Contains("Staff"))
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
