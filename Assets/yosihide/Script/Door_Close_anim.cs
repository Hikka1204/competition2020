using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Close_anim : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float _speed = 1;  //ドアのアニメーション速度

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        animator.SetBool("Open", true);
        animator.speed = _speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Open", false);
            Destroy(gameObject.GetComponent<Door_Close_anim>());
        }
    }
}
