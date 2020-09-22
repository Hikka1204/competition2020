using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nav_Enemy : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent Player_Nav;
    [SerializeField] GameObject Destination;
    private Animator anim;



    void Start()
    {
        //プレイヤーのNavMeshAgentを取得
        Player_Nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //目的地のオブジェクトを取得
        //Destination = GameObject.Find("Goal");
        anim = GetComponent<Animator>();
        anim.SetInteger("battle", 1);//walk/run/moving
        anim.SetInteger("moving", 1);//walk/run/moving
        
    }

    void Update()
    {
        //目的地を設定
        Player_Nav.SetDestination(Destination.transform.position);
    }
}
