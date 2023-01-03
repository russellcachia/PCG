using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    private int roadLength;
    private Vector3 position;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        CreateRoad();
        this.transform.position = position;
        this.transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRoadLength(int length)
    {
        roadLength = length/2;
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

    private void CreateStreet(){

        GameObject divider = new GameObject();
        divider.name = "MiddleStrip";
        divider.transform.parent = this.transform;
        divider.AddComponent<Cube>();
        divider.GetComponent<Cube>().setCubeSize(roadLength,0.05f,0.1f);
        divider.GetComponent<Cube>().setSubmeshIndex(1);

        for(int i = 0;i < 2;i++){
            GameObject street = new GameObject();
            street.transform.parent = this.transform;
            street.AddComponent<Cube>();
            street.GetComponent<Cube>().setCubeSize(roadLength,0.05f,0.5f);
            street.GetComponent<Cube>().setSubmeshIndex(0);

            GameObject pavement = new GameObject();
            pavement.transform.parent = this.transform;
            pavement.AddComponent<Cube>();
            pavement.GetComponent<Cube>().setCubeSize(roadLength,0.05f,0.3f);
            pavement.GetComponent<Cube>().setSubmeshIndex(2);

            switch(i){
                case 0:
                    road.name = "Road Right";
                    road.transform.position = new Vector3(road.transform.position.x,road.transform.position.y,0.6f);
                    pavement.name = "Pavement Right";
                    pavement.transform.position = new Vector3(road.transform.position.x,road.transform.position.y,1.4f);
                break;
                case 1:
                    road.name = "Road Left";
                    road.transform.position = new Vector3(road.transform.position.x,road.transform.position.y,- 0.6f);

                    pavement.name = "Pavement Left";
                    pavement.transform.position = new Vector3(road.transform.position.x,road.transform.position.y,-1.4f);
                break;
            }
        }
    }
}

