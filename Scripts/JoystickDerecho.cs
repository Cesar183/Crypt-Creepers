using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDerecho : MonoBehaviour
{
    public static JoystickDerecho sharedInstance;
    public Joystick joystick;
    public float velocidad;
    Vector2 facingDirection;
    [SerializeField] Transform aim;
    [SerializeField] Transform player;
    [SerializeField] float radius = 1f;
    void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
        facingDirection = direction;
        Vector3 newPos = transform.position + (Vector3)direction;
        Vector3 offset = newPos - player.position;
        transform.position = player.position + Vector3.ClampMagnitude(offset, radius);
    }
}
