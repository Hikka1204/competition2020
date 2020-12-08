using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChair : MonoBehaviour
{
    public GameObject Chair;
    ChairBlowAway script;
    

    // Start is called before the first frame update
    void Start()
    {
        
        script = Chair.gameObject.GetComponent<ChairBlowAway>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            script.enabled = true;
            Destroy(gameObject.GetComponent<CheckChair>());
        }
    }
}
