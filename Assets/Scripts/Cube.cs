using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{

    [SerializeField]
    private Vector3 triangleSize;

    private float cubeLength, cubeHeight, cubeWidth;

    [SerializeField]
    private int submeshCount = 10;

    [SerializeField]
    private int submeshIndex;


    // Start is called before the first frame update
    void Start()
    {
        triangleSize = new Vector3(cubeLength, cubeHeight, cubeWidth);
        CreateCube();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetCubeSize(float length, float height, float width)
    {
        cubeLength = length;
        cubeHeight = height;
        cubeWidth = width;
    }

    public Vector3 CubeSize(){
        return triangleSize;
    }

    public void UpdateCubeSize(Vector3 newCubeSize){
        triangleSize = newCubeSize;
    }

    public void setSubMeshIndex(int index)
    {
        submeshIndex = index;
    }

    private void CreateCube(){

        MeshFilter meshFilter = this.GetComponent<MeshFilter>();

        MeshBuilder meshBuilder = new MeshBuilder(submeshCount);

        //SET POINTS and TRIANGLES

        // ---- POINTS ----

        //top points
        Vector3 t0 = new Vector3(triangleSize.x, triangleSize.y, -triangleSize.z);
        Vector3 t1 = new Vector3(-triangleSize.x, triangleSize.y, -triangleSize.z);
        Vector3 t2 = new Vector3(-triangleSize.x, triangleSize.y, triangleSize.z);
        Vector3 t3 = new Vector3(triangleSize.x, triangleSize.y, triangleSize.z);

        //bottom points
        Vector3 b0 = new Vector3(triangleSize.x, -triangleSize.y, -triangleSize.z);
        Vector3 b1 = new Vector3(-triangleSize.x, -triangleSize.y, -triangleSize.z);
        Vector3 b2 = new Vector3(-triangleSize.x, -triangleSize.y, triangleSize.z);
        Vector3 b3 = new Vector3(triangleSize.x, -triangleSize.y, triangleSize.z);


        // ---- TRIANGLES ----

        //top square
        meshBuilder.TriangleBuilder(t0, t1, t2, submeshIndex);
        meshBuilder.TriangleBuilder(t0, t2, t3, submeshIndex);

        //bottom square
        meshBuilder.TriangleBuilder(b2, b1, b0, submeshIndex);
        meshBuilder.TriangleBuilder(b3, b2, b0, submeshIndex);

        //back square
        meshBuilder.TriangleBuilder(b0, t1, t0, submeshIndex);
        meshBuilder.TriangleBuilder(b0, b1, t1, submeshIndex);

        //front square
        meshBuilder.TriangleBuilder(b3, t0 ,t3, submeshIndex);
        meshBuilder.TriangleBuilder(b3, b0, t0, submeshIndex);

        //left square
        meshBuilder.TriangleBuilder(b1, t2, t1, submeshIndex);
        meshBuilder.TriangleBuilder(b1, b2, t2, submeshIndex);

        //right square
        meshBuilder.TriangleBuilder(b2, t3, t2, submeshIndex);
        meshBuilder.TriangleBuilder(b2, b3, t3, submeshIndex);

        meshFilter.mesh = meshBuilder.CreateMesh();

        MaterialsBuilder materialsBuilder = new MaterialsBuilder();

        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.materials = materialsBuilder.MaterialsList().ToArray();
    }
}
