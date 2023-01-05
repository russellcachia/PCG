using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilder : MonoBehaviour
{
    private int roadLength;
    private Vector3 position;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        CreateHouse();
        this.transform.position = position;
        this.transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setRoadLength(int length)
    {
        roadLength = length;
    }

    public int getRoadLength()
    {
        return roadLength;
    }

    public void setPosition(Vector3 pos)
    {
        position = pos;
    }

    public void setRotation(Quaternion rot)
    {
        rotation = rot;
    }

    private void CreateHouse()
    {
        //house
        GameObject house = new GameObject();
        house.name = "house";
        house.transform.parent = this.transform;
        house.AddComponent<Cube>();
        house.GetComponent<Cube>().SetCubeSize(1.5f, 3f, 1.5f);
        house.GetComponent<Cube>().setSubMeshIndex(7);

        //roof
        GameObject roof = new GameObject();
        roof.name = "roof";
        roof.transform.parent = house.transform;
        roof.AddComponent<Cube>();
        roof.GetComponent<Cube>().SetCubeSize(1.7f, 0.3f, 1.7f);
        roof.GetComponent<Cube>().setSubMeshIndex(7);
        roof.transform.position = new Vector3(0f, 3.2f, 0f);

        //door1
        GameObject door1 = new GameObject();
        door1.name = "door1";
        door1.transform.parent = house.transform;
        door1.AddComponent<Cube>();
        door1.GetComponent<Cube>().SetCubeSize(1.55f, 1f, 0.5f);
        door1.GetComponent<Cube>().setSubMeshIndex(7);
        door1.transform.position = new Vector3(0f, -2f, 0f);
        door1.transform.rotation = Quaternion.Euler(0, 90f, 0);

        //door2
        GameObject door2 = new GameObject();
        door2.name = "door2";
        door2.transform.parent = house.transform;
        door2.AddComponent<Cube>();
        door2.GetComponent<Cube>().SetCubeSize(1.55f, 1f, 0.5f);
        door2.GetComponent<Cube>().setSubMeshIndex(7);
        door2.transform.position = new Vector3(0f, -2f, 0f);

        //window1
        GameObject window1 = new GameObject();
        window1.name = "window1";
        window1.transform.parent = house.transform;
        window1.AddComponent<Cube>();
        window1.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window1.GetComponent<Cube>().setSubMeshIndex(7);
        window1.transform.position = new Vector3(0f, 2.2f, 0.8f);

        //window2
        GameObject window2 = new GameObject();
        window2.name = "window2";
        window2.transform.parent = house.transform;
        window2.AddComponent<Cube>();
        window2.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window2.GetComponent<Cube>().setSubMeshIndex(7);
        window2.transform.position = new Vector3(0f, 2.2f, -0.8f);

        //window3
        GameObject window3 = new GameObject();
        window3.name = "window3";
        window3.transform.parent = house.transform;
        window3.AddComponent<Cube>();
        window3.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window3.GetComponent<Cube>().setSubMeshIndex(7);
        window3.transform.position = new Vector3(0f, 0.8f, 0.8f);

        //window4
        GameObject window4 = new GameObject();
        window4.name = "window4";
        window4.transform.parent = house.transform;
        window4.AddComponent<Cube>();
        window4.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window4.GetComponent<Cube>().setSubMeshIndex(7);
        window4.transform.position = new Vector3(0f, 0.8f, -0.8f);

        //window5
        GameObject window5 = new GameObject();
        window5.name = "window5";
        window5.transform.parent = house.transform;
        window5.AddComponent<Cube>();
        window5.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window5.GetComponent<Cube>().setSubMeshIndex(7);
        window5.transform.position = new Vector3(-0.8f, 2.2f, 0f);
        window5.transform.rotation = Quaternion.Euler(0, 90f, 0);

        //window6
        GameObject window6 = new GameObject();
        window6.name = "window6";
        window6.transform.parent = house.transform;
        window6.AddComponent<Cube>();
        window6.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window6.GetComponent<Cube>().setSubMeshIndex(7);
        window6.transform.position = new Vector3(0.8f, 2.2f, 0f);
        window6.transform.rotation = Quaternion.Euler(0, 90f, 0);

        //window7
        GameObject window7 = new GameObject();
        window7.name = "window7";
        window7.transform.parent = house.transform;
        window7.AddComponent<Cube>();
        window7.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window7.GetComponent<Cube>().setSubMeshIndex(7);
        window7.transform.position = new Vector3(-0.8f, 0.8f, 0f);
        window7.transform.rotation = Quaternion.Euler(0, 90f, 0);

        //window8
        GameObject window8 = new GameObject();
        window8.name = "window8";
        window8.transform.parent = house.transform;
        window8.AddComponent<Cube>();
        window8.GetComponent<Cube>().SetCubeSize(1.55f, 0.5f, 0.5f);
        window8.GetComponent<Cube>().setSubMeshIndex(7);
        window8.transform.position = new Vector3(0.8f, 0.8f, 0f);
        window8.transform.rotation = Quaternion.Euler(0, 90f, 0);
    }
}

