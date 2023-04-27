using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] Text finalScore;
    void Start()
    {
        finalScore.text = "" + GameManager.sharedInstance.Score;
    }
    public void ShowGameOverScreen()
    {
        SceneManager.LoadScene("GameOver");
    }
}
