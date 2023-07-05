using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public List<NewWeapon> Weapons;

    public Joystick attackJoystick;
    Vector3 Target;
    Vector3 Direction;
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

        //Direction = new Vector3(attackJoystick.Direction.x, attackJoystick.Direction.y, 0);

        Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;

        targetPos.x = Target.x;
        targetPos.y = Target.y;

        targetPos = startingPos + (targetPos - startingPos).normalized * 10000.0f;

        float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
        transform.Rotate(0.0f, 0.0f, angle);


        maxRange = Weapons[PlayerChar.currWeapon].maxRange;
    }

    private void FixedUpdate() {
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
