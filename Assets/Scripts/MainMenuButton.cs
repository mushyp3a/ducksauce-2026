using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton: MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(0);
    }
}