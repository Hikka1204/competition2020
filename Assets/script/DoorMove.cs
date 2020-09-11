using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour {

    [SerializeField] private float _speed;   //動くスピード
    [SerializeField] private float _angleY;  //Yの方角
    [SerializeField] private float _waitRate;    //ドアの待機時間入力
    private float WaitTime; //待機時間
    private Transform IntObjectTr;

    // Use this for initialization
    void Start () {
        IntObjectTr = gameObject.transform;     //オブジェクトのトランスフォームの初期値を追加
	}
	
	// Update is called once per frame
	void Update () {
		if(WaitTime > 0)
        {
            WaitTime -= Time.deltaTime;
        }

	}

    

}
