using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if(collision.tag == "Player")
        {
            collision.transform.GetComponent<movement>().health -= 1;
        }
    }
}
