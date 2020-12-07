using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWheelChair : MonoBehaviour
{
    public GameObject WheelChair;
    WheelChair_Go wcg;
    WheelChair_Back wcb;

    bool Back = false;
    int Count = 0;              //何回壁にぶつかったか
    [SerializeField] int Goal;  

    private float currentTime = 0.0f;
    [SerializeField] int Go_Time;

    // Start is called before the first frame update
    void Start()
    {
        //WheelChair = GameObject.Find("Wheelchair_Gimmic");
        wcg = WheelChair.GetComponent<WheelChair_Go>();
        wcb = WheelChair.GetComponent<WheelChair_Back>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Back == true)
        {
            currentTime += Time.deltaTime;

            wcb.enabled = true;
            wcg.enabled = false;
            
            if (currentTime > Go_Time)
            {
                wcg.enabled = true;
                wcb.enabled = false;
                Back = false;
            }
            if (Count > Goal)
            {
                wcb.speeddown();
                Destroy(gameObject.GetComponent<CheckWheelChair>());
            }

        }
        if (Back == false)
        {
            currentTime = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            wcg.enabled = true;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Count++;
            Debug.Log(Count);
            Back = true;
            wcg.enabled = false;
        }
    }
}

