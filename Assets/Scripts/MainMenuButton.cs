using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton: MonoBehaviour
{
    public Animator transition;

    public void startGame()
    {
        StartCoroutine(LoadNextLevel(1));
    }

    IEnumerator LoadNextLevel(int idx)
    {
        transition.SetTrigger("start");

        transition.Update(0);

        yield return new WaitForSeconds(1);


        SceneManager.LoadScene(idx);
    }
}