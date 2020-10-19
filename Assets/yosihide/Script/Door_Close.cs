using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Close : MonoBehaviour
{
    Transform target;
    float speed = 400f;
    //[SerializeField] float currenttime;
    float targettime = 4.0f;
    //GameObject DPivot;

    void Start()
    {
        target = GameObject.Find("DoorPivot (1)").transform;
    }

    void Update()
    {
        //currenttime += currenttime + Time.deltaTime;
        //Debug.Log(this.transform.rotation.y);
        float step = speed * Time.deltaTime;

        //指定した方向にゆっくり回転する場合
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, 25f, 0), step);

        //if (targettime < currenttime)
        //{
        //    this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, -90f, 0), step);
        //}
    }
}
