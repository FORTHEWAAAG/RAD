using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public List<NewWeapon> Weapons;
    public Vector3 Target;
    Vector3 targetPos;

    Vector3 startingPos;

    public float projSpeed = 5.0f;

    public SpriteRenderer currSprite;
    public Sprite weaponSprite;
    public Sprite ammoSprite;


    private float maxRange;

    void Start() {
        weaponSprite = Weapons[PlayerChar.currWeapon].weaponSprite;
        ammoSprite = Weapons[PlayerChar.currWeapon].ammoSprite;

        currSprite.sprite = ammoSprite;

        Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        targetPos.x = Target.x;
        targetPos.y = Target.y;

        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;

        targetPos = startingPos + (targetPos - startingPos).normalized * 10000.0f;

        float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
        transform.Rotate(0.0f, 0.0f, angle);


        maxRange = Weapons[PlayerChar.currWeapon].maxRange;
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
}
