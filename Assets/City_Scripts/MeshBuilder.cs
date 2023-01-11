using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBuilder
{
    private List<Vector3> vertices = new List<Vector3>(); //a list to store all the points in our mesh

    private List<int> triangleIndices = new List<int>(); // a list of indices that correspond to the indices of the vertices list to make up a triangle

    private List<Vector3> normals = new List<Vector3>(); //defines the direction of each vertex

    private List<Vector2> uv = new List<Vector2>(); // stores coordinates of the UV 

    private List<int>[] submeshIndices = new List<int>[] {}; // array of submesh indices


    public MeshBuilder(int submeshCount)
    {

        submeshIndices = new List<int>[submeshCount];

        for(int i = 0; i < submeshCount; i++){
            submeshIndices[i] = new List<int>();
        }
    }

    public void TriangleBuilder(Vector3 p0, Vector3 p1, Vector3 p2, int submesh)
    {
        
        Vector3 normal = Vector3.Cross(p1 - p0, p2 - p0).normalized;
        TriangleBuilder(p0 , p1 , p2, normal, submesh);

    }

    public void TriangleBuilder(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 normal, int submesh)
    {

        int p0Index = vertices.Count;
        int p1Index = vertices.Count + 1;
        int p2Index = vertices.Count + 2;

        vertices.Add(p0);
        vertices.Add(p1);
        vertices.Add(p2);

        triangleIndices.Add(p0Index);
        triangleIndices.Add(p1Index);
        triangleIndices.Add(p2Index);

        submeshIndices[submesh].Add(p0Index);
        submeshIndices[submesh].Add(p1Index);
        submeshIndices[submesh].Add(p2Index);
        
        normals.Add(normal);
        normals.Add(normal);
        normals.Add(normal);

        uv.Add(new Vector2(0,0));
        uv.Add(new Vector2(0,1));
        uv.Add(new Vector2(1,1));
    }


    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

            mesh.vertices = vertices.ToArray();

            mesh.triangles = triangleIndices.ToArray();

            mesh.normals = normals.ToArray();

            mesh.uv = uv.ToArray();

            mesh.subMeshCount = submeshIndices.Length;

            for(int i = 0; i < submeshIndices.Length; i++)
            {
                if(submeshIndices[i].Count < 3){
                    mesh.SetTriangles(new int[3] {0,0,0}, i);
                }else{
                    mesh.SetTriangles(submeshIndices[i].ToArray(),i);
                }
            }
        return mesh;
    }
}
