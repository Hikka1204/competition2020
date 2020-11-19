using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror_Open : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private float _speed = 1;  //ドアのアニメーション速度
    [SerializeField] AudioClip _OpenSE;
    //[SerializeField] AudioClip _CloseSE;


    void Start()
    {
        animator = transform.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //animator.SetBool("Open", true);
        animator.speed = _speed;
    }

    void Update()
    {

    }

    public void OpenSE()    //アニメーションに関数を追加している //ドアが開く音
    {
        audioSource.clip = _OpenSE;
        audioSource.Play();
        Destroy(gameObject.GetComponent<Door_Close_anim>());
    }

    public void CloseSE()   //アニメーションに関数を追加している //ドアが閉まる音
    {
        //audioSource.clip = _CloseSE;
        audioSource.Play();
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Open", true);

        }
    }
}
