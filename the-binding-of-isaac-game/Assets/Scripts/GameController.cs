using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private static float health=6;
    private static int maxHealth=6 ;
    private static float moveSpeed=100;
    private static float fireRate=1f;
    private static float bulletSize = 5f;
    public Text healthText;
    public static float Health{ get=>health;set=>health = value; }
    public static int MaxHealth{ get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get =>moveSpeed; set => moveSpeed = value; }
    public static float FireRate{ get => fireRate; set => fireRate = value; }
    public static float BulletSize { get => bulletSize; set => bulletSize = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        
        healthText.text = "Health"+health;
    }
    public static void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillPlayer();
        }


    }
    public static void HealPlayer(float healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);
    }
    private static void KillPlayer()
    {
        health = 6;
    maxHealth = 6;
   moveSpeed = 100;
    fireRate = 1f;
    bulletSize = 5f;
    SceneManager.LoadScene(2);
    }
    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }
    public static void FireRateChange(float rate)
    {
        float newFireRate = fireRate - rate;
        if (newFireRate <= 0)
        {
            fireRate = 0.1f;
        }
        else
            fireRate -= rate;

    }
    public static void BulletSizeChange(float size)
    {
        bulletSize+= size;
    }

}
