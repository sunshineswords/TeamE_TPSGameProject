using UnityEngine;
using UnityEngine.SceneManagement;

public class ChengeScene_Gabu : MonoBehaviour
{
    public void ChengeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
