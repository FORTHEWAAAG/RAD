using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public GameObject player;

    public float speed = 10.0f;

    public Joystick joystick;


    /*private void OnMouseDrag() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(mousePos.x, mousePos.y), (speed * Time.deltaTime));
    }*/

    void FixedUpdate()
    {
        player.transform.position = Vector2.MoveTowards(player.transform.position, joystick.Direction + new Vector2(player.transform.position.x, player.transform.position.y), speed * Time.deltaTime);
        

        /*if (Input.GetMouseButtonDown(0) == true)
        {
            OnMouseDrag();
        }*/
    }
}
