using UnityEngine;

public class Example : MonoBehaviour
{
    // 回転の中心になるオブジェクト
    [SerializeField] private Transform target;
    // 回転速度
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float stopRate = 5.0f;
    private bool isEvent = true;

    void Update()
    {
        if(stopRate > 0)
        {
            stopRate -= Time.deltaTime;
            if(stopRate <= 0)
            {
                isEvent = false;
            }
        }
        if (isEvent)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
    }
}