using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    
    public void EnemySpawner(GameObject enemy)
    {
        Instantiate(enemy, gameObject.transform);
    }
    
    
}
