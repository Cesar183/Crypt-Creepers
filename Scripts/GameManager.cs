using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int difficulty = 1;
    public int time = 30;
    [SerializeField] int score;
    public int Score{
        get => score;
        set {
            score = value;
            if(score % 1000 ==0)
            {
                difficulty++;
            }
        }
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
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
        //Game Over
    }
}
