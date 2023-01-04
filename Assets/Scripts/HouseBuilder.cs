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
        this.transform.position = new Vector3(0, 3f, 0);
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
        house.GetComponent<Cube>().setSubMeshIndex(5);

        for (int i = 0; i < 2; i++)
        {
            GameObject road = new GameObject();
            road.transform.parent = this.transform;
            road.AddComponent<Cube>();
            road.GetComponent<Cube>().SetCubeSize(roadLength,0.05f,1f);
            road.GetComponent<Cube>().setSubMeshIndex(1);

            GameObject pavement = new GameObject();
            pavement.transform.parent = this.transform;
            pavement.AddComponent<Cube>();
            pavement.GetComponent<Cube>().SetCubeSize(roadLength,0.05f,0.5f);
            pavement.GetComponent<Cube>().setSubMeshIndex(2);

            switch(i)
            {
                case 0:
                    road.name = "right_lane";
                    road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y, 1.1f);
                    pavement.name = "pav_right";
                    pavement.transform.position = new Vector3(road.transform.position.x, 0.05f, 2.6f);
                break;
                case 1:
                    road.name = "left_lane";
                    road.GetComponent<Cube>().SetCubeSize(6.8f,0.05f,1f);
                    road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y, -1.1f);

                    pavement.name = "pav_left";
                    pavement.GetComponent<Cube>().SetCubeSize(4.75f,0.05f,0.5f);
                    pavement.transform.position = new Vector3(road.transform.position.x, 0.05f, -2.6f);
                break;
            }
        }
    }
}

