using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public float waitingTime;
    private float waitedTime=0;
    private float enemyCounter=0;
    private GameObject[] spawners = new GameObject[8];
    public GameObject[] enemyList;


    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            spawners[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    void Update()
    {
        if (enemyCounter <= 40) //esto habra que bajarlo segun vayan matando enemigos
        {
            if (waitedTime >= waitingTime)
            {
                int index = Random.Range(0, gameObject.transform.childCount);
                spawners[index].GetComponent<SpawnEnemy>().EnemySpawner(enemyList[0]);
                enemyCounter++;
                waitedTime = 0;
            }
            else
            {
                waitedTime += Time.deltaTime;
            }
        }
        else
        {
            waitedTime = 0;
        }
        
    }
}
