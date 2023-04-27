using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    Player player;
    float originalSpeed;
    [SerializeField] float speedCambioRatio = 0.5f;
    void Start()
    {
        player = FindObjectOfType<Player>();
        originalSpeed = player.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.speed *= speedCambioRatio;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.speed = originalSpeed;
        }
    }
}
