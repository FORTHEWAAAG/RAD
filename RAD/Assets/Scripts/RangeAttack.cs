using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public GameObject Target;
    Vector3 targetPos;
    
    public float projSpeed = 5.0f;
    public int damage = 5;

    void Start() {

        Target = GameObject.FindGameObjectWithTag("Player");

        targetPos.x = Target.transform.position.x;
        targetPos.y = Target.transform.position.y;
        targetPos.z = Target.transform.position.z;

        float angle = Vector3.SignedAngle(transform.up, targetPos - transform.position, transform.forward);
        transform.Rotate(0.0f, 0.0f, angle);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            PlayerChar.playerCurrentHealth -= damage;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, (projSpeed * Time.deltaTime));
        
        if ((transform.position.x == targetPos.x) && (transform.position.y == targetPos.y)) {
            Destroy(gameObject);
        }
    }
}
