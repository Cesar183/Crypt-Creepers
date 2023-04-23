using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h, v;
    Vector3 moveDirection;
    Vector2 facingDirection;
    public float speed = 6;
    [SerializeField] Transform aim;
    //[SerializeField] Camera camera;
    [SerializeField] Transform bulletPrefab;
    bool gunLoaded = true;
    [SerializeField] float fireRate = 2;
    [SerializeField] int health = 10;
    bool powerShotEnabled;
    [SerializeField] bool invulnerable;
    [SerializeField] float invulnerableTime = 3;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer spriteRenderer;
    public int Health{
        get => health;
        set{
            health = value;
            UIManager.sharedInstance.UpdaeUIHealth(health);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;
        transform.position += moveDirection * Time.deltaTime * speed;

        //Movimiento de la mira desde el mouse
        //facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //aim.position = transform.position + (Vector3)facingDirection.normalized;

        //if(Input.GetMouseButtonDown(0))
        float movX = JoystickDerecho.sharedInstance.joystick.Horizontal;
        float movY = JoystickDerecho.sharedInstance.joystick.Vertical;
        float angle = Mathf.Atan2(movY, movX) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        if (JoystickDerecho.sharedInstance.joystick.Direction != Vector2.zero && gunLoaded) //Input.GetMouseButton(0) || 
        {
            gunLoaded = false;
            Transform bulletclone = Instantiate(bulletPrefab, transform.position, targetRotation);
            if(powerShotEnabled)
            {
                bulletclone.GetComponent<Bullet>().powerShot = true;
            }
            StartCoroutine(ReloadGun());
        }
        anim.SetFloat("Speed", moveDirection.magnitude);
        if(aim.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if(aim.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }
    public void TakeDamage()
    {
        if(invulnerable)
        {
            return;
        }
        Health--;
        invulnerable = true;
        StartCoroutine(MakeVulnerableAgain());
        if(Health <= 0)
        {
            GameManager.sharedInstance.gameOver = true;
            UIManager.sharedInstance.ShowGameOverScreen();
        }
    }
    IEnumerator MakeVulnerableAgain()
    {
        yield return new WaitForSeconds(invulnerableTime);
        invulnerable = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PowerUp")
        {
            switch(collision.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.FireRateIncrease:
                    //Incrementar cadencia de diparo
                    fireRate++;
                    break;
                case PowerUp.PowerUpType.PowerShot:
                    //Activar super disparo
                    powerShotEnabled = true;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}
