using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentekibou : MonoBehaviour
{
    Transform target;
    float speed = 300f;
    [SerializeField]
    private float m_torqueForce = 0.0f;
    private Rigidbody m_rigidbody = null;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        target = GameObject.Find("TentekiBou").transform;
        
    }

    void ControlObject()
    {
        if(Input.GetKeyDown("n"))
        {
            Topple(transform.forward);
        }
    }

    void Update()
    {
        
        //float step = speed * Time.deltaTime;

        ////指定した方向にゆっくり回転する場合
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90f, 0, 0), step);
    }

    void Topple(Vector3 i_forwad)
    {
        Vector3 rightVec = transform.right;
        Vector3 torque = rightVec * m_torqueForce;

        m_rigidbody.AddTorque(torque, ForceMode.Force);
    }
}
