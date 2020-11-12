using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    Ray ray;        //レイ
    RaycastHit Rayhit; //ヒットしたオブジェクト情報
    public float distance = 1f; // 飛ばす&表示するRayの長さ
    int layerMask = 0;

    [SerializeField] GameObject TextUI;

    void Start()
    {
        layerMask = LayerMask.GetMask(new string[] { "Key", "Door" });
    }

    void Update()
    {
        //レイの設定
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Rayhit = new RaycastHit();

        
        if (Physics.Raycast(ray, out Rayhit, distance, layerMask))
        {
            switch (Rayhit.collider.gameObject.tag)
            {
                case "Key":
                    TextUI.GetComponent<Text>().text = "[E]拾う";
                    break;
                case "Door":
                    TextUI.GetComponent<Text>().text = "「E」開く";
                    break;
            }

        }
        else// Ray上に何もない時
        {
            TextUI.GetComponent<Text>().text = "";
        }
        //レイを可視化
        Debug.DrawRay(ray.origin, ray.direction* distance, Color.red);
    }
}
