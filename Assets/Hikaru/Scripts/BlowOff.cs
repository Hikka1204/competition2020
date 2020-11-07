using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトを吹き飛ばすスクリプト

public class BlowOff : MonoBehaviour
{
    [SerializeField]
    private float impulse = 300;

    bool isCollision = false;

    Rigidbody rigidBody;
    Rigidbody ObjectRigidBody;
    [SerializeField] private GameObject Object;
    private bool isEvent = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        //プレイヤーをタグで検索し、Rigidbodyを取得
        //Object = GameObject.FindGameObjectWithTag("Player");
        ObjectRigidBody = Object.GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (isEvent == false)
        {
            isEvent = true;
            Addforce();
        }
    }

    private void Addforce()
    {
        if (isCollision == false)
        {
            rigidBody.isKinematic = false;
            //吹っ飛ばす
            Vector3 playerVelocity = ObjectRigidBody.velocity;
            rigidBody.AddForce(playerVelocity * impulse, ForceMode.Impulse);
            rigidBody.AddForce(Vector3.back * impulse, ForceMode.Impulse);

            isCollision = true;
        }
    }

    ////衝突判定
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player" && isCollision == false)
    //    {
    //        //吹っ飛ばす
    //        Vector3 playerVelocity = ObjectRigidBody.velocity;
    //        rigidBody.AddForce(playerVelocity * impulse, ForceMode.Impulse);
    //        rigidBody.AddForce(Vector3.up * impulse, ForceMode.Impulse);

    //        isCollision = true;
    //    }
    //}
}