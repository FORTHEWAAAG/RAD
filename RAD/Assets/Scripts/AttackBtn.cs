using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class AttackBtn : Button
{
    
    public Transform playerPos;

    bool isAttacking = false;
    bool stopAttacking = true;
    public List<NewWeapon> Weapons;
    public GameObject AttackSprite;

    Collider2D[] hitColliders;
    public float radius = 15.0f;
    public int layer = 512;


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
        if (stopAttacking == false && isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {     
        radius = (float)Math.Sqrt(Weapons[PlayerChar.currWeapon].maxRange);

        hitColliders = Physics2D.OverlapCircleAll(playerPos.position, radius, layer);

        if (hitColliders.Length != 0)
        {
            stopAttacking = false;
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        stopAttacking = true;
    }
}
