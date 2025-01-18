using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("Game Over", sceneLoadDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quiting game....");
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
