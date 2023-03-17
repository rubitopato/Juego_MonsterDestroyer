using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed = 0.2f;
    public SpriteRenderer sprite;
    public Animator animator;
    private float beforePosition;
    private float afterPosition;

    // Update is called once per frame
    private void Start()
    {
        beforePosition = gameObject.transform.position.x;
    }
    void FixedUpdate()
    {
        afterPosition = gameObject.transform.position.x;
        if (afterPosition - beforePosition > 0)
        {
            beforePosition = afterPosition;
            sprite.flipX = true;
        }
        else if (afterPosition - beforePosition < 0)
        {
            beforePosition = afterPosition;
            sprite.flipX = false;
        }

        //triangleAnimator.Play("Run");
        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime);
    }
}
