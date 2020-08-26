using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public float transTime = 1;
    public void PlayGame() {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        //Play animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transTime);
        //wait

        SceneManager.LoadScene(levelIndex);
        //Load scene
    }

    public void QuitGame() {
        Debug.Log("Quit");
    }
}
