using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCity : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        CreatePortal();
        this.transform.position = position;
        this.transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePortal()
    {
        GameObject portal = new GameObject();
        portal.name = "portal";
        portal.transform.parent = this.transform;
        portal.AddComponent<Cube>();
        portal.GetComponent<Cube>().SetCubeSize(1f,1f,1f);
        portal.GetComponent<Cube>().setSubMeshIndex(7);
        portal.transform.position = new Vector3(0f, 1f, 0f);
    }
}
