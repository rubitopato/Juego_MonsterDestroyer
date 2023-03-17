using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollider : MonoBehaviour
{
    private bool activated=false;
    private float velocity = 0.5f;
    private Collider2D player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision;
            activated = true;
        }
    }
    private void FixedUpdate()
    {
        if (activated)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;//desactivamos pa que no vuelva a chocar contra nada
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, velocity * Time.deltaTime);//hacemos que la exp se mueva hacia el player
            velocity = velocity + 0.1f;//con una velocidad creciente
            Destroy(gameObject, 3);//destruimos el objeto una vez el player lo "coja"
        }
    }
}
