using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Intance;
    [SerializeField] int time = 30;
    private void Awake()
    {
        if(Intance == null)
        {
            Intance = this;
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
