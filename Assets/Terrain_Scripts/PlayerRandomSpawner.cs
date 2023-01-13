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
        path.AddComponent<Cube>();
        path.GetComponent<Cube>().SetCubeSize(1, 1, 200);
        path.AddComponent<BoxCollider>();
        path.GetComponent<BoxCollider>().size = new Vector3(1, 1, 200);
        path.transform.position = new Vector3(Random.Range(200, 500), 500, 500);

    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position =  path.transform.position + new Vector3(0, 2, 0);
    }
}
