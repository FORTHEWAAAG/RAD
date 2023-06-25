using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour
{
    public Vector3 posA;
    public Vector3 posB;
    public float speed = 1000f;

    private bool isMoving = false;


    private IEnumerator Move(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return new WaitForSeconds(0.03f);
        }

        isMoving = false;

        StopCoroutine("Move");
    }

    void Update()
    {
        if ((Inventory.isInventoryOpen == true) && (isMoving == false) && (transform.position != posB))
        {
            isMoving = true;
            StartCoroutine(Move(posB));
        }

        if ((Inventory.isInventoryOpen == false) && (isMoving == false) && (transform.position != posA))
        {
            isMoving = true;
            StartCoroutine(Move(posA));
        }
    }
}
