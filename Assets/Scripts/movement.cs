using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Inputs")]
    public string player;

    [Header("Player Stats")]
    public float thrustSpeed;
    public float turnSpeed;
    public float health;
    public float bulletDmg;
    public float bulletSpeed;
    public float bulletKnockback;
    public float cooldownTimer;

    private float cooldown;

    [Header("Game Components")]
    public Rigidbody2D rbody;
    public Transform shootPoint;
    public GameObject cannonBall;
    public AudioSource cannonBallSound;
    public Animator anim;
    public Image hpBar;

    private float healthStart;

    private SceneHandlerScript sceneHandler;

    void Start()
    {
        healthStart = health;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        hpBar.fillAmount = health;

        sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandlerScript>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump" + player ))
        {
            rbody.AddForce(transform.up * thrustSpeed);
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            sceneHandler.MatchOver(player);
            Destroy(gameObject);
        }

        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            cooldown = 0;
        }

        if (Input.GetButtonDown("Shoot" + player))
        {
            Shoot();
        }

        Vector3 lookVec = new Vector3(Input.GetAxis("Horizontal" + player), Input.GetAxis("Vertical" + player), 4096);
        
        if(lookVec.x != 0 || lookVec.y != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.back);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }

    public void Shoot()
    {
        if (cooldown == 0)
        {
            var ball = Instantiate(cannonBall, shootPoint.position, shootPoint.rotation);
            ball.GetComponent<cannonBallScript>().bulletDamage = bulletDmg;
            ball.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);

            anim.SetTrigger("Shoot");

            rbody.AddForce(-transform.up * bulletKnockback, ForceMode2D.Impulse);

            cannonBallSound.Play();
            cooldown = cooldownTimer;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            var dir = transform.position - collision.transform.position;
            rbody.AddForce(dir * 0.8f, ForceMode2D.Impulse);
            anim.SetTrigger("Dmg");
            hpBar.fillAmount = health / healthStart;
            if (hpBar.fillAmount < 0.3)
            {
                hpBar.color = Color.red;
            }
        }
    }
}
