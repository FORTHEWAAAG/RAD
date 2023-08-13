using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackBtn : MonoBehaviour
{
    
    public Transform playerPos;

    bool isAttacking = false;
    bool stopAttacking = true;
    public List<NewWeapon> Weapons;
    public GameObject AttackSprite;


    public IEnumerator Attack()
    {
        while (isAttacking == true)
        {
            if (stopAttacking == false)
            {
                float timeBtwShots = 1.0f / Weapons[PlayerChar.currWeapon].fireRate;

                Instantiate(AttackSprite, playerPos.position, Quaternion.identity);

                yield return new WaitForSeconds(timeBtwShots);
            }
            else
            {
                isAttacking = false;

                StopCoroutine(Attack());
            }
        }
    }

    public void Update()
    {
        if (stopAttacking == false || isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
    }

    public void StartAttack()
    {
        stopAttacking = false;
    }


    public void OnMouseUpAsButton()
    {
        stopAttacking = true;
    }
}
