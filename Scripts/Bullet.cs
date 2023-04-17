using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float lifetime = 5;
    private float timer = 0;
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        
        //Eliminar la bala despues de un tiempo
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
