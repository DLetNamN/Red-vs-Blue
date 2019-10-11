using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_script : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void destroy_self()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
