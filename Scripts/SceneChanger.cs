using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] AudioClip audioButton;
    public void SceneGame()
    {
        AudioSource.PlayClipAtPoint(audioButton, transform.position);
        Invoke("LoadGameScene", 0.3f);
    }
    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void SceneMenu()
    {
        AudioSource.PlayClipAtPoint(audioButton, transform.position);
        Invoke("LoadMenuScene", 0.3f);
    }
    void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void SceneGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void ExitGame()
    {
        AudioSource.PlayClipAtPoint(audioButton, transform.position);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
