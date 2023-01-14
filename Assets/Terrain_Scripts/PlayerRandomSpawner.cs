using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomSpawner : MonoBehaviour
{
    public GameObject player;
    
    GameObject path;

    // Start is called before the first frame update
    void Start()
    {
        path = new GameObject();
        path.name = "path";
        path.AddComponent<Cube>();
        path.GetComponent<Cube>().SetCubeSize(2, 2, 400);
        path.AddComponent<BoxCollider>();
        path.GetComponent<BoxCollider>().size = new Vector3(4, 4, 800);
        path.transform.position = new Vector3(Random.Range(50, 900), 450, 500);
        player.transform.position =  path.transform.position + new Vector3(0, 2, 0);
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
