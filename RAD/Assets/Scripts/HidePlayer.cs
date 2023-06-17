using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    public static bool isInHideout = false;

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player")
        {
            isInHideout = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            isInHideout = false;
        }
    }
}
