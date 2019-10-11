using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallScript : MonoBehaviour
{
    public float bulletDamage;
    public GameObject explosion;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            collision.transform.GetComponent<movement>().health -= bulletDamage;
        }
        if(collision.tag != "Bullet")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
