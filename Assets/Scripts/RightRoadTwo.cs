using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRoadTwo : MonoBehaviour
{
    private int roadLength = 10;
    private Vector3 position;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        CreateRoad();
        this.transform.position = new Vector3(-13.8f, 0, -6.9f);
        this.transform.rotation = rotation;
        
        
        //randomizing
        for (int i = 0; i < 2; i++)
        {
            GameObject house = new GameObject();
            house.name = "right_road_house " + (i + 1);
            house.AddComponent<HouseBuilder>();
            house.GetComponent<HouseBuilder>().setPosition(new Vector3(Random.Range(-5f, -22f), 3f, -11.5f));
        }
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

    private void CreateRoad()
    {
        //middle white line
        GameObject divider = new GameObject();
        divider.name = "middle_line";
        divider.transform.parent = this.transform;
        divider.AddComponent<Cube>();
        divider.GetComponent<Cube>().SetCubeSize(7f,0.05f,0.1f);
        divider.GetComponent<Cube>().setSubMeshIndex(0);

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
                    road.GetComponent<Cube>().SetCubeSize(6.85f,0.05f,1f);
                    road.transform.position = new Vector3(-0.05f, road.transform.position.y, 1.1f);
                    pavement.name = "pav_right";
                    pavement.GetComponent<Cube>().SetCubeSize(4.8f,0.05f,0.5f);
                    pavement.transform.position = new Vector3(road.transform.position.x, 0.05f, 2.6f);
                break;
                case 1:
                    road.name = "left_lane";
                    road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y, -1.1f);

                    pavement.name = "pav_left";
                    pavement.transform.position = new Vector3(road.transform.position.x, 0.05f, -2.6f);
                break;
            }
        }
    }
}

