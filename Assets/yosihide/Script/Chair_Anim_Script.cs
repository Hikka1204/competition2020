using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair_Anim_Script : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("Fall Down",true);
        }
    }
}
