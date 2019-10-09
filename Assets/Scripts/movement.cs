using System.Collections;
using System.Collections.Generic;
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

    [Header("Game Components")]
    public Rigidbody2D rbody;
    public Transform shootPoint;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        thrustSpeed = 2;

        turnSpeed = 2;
    }

    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            rbody.AddForce(transform.up * thrustSpeed);
        }

        Vector3 lookVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 4096);
        
        if(lookVec.x != 0 || lookVec.y != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.back);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }   
}
