using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    float alfa;
    private float speed = 0.005f;
    float red, green, blue;
    float count;

    void Start()
    {
        red = GetComponent<Text>().color.r;
        green = GetComponent<Text>().color.g;
        blue = GetComponent<Text>().color.b;
    }

    void Update()
    {
        GetComponent<Text>().color = new Color(red, green, blue, alfa);
        //alfa += speed;
        count += speed;
        alfa = Mathf.Abs(Mathf.Sin(count));
    }
}