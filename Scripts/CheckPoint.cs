using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int addTime = 10;
    [SerializeField] AudioClip collectCheckPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.sharedInstance.time += addTime;
            AudioSource.PlayClipAtPoint(collectCheckPoint, transform.position);
            Destroy(gameObject);
        }
    }
}
