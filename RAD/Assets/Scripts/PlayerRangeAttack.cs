using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public List<NewWeapon> Weapons;
    Vector3 targetPos;
    Vector3 startingPos;
    public float projSpeed = 5.0f;
    public SpriteRenderer currSprite;
    public Sprite weaponSprite;
    public Sprite ammoSprite;
    private float maxRange;


    public float radius = 15.0f;
    public int layer = 512;
    Collider2D[] hitColliders;
    Vector3 closestTarget;


    void Awake()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;

        SearchForTargets();
    }


    void Start() {
        Array.Clear(hitColliders, 0, hitColliders.Length);

        weaponSprite = Weapons[PlayerChar.currWeapon].weaponSprite;
        ammoSprite = Weapons[PlayerChar.currWeapon].ammoSprite;

        currSprite.sprite = ammoSprite;

        targetPos.x = closestTarget.x;
        targetPos.y = closestTarget.y;

        targetPos = startingPos + (targetPos - startingPos).normalized * 10000.0f;

        float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
        transform.Rotate(0.0f, 0.0f, angle);

        maxRange = Weapons[PlayerChar.currWeapon].maxRange;

        //Debug.Log("distance to player: " + (startingPos - closestTarget).magnitude);
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPos.x, targetPos.y), (projSpeed * Time.deltaTime));

        if((transform.position.x == targetPos.x) && (transform.position.y == targetPos.y)) {
            Destroy(gameObject);
        }

        if((startingPos - transform.position).sqrMagnitude > maxRange)
        {
            Destroy(gameObject);
        }
    }


    public void SearchForTargets()
    {
        radius = (float)Math.Sqrt(Weapons[PlayerChar.currWeapon].maxRange);

        hitColliders = Physics2D.OverlapCircleAll(startingPos, radius, layer);

        if (hitColliders.Length == 1)
        {
            float distance = (startingPos - hitColliders[0].transform.position).sqrMagnitude;
            closestTarget = hitColliders[0].transform.position;

            //Debug.Log(closestTarget);
        }
        else if (hitColliders.Length > 1)
        {
            float distance = (startingPos - hitColliders[0].transform.position).sqrMagnitude;
            closestTarget = hitColliders[0].transform.position;

            foreach (Collider2D hitCollider in hitColliders)
            {
                Debug.Log(hitCollider.name + " distance to player: " + (startingPos - hitCollider.transform.position).magnitude);

                float newDistance = (startingPos - hitCollider.transform.position).sqrMagnitude;

                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestTarget = hitCollider.transform.position;
                }
            }

            //Debug.Log(closestTarget);
            //SendMessage(PlayerChar);s
        }
    }
}
