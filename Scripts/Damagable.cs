using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{

    public float lifepoints;
    public Animator enemyAnimator;
    public float deathTime;
    public float stuntBase;
    private Vector2 distanceToPlayer;
    private LinkedList<string> receivedAttacks = new LinkedList<string>();
    private float[] timers = new float[8];
    private int timerCount=0;
    private void Start()
    {
        enemyAnimator = gameObject.transform.GetComponent<Animator>();
    }
    private void Update()
    {
        if (timerCount > 0)
        {
            for (int i = 0; i < timerCount; i++)
            {
                timers[i] -= Time.deltaTime;
            }
            if (timers[0] <= 0)
            {

                for (int a = 0; a < timerCount - 1; a++)
                {
                    timers[a] = timers[a + 1];
                }
                timers[timerCount] = 0;
                receivedAttacks.RemoveFirst(); //aqui estamos sacando un ataque que ya nos dio de la array de ataques para que un ataque igual nos pueda golpear otra vez
                timerCount--;

            }
        }
    }
    public void Damaged(string powerName, float damage, float stunt, float timeBetweenHits)
    {

        if (!receivedAttacks.Contains(powerName))
        {
            gameObject.transform.GetComponent<EnemyMove>().enabled = false;
            enemyAnimator.Play("Hit");
            distanceToPlayer = gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position; //vector distancia al jugador
            distanceToPlayer = distanceToPlayer / distanceToPlayer.magnitude; //vector distancia normalizado
            gameObject.transform.position = new Vector3(transform.position.x + 0.001f + distanceToPlayer.x * stuntBase * stunt, transform.position.y + 0.001f + distanceToPlayer.y * stuntBase * stunt, transform.position.z); //el retroceso despues del golpe
            lifepoints -= damage;
            gameObject.transform.GetComponent<EnemyMove>().enabled = true;
            if (lifepoints <= 0)
            {
                gameObject.transform.GetComponent<EnemyMove>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                enemyAnimator.Play("Death");
                GameObject controller = GameObject.FindGameObjectWithTag("ExpController");
                controller.GetComponent<EnemyExpDrop>().expDroppingFunction(gameObject.transform.position);
                Destroy(gameObject, deathTime);
            }
            receivedAttacks.AddLast(powerName);
            timers[timerCount] = timeBetweenHits; //añadir espera de cada ataque si eso
            timerCount++;
        }      
    }   
}
