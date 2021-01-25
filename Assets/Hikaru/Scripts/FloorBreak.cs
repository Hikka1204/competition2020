using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FloorBreak : MonoBehaviour
{
    private AudioSource audio;
    private bool isEvent = false;
    private Vector3 IntPo;
    private GameObject[] Child = new GameObject[7];
    private Vector3[] IntPoChild = new Vector3[7];
    [SerializeField] FlgManeger flgManeger;

    private void Start()
    {
        
        audio = GetComponent<AudioSource>();
        isEvent = false;
        IntPo = transform.position;
        
    }

    private void OnEnable()
    {
            if (isEvent)
            {
                isEvent = false;
                transform.position = IntPo;
                for (int i = 0; i < 7; i++)
                {
                    Child[i].transform.parent = gameObject.transform;
                    gameObject.transform.GetChild(i).gameObject.transform.position = IntPoChild[i];
                }

                gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r =>
                {
                    r.isKinematic = true;
                    r.transform.SetParent(gameObject.transform);
                    r.gameObject.SetActive(false);
                });

                return;

            }

        
    }

    public void destroyObject()
    {
        
        var random = new System.Random();
        var min = -3;
        var max = 3;
        gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r => {
            r.gameObject.SetActive(true);
            r.isKinematic = false;
            r.transform.SetParent(null);
            //r.gameObject.AddComponent<AutoDestroy>().time = 2f;
            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
            r.AddForce(vect, ForceMode.Impulse);
            r.AddTorque(vect, ForceMode.Impulse);
        });
        audio.Play();
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flgManeger.FloorBreak_getFlg();
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                Child[i] = gameObject.transform.GetChild(i).gameObject;
                IntPoChild[i] = Child[i].transform.position;
            }
            FlagManager.Instance.Co_Event[4] = true; // イベントコメント表示
            isEvent = true;
            destroyObject();
        }
    }


}
