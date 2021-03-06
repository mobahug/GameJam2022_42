using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anim;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
        rb.velocity = new Vector2(0, 0);
    }
    private void Death()
    {
        Destroy(this);
    }
}
