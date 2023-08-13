using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBtn : MonoBehaviour
{
    
    public Transform playerPos;
    public float radius = 15.0f;

    public int layer = 0;

    Collider2D[] hitColliders;
    Vector3 closestTarget;


    bool isAttacking = false;
    bool stopAttacking = true;
    public List<NewWeapon> Weapons;
    public GameObject AttackSprite;

    public PlayerRangeAttack projectile;


    public void SearchForTargets()
    {
        hitColliders = Physics2D.OverlapCircleAll(playerPos.position, radius, layer);

        if (hitColliders.Length == 1)
        {
            float distance = (playerPos.position - hitColliders[0].transform.position).sqrMagnitude;
            closestTarget = hitColliders[0].transform.position;

            Debug.Log(closestTarget);
        }
        else if (hitColliders.Length > 1)
        {
            float distance = (playerPos.position - hitColliders[0].transform.position).sqrMagnitude;
            closestTarget = hitColliders[0].transform.position;

            foreach (Collider2D hitCollider in hitColliders)
            {
                //Debug.Log(hitCollider.name + " distance to player: " + (playerPos.position - hitCollider.transform.position).sqrMagnitude);

                float newDistance = (playerPos.position - hitCollider.transform.position).sqrMagnitude;

                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestTarget = hitCollider.transform.position;
                }
            }

            //Debug.Log(closestTarget);
            //SendMessage(PlayerChar);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerPos.position, radius);
    }
}
