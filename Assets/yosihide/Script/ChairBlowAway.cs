using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairBlowAway : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _rb_Y = 0.05f;
    [SerializeField] private float angle_x = 10f;
    [SerializeField] private float angle_y = 0.0f;
    [SerializeField] private float angle_z = 0.0f;

    private AudioSource audioSource;
    [SerializeField] AudioClip WallHitSE;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Vector3 now = rb.position;
        //now += new Vector3(-0.2f, 0.0f, 0.0f);
        //rb.position = now;
    }

    private void FixedUpdate()
    {
        // transformを取得
        Transform myTransform = this.transform;
        //回転を加える
        myTransform.Rotate(angle_x, angle_y, angle_z);
        
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 now = rb.position;
        now += new Vector3(-0.2f, _rb_Y, 0.0f);
        rb.position = now;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            audioSource.PlayOneShot(WallHitSE);
            Destroy(gameObject.GetComponent<ChairBlowAway>());
        }
    }
}
