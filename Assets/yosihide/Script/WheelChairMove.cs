using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMove : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float angle_x;
    [SerializeField] private float angle_z;

    GameObject WheelChair;
    WheelChair_Check wcc;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        WheelChair = GameObject.Find("Wheelchair");
        wcc = WheelChair.GetComponent<WheelChair_Check>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Transform mytransform = this.transform;
        Vector3 now = rb.position;
        now += new Vector3(angle_x, 0.0f, angle_z);
        rb.position = now;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            wcc.enabled = true;
        }
    }
}
