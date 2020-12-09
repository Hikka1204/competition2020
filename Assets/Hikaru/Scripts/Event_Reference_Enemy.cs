using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Event_Reference_Enemy : MonoBehaviour
{
    NavMeshAgent Enemy_Nav;     //このオブジェクトについてるナビメッシュ
    [SerializeField] GameObject Destination;
    private Animator Anim;      //アニメーション格納
    private Staging_Enemy StaEne;
    [SerializeField] private float _DesRate = 3f;
    private bool isEvent = false;
    void Start()
    {
        ////目的地のオブジェクトを取得
        //Enemy_Nav.SetDestination(Destination.transform.position);
        //プレイヤーのNavMeshAgentを取得
        Enemy_Nav = GetComponent<NavMeshAgent>();
        //Destination = GameObject.Find("Goal");
        Anim = GetComponent<Animator>();
        //Script格納
        StaEne = gameObject.GetComponent<Staging_Enemy>();
        isEvent = false;
        Enemy_Nav.SetDestination(gameObject.transform.position);
    }

    private void OnEnable()
    {
        if (isEvent)
        {
            isEvent = false;
        }
    }

    void Update()
    {
        if (isEvent)
        {
            if (_DesRate > 0)
            {
                Anim.SetFloat("speed", Enemy_Nav.speed);
                //目的地のオブジェクトを取得
                Enemy_Nav.SetDestination(Destination.transform.position);
                _DesRate -= Time.deltaTime;
                if (_DesRate <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void StartEvent()
    {
        isEvent = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
