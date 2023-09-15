using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int AttackDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDelay = 1f;

    private Animator animator;
    private int food;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("onHit");

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("onStunned");

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("onBuff");

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetTrigger("Death");

        }
    }

}
