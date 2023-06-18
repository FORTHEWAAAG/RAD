using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float speed = 10.0f;

    public Joystick joystick;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, joystick.Direction + new Vector2(transform.position.x, transform.position.y), speed * Time.deltaTime);
    }
}
