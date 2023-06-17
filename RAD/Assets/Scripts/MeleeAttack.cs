using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject Target;
    Vector3 targetPos;

    public int damage = 5;

    public float attackDuration = 0.5f;

    private bool attacking = false;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");

        targetPos.x = Target.transform.position.x;
        targetPos.y = Target.transform.position.y;

        float angle = Vector3.SignedAngle(transform.up, targetPos - transform.position, transform.forward);
        transform.Rotate(0.0f, 0.0f, angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerChar.playerCurrentHealth -= damage;
        }
    }

    IEnumerator AttackLifeSpan()
    {
        while (attacking == true)
        {
            yield return new WaitForSeconds(attackDuration);

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (attacking == false)
        {
            attacking = true;
            StartCoroutine(AttackLifeSpan());
        }
        else
        {
            attacking = false;
            StopCoroutine(AttackLifeSpan());
        }
    }
}
