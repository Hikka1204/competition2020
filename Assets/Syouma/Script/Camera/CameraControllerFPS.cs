using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Camera))]
public class CameraControllerFPS : MonoBehaviour
{
    [Header("Position/Rotation Attenuation")]
    public bool EnableAtten = true;
    public float PositionAttenRate = 3.0f;
    public float RotationAttenRate = 40.0f;
    public float ForwardDistance = 0.5f;

    [Header("Noise")]
    public bool EnableNoise = true;
    public float NoiseSpeed = 0.5f;
    public float MoveNoiseSpeed = 1.5f;
    public float NoiseCoeff = 1.3f;
    public float MoveNoiseCoeff = 2.5f;

    [Header("FoV Attenuation")]
    public bool EnableFieldOfViewAtten = true;
    public float FieldOfView = 50.0f;
    public float MoveFieldOfView = 60.0f;

    private new Camera camera;
    private Transform cameraTransform;
    private float previousFov;
    private Vector3 previousCameraPosition;
    private Quaternion previousCameraRotation;
    private Vector3 expectedCameraPosition;
    private Quaternion expectedCameraRotation;

    private Transform playerTransform;
    private Vector3 previousPlayerPosition;

    private Vector3 addForward;

    private Coroutine revertCameraTransformToExpectedCoroutine;

    // Use this for initialization
    private void Start()
    {
        camera = GetComponent<Camera>();
        cameraTransform = camera.transform;

        // 念のため親階層にFirstPersonControllerがあるか確認する
        MonoBehaviour fpsController = cameraTransform.GetComponentInParent<FirstPersonController>();
        if (fpsController == null)
        {
            fpsController = cameraTransform.GetComponentInParent<RigidbodyFirstPersonController>();
            if (fpsController == null)
            {
                Debug.LogError("FirstPersonController not found.");
                enabled = false;
                return;
            }
        }

        // FirstPersonControllerを持っているオブジェクトをプレイヤーオブジェクトとして扱う
        playerTransform = fpsController.transform;

        // それぞれの前フレームデータに初期値をセットする
        previousPlayerPosition = playerTransform.position;
        previousFov = FieldOfView;
        previousCameraPosition = cameraTransform.position;
        previousCameraRotation = cameraTransform.rotation;

        // 各フレームのレンダリング後にカメラ位置・回転の変更を取り消すためのコルーチンを始動する
        revertCameraTransformToExpectedCoroutine = StartCoroutine(RevertCameraTransformToExpected());
    }

    private IEnumerator RevertCameraTransformToExpected()
    {
        var wait = new WaitForEndOfFrame();
        while (true)
        {
            yield return wait;

            if (cameraTransform == null)
            {
                StopCoroutine(revertCameraTransformToExpectedCoroutine);
                revertCameraTransformToExpectedCoroutine = null;
                yield break;
            }

            cameraTransform.position = expectedCameraPosition;
            cameraTransform.rotation = expectedCameraRotation;
        }
    }

    // LateUpdate is called once per frame after Update
    private void LateUpdate()
    {
        // まずFirstPersonControllerが設定したカメラの位置・回転を保存しておく
        // 次のフレームでFirstPersonControllerが正しくカメラをコントロールできるようにするため、
        // レンダリング後に上記のRevertCameraTransformToExpectedで位置・回転を元に戻すようにする
        expectedCameraPosition = cameraTransform.position;
        expectedCameraRotation = cameraTransform.rotation;

        // このフレームでのプレイヤーの移動量を求めておく
        var currentPlayerPosition = playerTransform.position;
        var playerDeltaPosition = currentPlayerPosition - previousPlayerPosition;

        // 減衰
        var currentCameraPosition = expectedCameraPosition;
        if (EnableAtten)
        {
            addForward += playerDeltaPosition * (Time.deltaTime * ForwardDistance * 20.0f);
            addForward = Vector3.Lerp(addForward, Vector3.zero, Time.deltaTime * PositionAttenRate);
            currentCameraPosition = Vector3.Lerp(
                previousCameraPosition,
                currentCameraPosition + addForward,
                Time.deltaTime * PositionAttenRate);
        }

        // 手ブレ
        var move = playerDeltaPosition.sqrMagnitude > 0.0f;
        var noise = new Vector3();
        if (EnableNoise)
        {
            var ns = move ? MoveNoiseSpeed : NoiseSpeed;
            var nc = move ? MoveNoiseCoeff : NoiseCoeff;
            var t = Time.time * ns;
            var nx = Mathf.PerlinNoise(t, t) * nc;
            var ny = Mathf.PerlinNoise(t + 10.0f, t + 10.0f) * nc;
            var nz = Mathf.PerlinNoise(t + 20.0f, t + 20.0f) * nc * 0.5f;
            noise = new Vector3(nx, ny, nz);
        }

        // FoV
        var currentFov = move ? MoveFieldOfView : FieldOfView;
        if (EnableFieldOfViewAtten)
        {
            currentFov = Mathf.Lerp(previousFov, currentFov, Time.deltaTime);
        }

        // カメラ向き
        var currentCameraRotation = expectedCameraRotation * Quaternion.Euler(noise);
        if (EnableAtten)
        {
            currentCameraRotation = Quaternion.Slerp(
                previousCameraRotation,
                currentCameraRotation,
                Time.deltaTime * RotationAttenRate);
        }

        // カメラの位置・回転・FoVに修正を加える
        transform.position = currentCameraPosition;
        transform.rotation = currentCameraRotation;
        camera.fieldOfView = currentFov;

        // 次のフレームに備えて現フレームのデータを保存しておく
        previousPlayerPosition = currentPlayerPosition;
        previousFov = currentFov;
        previousCameraPosition = currentCameraPosition;
        previousCameraRotation = currentCameraRotation;
    }
}