using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    [Range(0.01f, 1f)] public float Zoom_Speed; // ズームの速度を変更できる
    public float Zoom_Time; // ズームしている時間を変更できる
    public float Zoom_View;   // ズームする距離を変更できる

    const float MaxView = 50f; // 元の視野角
    public bool Zoomflg = false; // true=ズームイン、false=ズームアウト

    [SerializeField] private CameraObject _cameraObj;

    GameObject CameraOBJ; // カメラそのものが入る変数
    CameraControllerFPS CameraController; // CameraControllerFPSが入る変数
    bool g_FOVflg;

    void Start()
    {
        cam = this.GetComponent<Camera>();
        zoom -= Zoom_Speed;
        Zoomflg = false;

        CameraOBJ = GameObject.Find("FirstPersonCharacter");
        CameraController = CameraOBJ.GetComponent<CameraControllerFPS>();

    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Q)) Zoomflg = true;

        if (Zoomflg){
            Invoke("ZoomStart",1);
        }
        else{
            cam.fieldOfView -= zoom; // JOJOにズームアウトしている
        }

        // 最小値と最大値を決める
        if (cam.fieldOfView < Zoom_View)
        {
            cam.fieldOfView = Zoom_View;
            Invoke("ZoomOut", Zoom_Time);
        }

        if (cam.fieldOfView > MaxView)
        {
            cam.fieldOfView = MaxView;
            CameraController.g_FOVflg = true; // Fov値を固定化
        }
    }
    
    void ZoomStart()
    {
        cam.fieldOfView += zoom; // JOJOにズームインしている
        CameraController.g_FOVflg = false; // Fov値を固定化解除
        _cameraObj.enabled = true;
    }

    void ZoomOut()
    {
        Zoomflg = false; // ズームアウト開始のフラグ
        _cameraObj.enabled = false;
    }
}
