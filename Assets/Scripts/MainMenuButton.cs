using System;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton: MonoBehaviour
{
    public Animator transition;

    public string nextScene;

    public void startGame()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        transition.SetTrigger("start");

        transition.Update(0);

        yield return new WaitForSeconds(1);


        SceneManager.LoadScene(nextScene);
    }
}