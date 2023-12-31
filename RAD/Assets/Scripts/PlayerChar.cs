using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChar : MonoBehaviour
{
    public GameObject playerCharacter;

    public Joystick joystick;
    public float speed = 10.0f;


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

    private void Start()
    {

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

        if (playerCurrentHealth + (num - 15) <= playerMaxHealth)
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
    IEnumerator RadiationDamageOverTime()
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


    private void Update()
    {

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


        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            if (PlayerChar.currWeapon <= 2)
            {
                PlayerChar.currWeapon++;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            if (PlayerChar.currWeapon >= 2)
            {
                PlayerChar.currWeapon--;
            }
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, joystick.Direction + new Vector2(transform.position.x, transform.position.y), speed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, (float)Math.Sqrt(Weapons[currWeapon].maxRange));
    }
}
