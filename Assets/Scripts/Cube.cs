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
    private int submeshCount = 6;

    [SerializeField]
    private int submeshTopIndex = 0;

    [SerializeField]
    private int submeshBottomIndex = 1;

    [SerializeField]
    private int submeshFrontIndex = 2;

    [SerializeField]
    private int submeshBackIndex = 3;
        
    [SerializeField]
    private int submeshLeftIndex = 4;

    [SerializeField]
    private int submeshRightIndex = 5;

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
        meshBuilder.TriangleBuilder(t0, t1, t2, submeshTopIndex);
        meshBuilder.TriangleBuilder(t0, t2, t3, submeshTopIndex);

        //bottom square
        meshBuilder.TriangleBuilder(b2, b1, b0, submeshBottomIndex);
        meshBuilder.TriangleBuilder(b3, b2, b0, submeshBottomIndex);

        //back square
        meshBuilder.TriangleBuilder(b0, t1, t0, submeshBackIndex);
        meshBuilder.TriangleBuilder(b0, b1, t1, submeshBackIndex);

        //front square
        meshBuilder.TriangleBuilder(b3, t0 ,t3, submeshFrontIndex);
        meshBuilder.TriangleBuilder(b3, b0, t0, submeshFrontIndex);

        //left square
        meshBuilder.TriangleBuilder(b1, t2, t1, submeshLeftIndex);
        meshBuilder.TriangleBuilder(b1, b2, t2, submeshLeftIndex);

        //right square
        meshBuilder.TriangleBuilder(b2, t3, t2, submeshRightIndex);
        meshBuilder.TriangleBuilder(b2, b3, t3, submeshRightIndex);

        meshFilter.mesh = meshBuilder.CreateMesh();

        MaterialsBuilder materialsBuilder = new MaterialsBuilder();

        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.materials = materialsBuilder.MaterialsList().ToArray();
    }
}
