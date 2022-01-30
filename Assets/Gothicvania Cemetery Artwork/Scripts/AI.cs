using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenght = 10f;
    [SerializeField] private float jumpHeight = 15;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    protected Animator anim;
    protected Rigidbody2D rb;

    private bool facingLeft = true;

    //protected override void Start()
    private void Start()
    {
        //base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(facingLeft)
        {
            if(transform.position.x > leftCap)
            {
                if(transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if(coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLenght, jumpHeight);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLenght, jumpHeight);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }
    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
