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
        if (Input.GetKey(KeyCode.Escape)) Quit();
        if (Input.GetKey(KeyCode.R)) RetryButton();
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