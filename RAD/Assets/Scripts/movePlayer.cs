using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public GameObject player;

    public float speed = 10.0f;


    private void OnMouseDrag() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(mousePos.x, mousePos.y), (speed * Time.deltaTime));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            OnMouseDrag();
        }
    }
}
