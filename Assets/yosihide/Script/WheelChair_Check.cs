using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChair_Check : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float angle_x;
    [SerializeField] private float angle_z;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Transform mytransform = this.transform;
        Vector3 now = rb.position;
        now -= new Vector3(angle_x, 0.0f, angle_z);
        rb.position = now;
    }
}
