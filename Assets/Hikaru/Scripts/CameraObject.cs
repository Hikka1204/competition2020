using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObject : MonoBehaviour
{

    public GameObject target = null;

    void Update()
    {
        // targetオブジェクトを注視する
        this.transform.LookAt(target.transform);
    }
}