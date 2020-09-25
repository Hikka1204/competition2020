using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip _PickUp;
    byte keyFlg;    //キーのフラグ　数字で制御

    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.root.root.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public byte GetKey()
    {
        return keyFlg;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Key" && Input.GetKeyDown("e"))
        {
            keyFlg = other.gameObject.GetComponent<Key1>().GetKey();

            audioSource.clip = _PickUp;
            audioSource.Play();
            
            Destroy(other.gameObject);
        }
    }

}
