using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    //en este script habra un metodo que se activara al elegir un poder para que este se añada a los selectedPowers
    public GameObject[] powers = new GameObject[5];
    public GameObject[] selectedPowers = new GameObject[5];
    public float[] powerTimers = new float[5];
    public float[] originalPowerTimers = new float[5];
    public float[] powerDurations = new float[5];
    void Start()
    {
        for(int i=0; i<powers.Length; i++) //esto sera parte del metodo añadirPower
        {
            if (powers[i] != null)
            {
                selectedPowers[i] = powers[i];
                originalPowerTimers[i] = powers[i].gameObject.transform.GetComponent<DamagingPower>().waitingTime;
                powerTimers[i] = powers[i].gameObject.transform.GetComponent<DamagingPower>().waitingTime;
                powerDurations[i] = powers[i].gameObject.transform.GetComponent<DamagingPower>().powerDuration;
            }          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            for (int i = 0; i < selectedPowers.Length; i++)
            {
                if (selectedPowers[i] != null)
                {
                    if (powerTimers[i] <= 0)
                    {
                    GameObject pepe = Instantiate(selectedPowers[i], gameObject.transform);
                    Destroy(pepe, powerDurations[i]);
                    powerTimers[i] = originalPowerTimers[i];
                    }
                    else
                    {
                    powerTimers[i] -= Time.deltaTime;
                    }
                }                  
            }
            
        
    }
}
