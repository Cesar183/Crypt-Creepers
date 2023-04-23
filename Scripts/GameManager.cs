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
        }
        gameOver = true;
        UIManager.sharedInstance.ShowGameOverScreen();
    }
    public void PlayAgain()
    {
        UIManager.sharedInstance.gameOverScreen.SetActive(false);
        SceneManager.LoadScene("Game");
    }
}
