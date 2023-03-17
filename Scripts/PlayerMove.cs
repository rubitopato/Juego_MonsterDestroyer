using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float runSpeed = 2;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            spriteRenderer.flipX = false;
            animator.Play("RunCirclePlayer");
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                rigid.velocity = new Vector2(runSpeed, runSpeed);
            }
            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                rigid.velocity = new Vector2(runSpeed, -runSpeed);
            }
            if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
            {
                rigid.velocity = new Vector2(runSpeed, 0);
            }
            if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
            {
                rigid.velocity = new Vector2(runSpeed, 0);
            }
            rigid.velocity = new Vector2(runSpeed, rigid.velocity.y);
        }

        else if (Input.GetKey("w") || Input.GetKey("up"))
        {
            animator.Play("RunCirclePlayer");
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                spriteRenderer.flipX = true;
                rigid.velocity = new Vector2(-runSpeed, runSpeed);
            }
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                spriteRenderer.flipX = false;
                rigid.velocity = new Vector2(runSpeed, runSpeed);
            }
            if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
            {
                rigid.velocity = new Vector2(0, runSpeed);
            }
            if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
            {
                rigid.velocity = new Vector2(0, runSpeed);
            }
            rigid.velocity = new Vector2(rigid.velocity.x, runSpeed);
        }

        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            animator.Play("RunCirclePlayer");
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                spriteRenderer.flipX = true;
                rigid.velocity = new Vector2(-runSpeed, -runSpeed);
            }
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                spriteRenderer.flipX = false;
                rigid.velocity = new Vector2(runSpeed, -runSpeed);
            }
            if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
            {
                rigid.velocity = new Vector2(0, -runSpeed);
            }
            if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
            {
                rigid.velocity = new Vector2(0, -runSpeed);
            }
            rigid.velocity = new Vector2(rigid.velocity.x, -runSpeed);
        }

        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            spriteRenderer.flipX = true;
            animator.Play("RunCirclePlayer");
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                rigid.velocity = new Vector2(-runSpeed, runSpeed);
            }
            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                rigid.velocity = new Vector2(-runSpeed, -runSpeed);
            }
            if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
            {
                rigid.velocity = new Vector2(-runSpeed, 0);
            }
            if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
            {
                rigid.velocity = new Vector2(-runSpeed, 0);
            }
            rigid.velocity = new Vector2(-runSpeed, rigid.velocity.y);
        }

        else
        {
            animator.Play("IdleCirclePlayer");
            rigid.velocity = new Vector2(0, 0);
        }
        
    }
}
