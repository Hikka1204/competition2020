using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WillRenderObj : MonoBehaviour
{
    [SerializeField] Material M_BloodHand;
    [SerializeField] private float _SpawnRate = 1f;
    //MeshRenderer meshRe;
    int cameraNum;

    void Start()
    {
        //meshRe = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        ShowText(cameraNum);
        cameraNum = 0;
    }

    void OnWillRenderObject()
    {
        //Debug.Log(Camera.current.name);
        if (Camera.current.name == "SceneCamera")
            cameraNum++;
        if (Camera.current.name == "FirstPersonCharacter")
            cameraNum += 2;
    }

    // 以下はサンプルのUI表示用
    //[SerializeField]
    //Text uiText;

    void ShowText(int num)
    {
        switch (num)
        {
            case 0:
                //uiText.text = "映ってないよ";
                break;
            case 1:
                //uiText.text = "シーンカメラに映ってるよ";
                break;
            case 2:
                //uiText.text = "メインカメラに映ってるよ";
                StartCoroutine("SpawnHand");
                break;
            case 3:
                //uiText.text = "両方のカメラに映ってるよ";
                StartCoroutine("SpawnHand");
                break;
        }
    }
    
    IEnumerator SpawnHand()
    {
        yield return new WaitForSeconds(_SpawnRate); //1秒待って
        gameObject.GetComponent<MeshRenderer>().material = M_BloodHand;
    }
}