using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [SerializeField] Text finalScore;
    public GameObject gameOverScreen;
    
    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    public void UpdateUIScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
    public void UpdaeUIHealth(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }
    public void UpdateUITime(int newTime)
    {
        timeText.text = newTime.ToString();
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        finalScore.text = "SCORE: " + GameManager.sharedInstance.Score;
    }
    void Start()
    {
        
    }
}
