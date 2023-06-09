using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public int difficulty = 1;
    public int time = 30;
    public bool gameOver;
    [SerializeField] int score;
    [SerializeField] AudioClip audioButton;
    public int Score{
        get => score;
        set {
            score = value;
            UIManager.sharedInstance.UpdateUIScore(score);
            if(score % 1000 ==0)
            {
                difficulty++;
            }
        }
    }
    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    void Start()
    {
        StartCoroutine(CountdownRoutine());
        UIManager.sharedInstance.UpdateUIScore(score);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator CountdownRoutine()
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            UIManager.sharedInstance.UpdateUITime(time);
        }
        gameOver = true;
        SceneManager.LoadScene("GameOver");
    }
    public void PlayAgain()
    {
        UIManager.sharedInstance.gameOverScreen.SetActive(false);
        AudioSource.PlayClipAtPoint(audioButton, transform.position);
        SceneManager.LoadScene("Game");
    }
    public void PlayGame()
    {
        //UIManager.sharedInstance.menuScreen.SetActive(false);
        AudioSource.PlayClipAtPoint(audioButton, transform.position);
        SceneManager.LoadScene("Game");
    }
    public void MenuGame()
    {
        AudioSource.PlayClipAtPoint(audioButton, transform.position);
        SceneManager.LoadScene("MenuScene");
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
