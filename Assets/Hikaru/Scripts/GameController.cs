using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    string sceneName;

    private void Start()
    {
        Cursor.visible = false;
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P)) Quit();
        if (Input.GetKey(KeyCode.K)) Ro();
        if (Input.GetKey(KeyCode.O)) RetryButton();
    }

    void Ro()
    {
        float x = 90;
        this.transform.Rotate(0.0f, 0.0f, x);
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

    void RetryButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}