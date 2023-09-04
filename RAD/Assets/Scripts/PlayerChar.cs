using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChar : MonoBehaviour
{
    public GameObject playerCharacter;
    public Joystick attackJoystick;

    public GameObject AttackSprite;
    public List<NewWeapon> Weapons;
    public static int currWeapon = 1;
    public bool isAttacking = false;
    public bool stopAttacking = true;

    #region Variable
    public Slider HealthBar;
    public int playerMaxHealth = 150;           // HEALTH
    public static int playerCurrentHealth;      // HEALTH


    public Slider RadiationBar;
    public int playerMaxRadiation = 75;           // RADIATION
    public static int playerCurrentRadiation;      // RADIATION
    private bool isRadDoTActive = false;            // RADIATION


    public Slider HungerBar;
    public int playerMaxHunger = 100;           // HUNGER
    public static int playerCurrentHunger;      // HUNGER


    public Slider ThirstBar;
    public int playerMaxThirst = 100;           // THIRST
    public static int playerCurrentThirst;      // THIRST


    public int maxCarryingCapacity = 100;
    public int currentLoad = 0;
    #endregion

    private void Start() {

        playerCurrentHealth = playerMaxHealth;

        playerCurrentRadiation = 0;

        HealthBar.maxValue = playerMaxHealth;
        HealthBar.value = playerCurrentHealth;

        RadiationBar.maxValue = playerMaxRadiation;
        RadiationBar.value = playerCurrentRadiation;

        /*HungerBar.maxValue = playerMaxHunger;
        HungerBar.value = playerCurrentHunger;

        ThirstBar.maxValue = playerMaxThirst;
        ThirstBar.value = playerCurrentThirst;*/
    }


    private void UpdateSliders()
    {
        HealthBar.value = playerCurrentHealth;

        RadiationBar.value = playerCurrentRadiation;
    }

    #region Heal
    private void HealHealth(int num)
    {
        if (playerMaxHealth + num <= 150)
        {
            playerMaxHealth += num;
        }
        else
        {
            playerMaxHealth = 150;
        }

        if (playerCurrentHealth + (num -15) <= playerMaxHealth)
        {
            playerCurrentHealth += (num - 15);
        }
        else
        {
            playerCurrentHealth = playerMaxHealth;
        }
    }

    private void HealRadiation(int num)
    {
        if (playerCurrentRadiation - num >= 0)
        {
            playerCurrentRadiation -= num;
        }
        else
        {
            playerCurrentRadiation = 0;
        }
    }
    #endregion

    #region RadiationMech
    IEnumerator RadiationDamageOverTime ()
    {
        while (isRadDoTActive == true)
        {
            if (playerCurrentHealth >= 3)
            {
                playerMaxHealth -= 2;
            }

            if (playerCurrentHealth >= 3)
            {
                playerCurrentHealth -= 2;
            }

            HealthBar.maxValue = playerMaxHealth;
            HealthBar.value = playerCurrentHealth;

            yield return new WaitForSeconds(0.5f);
        }
    }
    #endregion

    #region Attack
    IEnumerator Attack()
    {
        while (isAttacking == true)
        {
            if (stopAttacking == false)
            {
                float timeBtwShots = 1.0f / Weapons[currWeapon].fireRate;

                Instantiate(AttackSprite, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(timeBtwShots);
            }
            else
            {
                isAttacking = false;

                StopCoroutine(Attack());
            }
        }
    }
    #endregion

    private void Update() {

        UpdateSliders();

        if ((RadiationBar.value >= RadiationBar.maxValue) && (isRadDoTActive == false))
        {
            isRadDoTActive = true;
            StartCoroutine(RadiationDamageOverTime());
        }

        if (RadiationBar.value < RadiationBar.maxValue)
        {
            isRadDoTActive = false;
            StopCoroutine(RadiationDamageOverTime());
        }

        if (Input.GetKeyDown(KeyCode.H) == true)
        {
            HealHealth(30);
        }

        if (Input.GetKeyDown(KeyCode.G) == true)
        {
            HealRadiation(15);
        }

        UpdateSliders();

        if ((Input.GetMouseButton(1) == true) && (isAttacking == false))
        {
            isAttacking = true;
            stopAttacking = false;

            StartCoroutine(Attack());
        }
        
        if((Input.GetMouseButton(1) == false) && (isAttacking == true))
        {
            stopAttacking = true;
        }


        /*if ((Mathf.Abs(attackJoystick.Direction.x) > 0.2f) || (Mathf.Abs(attackJoystick.Direction.y) > 0.2f))
        {
            if (isAttacking == false)
            {
                isAttacking = true;
                stopAttacking = false;

                StartCoroutine(Attack());
            }
        }

        if ((Mathf.Abs(attackJoystick.Direction.x) < 0.2f) || (Mathf.Abs(attackJoystick.Direction.y) < 0.2f))
        {
            if (isAttacking == true)
            {
                stopAttacking = true;
            }
        }*/


        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            if(PlayerChar.currWeapon <= 2)
            {
                PlayerChar.currWeapon++;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            if(PlayerChar.currWeapon >= 2)
            {
                PlayerChar.currWeapon--;
            }            
        }
    }
}
