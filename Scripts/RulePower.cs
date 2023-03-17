using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulePower : MonoBehaviour
{
    public BoxCollider2D ruleCollider;
    public Animator ruleAnimator;
    public SpriteRenderer ruleSprite;
    private GameObject parent;
    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

            ruleCollider.enabled = true;
            ruleSprite.enabled = true;
            if (parent.GetComponent<SpriteRenderer>().flipX == true)
            {
                ruleAnimator.Play("FirstStageAttack"); //añadir una animacion para golpear el otro lado
            }
            else
            {
                ruleAnimator.Play("FirstStageAttackRight");
            }
            Invoke("Restart", 0.18f);

    }
    void Restart()
    {
        ruleCollider.enabled = false;
        ruleSprite.enabled = false;
    }
}
