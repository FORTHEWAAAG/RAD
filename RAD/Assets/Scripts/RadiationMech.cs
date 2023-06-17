using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationMech : MonoBehaviour
{
    public static bool isInRadiation = false;

    private bool isActive = false;

    public float radiationDelay = 0.5f;


    IEnumerator Radiated()
    {
        while (isActive == true)
        {
            if (PlayerChar.playerCurrentRadiation <= 75)
            {
                PlayerChar.playerCurrentRadiation += 1;
            }

            yield return new WaitForSeconds(radiationDelay);
        }
    }


    private void OnTriggerStay2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player"))
        {
            isInRadiation = true;
            //Debug.Log("isInRadiation: " + isInRadiation);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            isInRadiation = false;
            isActive = false;

            StopCoroutine(Radiated());

            //Debug.Log("isInRadiation: " + isInRadiation);
        }
    }

    private void Update()
    {
        if ((isInRadiation == true) && (isActive == false))
        {
            isActive = true;
            StartCoroutine(Radiated());
        }
    }
}
