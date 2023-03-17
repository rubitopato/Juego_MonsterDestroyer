using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExpDrop : MonoBehaviour
{
    public GameObject expPoint;
    public int multiplicador;//multiplicador para que dropen experiencia
    private int maxRandom=6;

    public void expDroppingFunction(Vector3 position)
    {
        int random = Random.Range(0, maxRandom);
        if (random % 2 == 0)
        {
            Instantiate(expPoint, position, new Quaternion(0,0,0,0));//lo del quaternion es una rotacion que ni idea, pero asi es sin ninguna, asi el exp spawnea donde murio el enemigo
        }
    }
}
