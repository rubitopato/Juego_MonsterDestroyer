using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingPower : MonoBehaviour
{
    public string powerName;
    public float damage;
    public float stuntDealt;
    public float waitingTime=1;
    public float powerDuration;
    public int Level = 1;  //este sera el script encargado de llamar al metodo de subir de nivel de cada poder, porque este script es generico
    public float timeBetweenHits;
    public Component powerScepecificScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Damagable>().Damaged(powerName, damage, stuntDealt, timeBetweenHits);
        }
    }
}
