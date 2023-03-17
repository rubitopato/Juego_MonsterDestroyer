using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilPower : MonoBehaviour
{
    private GameObject[] currentEnemies;
    private GameObject closestEnemy;
    private Vector2 distance;
    private float distanceModule;
    private Vector2 initialPosition;
    private Vector2 enemyPosition;
    void Start()
    {
        currentEnemies=GameObject.FindGameObjectsWithTag("Enemy");
        if (currentEnemies == null || currentEnemies.Length==0)
        {
            Destroy(this, 0);
            gameObject.SetActive(false);
        }
        else
        {
            distance = gameObject.GetComponentInParent<Transform>().position - currentEnemies[0].gameObject.transform.position;
            distanceModule = distance.magnitude;
            closestEnemy = currentEnemies[0];
            for (int i = 0; i < currentEnemies.Length; i++)
            {
                Vector2 distance_aux = gameObject.GetComponentInParent<Transform>().position - currentEnemies[i].gameObject.transform.position;
                if (distance_aux.magnitude < distanceModule)
                {
                    distanceModule = distance_aux.magnitude;
                    closestEnemy = currentEnemies[i];
                }
            }
            ///////////////////////////////////////////////////////////////
            enemyPosition = closestEnemy.transform.position;
            Vector3 enemyPositionAux = enemyPosition;
            //enemyPositionAux.z = 0; si algo falla quitar este comentario
            Vector3 lookDirection = enemyPositionAux - transform.position;  //conseguimos el vector desde el jugador al enemigo
            transform.up = -lookDirection; //modificamos el vector arriba del lapiz y le asignamos el vector desde el jugador al enemigo para que se oriente
            /////////////////////////////////////////////////////////////// no tocar esta seccion porque no entiendo muy bien como funciona
        }
        initialPosition = gameObject.transform.GetComponentInParent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies != null)
        {
            transform.position = Vector2.MoveTowards(initialPosition, enemyPosition,5 * Time.deltaTime);
   
        }
        else
        {
            Destroy(this, 0);
        }
        initialPosition = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        gameObject.SetActive(false);
    }
}
