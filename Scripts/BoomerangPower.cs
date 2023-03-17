using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangPower : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float force = 1;
    public float rotateSpeed;
    private GameObject spawn;

    private void Start()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        spawn = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = spawn.transform.position;
        rigid.velocity = new Vector2((-500+spawn.GetComponent<Rigidbody2D>().velocity.x)*Time.deltaTime, 0);//creo que hay que añadirle algo para que dependa del tamaño de la pantalla
    }
    void FixedUpdate()
    {
        rigid.gravityScale = 0;
        rigid.AddForce(new Vector2(290 * force * Time.deltaTime,0));
        force = force + 20 * Time.deltaTime;
    }
}
