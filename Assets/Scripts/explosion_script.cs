using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_script : MonoBehaviour
{
    public Animator anim;
    public AudioSource explosionSound;

    void Start()
    {
        anim = GetComponent<Animator>();

        explosionSound = GameObject.Find("ExplosionSound").GetComponent<AudioSource>();
        explosionSound.pitch = Random.Range(0.8f, 1.2f);
        explosionSound.Play();
    }

    public void destroy_self()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
