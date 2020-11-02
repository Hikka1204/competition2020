using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 振動タイプ
/// </summary>
internal enum VibrateType
{
    VERTICAL,
    HORIZONTAL
}

public class VibrateController : MonoBehaviour
{
    [SerializeField] private VibrateType vibrateType;          //振動タイプ
    [Range(0, 1)] [SerializeField] private float vibrateRange; //振動幅
    [SerializeField] private float vibrateSpeed;               //振動速度

    int Nockflg;
    [SerializeField] float countRate;
    float CountTime;

    private Vector3 Position;
    private float initPosition;   //初期ポジション
    private float newPosition;    //新規ポジション
    private float minPosition;    //ポジションの下限
    private float maxPosition;    //ポジションの上限
    private bool directionToggle; //振動方向の切り替え用トグル(オフ：値が小さくなる方向へ オン：値が大きくなる方向へ)
    //private Animator animator;

    // Use this for initialization
    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator.SetBool("DoorKnockAnim", false);

        Position = gameObject.transform.position; 
        //初期ポジションの設定を振動タイプ毎に分ける
        switch (this.vibrateType)
        {
            case VibrateType.VERTICAL:
                this.initPosition = transform.position.y;
                break;
            case VibrateType.HORIZONTAL:
                this.initPosition = transform.position.x;
                break;
        }

        this.newPosition = this.initPosition;
        this.minPosition = this.initPosition - this.vibrateRange;
        this.maxPosition = this.initPosition + this.vibrateRange;
        this.directionToggle = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(CountTime);
            CountTime = countRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CountTime > 0)
        {
            CountTime -= Time.deltaTime;
            if (CountTime <= 0)
            {
                switch (Nockflg)
                {
                    case 0:
                        CountTime = countRate;
                        Vibrate();
                        Nockflg++;
                        break;

                    case 1:
                        CountTime = countRate;
                        Vibrate();
                        Nockflg++;
                        break;

                    case 2:
                        CountTime = countRate;
                        Vibrate();
                        Nockflg++;
                        break;
                }

            }

        }

    }

    private void Vibrate()
    {

        //ポジションが振動幅の範囲を超えた場合、振動方向を切り替える
        if (this.newPosition <= this.minPosition ||
            this.maxPosition <= this.newPosition)
        {
            this.directionToggle = !this.directionToggle;
        }

        //新規ポジションを設定
        this.newPosition = this.directionToggle ?
            this.newPosition + (vibrateSpeed * Time.deltaTime) :
            this.newPosition - (vibrateSpeed * Time.deltaTime);
        this.newPosition = Mathf.Clamp(this.newPosition, this.minPosition, this.maxPosition);

        //新規ポジションを代入
        switch (this.vibrateType)
        {
            case VibrateType.VERTICAL:
                this.transform.position = new Vector3(Position.x, this.newPosition, Position.z);
                break;
            case VibrateType.HORIZONTAL:
                this.transform.position = new Vector3(this.newPosition, Position.y, Position.z);
                break;
        }

        
    }
}
