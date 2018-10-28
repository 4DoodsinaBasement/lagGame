using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneJump : MonoBehaviour {

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void OnClick()
    {
        Application.Quit();
    }
}