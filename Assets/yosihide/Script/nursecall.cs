using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nursecall : MonoBehaviour
{

    //効果音の設定
    public AudioClip NurseCallSE;
    [SerializeField] private AudioSource _NurseCall;
    private bool NurseFlg = false;  //なってないか、なったか
    private bool colflg = false;

    private void Update()
    {
        if (NurseFlg == false && colflg == true && Input.GetKeyDown("e"))
        {
            FlagManager.Instance.SerifFlg[0] = true; // 「鍵がかかっているようだ」を表示
            FlagManager.Instance.Co_Hint[1] = true; // コメント「何かなってるぞ」を表示
            _NurseCall.GetComponent<AudioSource>().clip = NurseCallSE;
            _NurseCall.GetComponent<AudioSource>().Play();
            //Destroy(GetComponent<nursecall>());
            NurseFlg = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            colflg = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            colflg = false;
        }
    }
    
}
