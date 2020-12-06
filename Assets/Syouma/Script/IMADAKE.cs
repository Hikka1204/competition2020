using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMADAKE : MonoBehaviour
{
    bool flg = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!flg)
            {
                this.GetComponent<GlitchEffect>().enabled = true;
                flg = true;

            }
            else
            {
                this.GetComponent<GlitchEffect>().enabled = false;
                flg = false;

            }
        }
    }
}
