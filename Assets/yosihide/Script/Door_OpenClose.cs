using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_OpenClose : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private float _Open_speed = 1;
    [SerializeField] private float _Close_speed = 1;//ドアのアニメーション速度
    [SerializeField] AudioClip _OpenSE;
    [SerializeField] AudioClip _CloseSE;
    private bool isEvent;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //animator.SetBool("Open", true);
        isEvent = false;
    }

    void Update()
    {

    }

    public void OpenSE()    //アニメーションに関数を追加している //ドアが開く音
    {
        audioSource.clip = _OpenSE;
        audioSource.Play();
        animator.speed = _Open_speed;
        animator.SetBool("Auto Door", false);
    }

    public void CloseSE()   //アニメーションに関数を追加している //ドアが閉まる音
    {
        audioSource.clip = _CloseSE;
        audioSource.Play();
        if (isEvent) return;
        animator.speed = _Close_speed;
        animator.SetBool("Auto Door", true);
        //Destroy(gameObject.GetComponent<Door_Close_anim>());
    }

    public void StartAnim()
    {
        animator.SetBool("Auto Door", true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //animator.SetBool("Close_Auto", true);
            isEvent = true;
            animator.SetBool("Auto Door",false);
            //Destroy(gameObject.GetComponent<Door_OpenClose>());

        }
    }

}
