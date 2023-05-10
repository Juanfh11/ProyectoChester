using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonRebote : MonoBehaviour
{
    private Animator animator;
    public AudioClip sonido;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D punto in col.contacts)
            {
                if (col.GetContact(0).normal.y <= -0.9)
                {
                    animator.SetTrigger("Golpe");
                    col.gameObject.GetComponent<ChesterMovement>().Rebote();
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
                }
            }
        }
    }
}
