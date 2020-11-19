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
        
    }

    void Update()
    {
        if(_DesRate > 0)
        {
            Anim.SetFloat("speed", Enemy_Nav.speed);
            //目的地のオブジェクトを取得
            Enemy_Nav.SetDestination(Destination.transform.position);
            _DesRate -= Time.deltaTime;
            if(_DesRate <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        
    }



}
