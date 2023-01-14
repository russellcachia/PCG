using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    GameObject[] streets;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPlayer", 0f);
    }
    
    void SpawnPlayer()
    {
        streets = GameObject.FindGameObjectsWithTag("road");
        //Debug.Log("Spawned on " + this.gameObject.name);
        GameObject spawnPos = streets[Random.Range(0, streets.Length)];
        player.transform.position = streets[Random.Range(0, streets.Length)].transform.position;
        player.SetActive(true);
    }
}
