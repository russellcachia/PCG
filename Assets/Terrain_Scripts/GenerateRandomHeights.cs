using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TerrainTextureData
{
    public Texture2D terrainTexture;
    public Vector2 tileSize;

    public float minHeight;
    public float maxHeight;
}

[System.Serializable]
public class TreeData
{
    public GameObject treeMesh;
    public float minHeight;
    public float maxHeight;
}

public class GenerateRandomHeights : MonoBehaviour
{
    private Terrain terrain;
    private TerrainData terrainData;

    [SerializeField]
    [Range(0f, 1f)]
    private float minRandomHeightRange = 0f; //min is 0

    [SerializeField]
    [Range(0f, 1f)]
    private float maxRandomHeight = 0.1f; //max is 1

    [SerializeField]
    private bool flattenTerrain = true;

    [Header("Perlin Noise")] 
    [SerializeField]
    private bool perlinNoise = false;

    [SerializeField]
    private float perlinNoiseWidthScale = 0.01f;

    [SerializeField]
    private float perlinNoiseHeightScale = 0.01f;

    [Header("Texture Data")]
    [SerializeField]
    private List<TerrainTextureData> terrainTextureData;

    [SerializeField]
    private bool addTerrainTexture = false;

    [SerializeField]
    private float terrainTextureBlendOffset =   0.01f;  

    [Header("Tree Data")]
    [SerializeField]
    private List<TreeData> treeData;

    [SerializeField]
    private int maxTrees = 2000;

    [SerializeField]
    private int treeSpacing = 10;    

    [SerializeField]
    private bool addTrees = false;

    // Start is called before the first frame update
    void Start()
    {
        if (terrain == null)
        {
            terrain = this.GetComponent<Terrain>();
        }

        if (terrainData == null)
        {
            terrainData = Terrain.activeTerrain.terrainData; 
        } 

        GenerateHeights();
        AddTerrainTextures();
        AddTrees();
    }

    void GenerateHeights()
    {
        float[,] heightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        for (int width = 0; width < terrainData.heightmapResolution; width++)
        {
            for (int height = 0; height < terrainData.heightmapResolution; height++)
            {
                heightMap[width,height] = Random.Range(minRandomHeightRange, maxRandomHeight);

                /*
                if (perlinNoise)
                {
                    heightMap[width, height] = Mathf.PerlinNoise(width * perlinNoiseWidthScale, height * perlinNoiseHeightScale);
                }
                else
                {
                    heightMap[width, height] = Random.Range(minRandomHeightRange, maxRandomHeight);
                }
                */

                heightMap[width, height] = Random.Range(minRandomHeightRange, maxRandomHeight);
                heightMap[width, height] += Mathf.PerlinNoise(width * perlinNoiseWidthScale, height * perlinNoiseHeightScale);
            }
        }

        terrainData.SetHeights(0, 0, heightMap);
    }

    void FlattenTerrain()
    {
        float[,] heightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        for (int width = 0; width < terrainData.heightmapResolution; width++)
        {
            for (int height = 0; height < terrainData.heightmapResolution; height++)
            {
                heightMap[width,height] = 0;
            }
        }
        terrainData.SetHeights(0, 0, heightMap);
    }

    private void AddTerrainTextures()
    {
        TerrainLayer[] terrainLayers = new TerrainLayer[terrainTextureData.Count];

        for (int i = 0; i < terrainTextureData.Count; i++)
        {
            if (addTerrainTexture)
            {
                terrainLayers[i] = new TerrainLayer();
                terrainLayers[i].diffuseTexture = terrainTextureData[i].terrainTexture;
                terrainLayers[i].tileSize = terrainTextureData[i].tileSize;
            }
            else
            {
                terrainLayers[i] = new TerrainLayer();
                terrainLayers[i].diffuseTexture = null;
            }
        }

        terrainData.terrainLayers = terrainLayers;

        float[,] heightMap = terrainData.GetHeights(0,0,terrainData.heightmapResolution, terrainData.heightmapResolution);
    
        float[, ,] alphamapList = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];
    
        for (int height = 0; height < terrainData.alphamapHeight; height++)
        {
            for (int width = 0; width < terrainData.alphamapWidth; width++)
            {
                float[] alphamap = new float[terrainData.alphamapLayers];

                for (int i = 0; i < terrainTextureData.Count; i++)
                {
                    float heightBegin = terrainTextureData[i].minHeight - terrainTextureBlendOffset;
                    float heightEnd = terrainTextureData[i].maxHeight + terrainTextureBlendOffset;

                    if (heightMap[width, height] >= heightBegin && heightMap[width, height] <= heightEnd)
                    {
                        alphamap[i] = 1;
                    }
                }

                Blend(alphamap);

                for (int j = 0; j < terrainTextureData.Count; j++)
                {
                    alphamapList[width,height, j] = alphamap[j];   
                }
            }
        }

        terrainData.SetAlphamaps(0,0,alphamapList);
    }

    private void Blend(float[] alphamap)
    {
        float total = 0;

        for (int i = 0; i < alphamap.Length; i++)
        {
            total += alphamap[i];
        }

        for (int i = 0; i < alphamap.Length; i++)
        {
            alphamap[i] = alphamap[i] / total;
        }
    }

    private void AddTrees()
    {
        TreePrototype[] trees = new TreePrototype[treeData.Count];

        for (int i = 0; i < treeData.Count; i++)
        {
            trees[i] = new TreePrototype();
            trees[i].prefab = treeData[i].treeMesh;
        }

        terrainData.treePrototypes = trees;

        List<TreeInstance> treeInstanceList = new List<TreeInstance>();

        if (addTrees)
        {
            for (int z = 0; z < terrainData.size.z; z += treeSpacing)
            {
                for (int x = 0; x < terrainData.size.x; x += treeSpacing)
                {
                    for (int treeIndex = 0; treeIndex < trees.Length; treeIndex++)
                    {
                        if (treeInstanceList.Count < maxTrees)
                        {
                            float currentHeight = terrainData.GetHeight(x,z) / terrainData.size.y; //this is going to give us a eight value between 0 and 1

                            if (currentHeight >= treeData[treeIndex].minHeight && currentHeight <= treeData[treeIndex].maxHeight)
                            {
                                float randomX = (x + Random.Range(-5.0f, 5.0f)) / terrainData.size.x;

                                float randomZ = (z + Random.Range(-5.0f, 5.0f)) / terrainData.size.z;

                                TreeInstance treeInstance = new TreeInstance();

                                treeInstance.position = new Vector3(randomX, currentHeight, randomZ);
                                treeInstance.rotation = Random.Range(0, 360);
                                treeInstance.prototypeIndex = treeIndex;
                                treeInstance.color = Color.white;
                                treeInstance.lightmapColor = Color.white;
                                treeInstance.heightScale = 0.95f;
                                treeInstance.widthScale = 0.95f ;

                                treeInstanceList.Add(treeInstance);
                            }
                        }
                    }
                }
            }
        }

        terrainData.treeInstances = treeInstanceList.ToArray();
    }

    void OnDestroy()
    {
        if (flattenTerrain)
        {
            FlattenTerrain();
        }
    }
}
