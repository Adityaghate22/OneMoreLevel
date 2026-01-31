using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenuUI;
    public void pause()
    {
        pauseMenuUI.SetActive(true);
         Time.timeScale = 0f;
    }

    public void home()
    {          Time.timeScale = 1f;
      SceneManager.LoadScene("Main Menu");
    }
    public void resume()
    {
         Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void restart()
    {          Time.timeScale = 1f;
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
