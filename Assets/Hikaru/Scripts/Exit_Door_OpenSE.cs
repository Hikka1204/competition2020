using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Door_OpenSE : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;
    [SerializeField] private AudioClip _OpenSE;
    [SerializeField] private AudioClip _CloseSE;
    private bool SEflg = false; //なった(TRUE)か、なってない(FALSE)か
    private float CloseRate = 4;    //閉まるまでの時間初期化用
    private float CloseTime;        //格納用
    private float DestroyRate = 2;    //デストロイするまでの時間
    private float DestroyTime;   //ブレイクするまでのカウント

    void Update()
    {

        if (CloseTime > 0)
        {
            CloseTime -= Time.deltaTime;
            if (CloseTime <= 0)
            {
                _audiosource.clip = _CloseSE;
                _audiosource.Play();
                DestroyTime = DestroyRate;
            }
        }

        if (DestroyTime > 0)
        {
            DestroyTime -= Time.deltaTime;
            if(DestroyTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" && SEflg == false)
        {
            _audiosource.clip = _OpenSE;
            _audiosource.Play();
            SEflg = true;
            CloseTime = CloseRate;
            //
        }
    }

}
