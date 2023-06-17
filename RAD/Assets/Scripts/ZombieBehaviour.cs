using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public GameObject Target;              // TARGET

    public GameObject SlashAttack;          // ATTACK
    private bool isInAttackRange = false;   // ATTACK
    private bool isAttacking = false;
    private bool stopAttacking = false;

    public float aggrRange = 4.0f;          // AGGR
    private bool isAggred = false;          // AGGR

    public float speed = 2.0f;              // ZOMBIE
    Vector2 startingPos;                    // ZOMBIE


    public ZombieNPC Zombie;
    public int healthOffset = 10;

    private void Start() {
        Target = GameObject.FindGameObjectWithTag("Player");

        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;

        Zombie.maxHealth += healthOffset;
    }


    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            isInAttackRange = true;
        }
    }


    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            isInAttackRange = false;
        }
    }


    private bool IsAggred() {
        if ((transform.position - Target.transform.position).sqrMagnitude <= (aggrRange * aggrRange))
        {
            isAggred = true;
        }
        else
        {
            if (HidePlayer.isInHideout == true)
            {
                isAggred = false;
            }
        }

        return isAggred;
    }


    IEnumerator MeleeAttack()
    {
        while (isAttacking == true)
        {
            if (stopAttacking == false)
            {
                Instantiate(SlashAttack, (transform.position + (Target.transform.position - transform.position).normalized * 0.65f), Quaternion.identity);

                yield return new WaitForSeconds(1.0f);
            }
            else
            {
                isAttacking = false;
                StopCoroutine(MeleeAttack());
            }
        }
    }

    private void Update() {

        if (IsAggred() == true)
        {
            if (isInAttackRange == true)
            {
                if (isAttacking == false)
                {
                    isAttacking = true;
                    stopAttacking = false;

                    StartCoroutine(MeleeAttack());
                }
            }
            else
            {
                stopAttacking = true;

                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, (speed * Time.deltaTime));
            }
        }
        else
        {
            if ((transform.position.x != startingPos.x) && (transform.position.y != startingPos.y))
            {
                transform.position = Vector2.MoveTowards(transform.position, startingPos, (speed * Time.deltaTime));
            }
        }
    }
}
