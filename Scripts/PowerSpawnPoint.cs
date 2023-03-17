using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawnPoint : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}
