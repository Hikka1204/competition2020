using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    Transform target;
    float speed = 400f;
    //GameObject DPivot;

    void Start()
    {
        target = GameObject.Find("Door").transform;
    }

    void Update()
    {
        Debug.Log(this.transform.rotation.y);
        float step = speed * Time.deltaTime;

        //指定した方向にゆっくり回転する場合
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, 25f, 0), step);
    }
}
