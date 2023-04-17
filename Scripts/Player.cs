using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h, v;
    Vector3 moveDirection;
    Vector2 facingDirection;
    [SerializeField] float speed = 6;
    [SerializeField] Transform aim;
    //[SerializeField] Camera camera;
    [SerializeField] Transform bulletPrefab;
    bool gunLoaded = true;
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
            Instantiate(bulletPrefab, transform.position, targetRotation);
            StartCoroutine(ReloadGun());
        }
    }
    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1);
        gunLoaded = true;
    }
    
}
