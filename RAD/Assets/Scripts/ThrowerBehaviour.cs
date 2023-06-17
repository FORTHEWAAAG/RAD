using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerBehaviour : MonoBehaviour
{
    public GameObject Target;              // TARGET

    public GameObject spitAttack;           // ATTACK
    public float attackCooldown = 0.5f;     // ATTACK
    public float attackRange = 3.0f;        // ATTACK
    private bool isInAttackRange = false;   // ATTACK
    private bool isCoroutineRunning = false;    // ATTACK
    
    private bool isAggred = false;          // AGGR CHECK
    public float aggrRange = 4.0f;          // AGGR RANGE
    
    public float speed = 2.0f;              // THROWER
    Vector2 startingPos;                    // THROWER

    public ZombieNPC Thrower;
    public int healthOffset = -5;


    private void Start() {
        Target = GameObject.FindGameObjectWithTag("Player");

        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;

        Thrower.maxHealth += healthOffset;
    }


    IEnumerator Attack() {

        while(isCoroutineRunning == true) {

            yield return new WaitForSeconds(attackCooldown);
            Instantiate(spitAttack, transform.position, Quaternion.identity);
        }
    }


    private bool IsInAttackRange() {

        if ((transform.position - Target.transform.position).sqrMagnitude <= (attackRange * attackRange))
        {
            isInAttackRange = true;
        }
        else
        {
            isInAttackRange = false;
        }

        return isInAttackRange;
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


    private void Update() {

        if (IsAggred() == true)
        {
            if (IsInAttackRange() == false)
            {
                StopAllCoroutines();
                isCoroutineRunning = false;

                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, (speed * Time.deltaTime));
            }
            else
            {
                if (isCoroutineRunning == false)
                {
                    isCoroutineRunning = true;
                    StartCoroutine(Attack());
                }
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
