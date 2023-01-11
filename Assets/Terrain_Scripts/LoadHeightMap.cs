using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LoadHeightMap : MonoBehaviour
{
    private Terrain terrain;
    private TerrainData terrainData;

    [SerializeField]
    private Texture2D heightMapImage;

    [SerializeField]
    private Vector3 heightMapScale = new Vector3(1, 1, 1);

    [SerializeField]
    private bool loadHieghtMap = true;

    [SerializeField]
    private bool flattenTerrainOnExit = true;

    [SerializeField]
    private bool loadHeightMapInEditMode = false;

    [SerializeField]
    private bool flattenTerrainInEditMode = false;

    // Start is called before the first frame update
    void Start()
    {
        //terrain = this.GetComponent<Terrain>();
        //terrainData = Terrain.activeTerrain.terrainData;

        if (loadHieghtMap)
        {
            LoadHeightMapImage();
        }
    }

    void LoadHeightMapImage()
    {
        terrain = this.GetComponent<Terrain>();
        terrainData = Terrain.activeTerrain.terrainData;

        float[,] heightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        for (int width = 0; width < terrainData.heightmapResolution; width++)
        {
            for (int height = 0; height < terrainData.heightmapResolution; height++)
            {
                heightMap[width,height] = heightMapImage.GetPixel((int)(width * heightMapScale.x), (int)(height * heightMapScale.z)).grayscale * 
                heightMapScale.y;
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

    //This method is called in edit mode only
    void OnValidate()
    {
        if (flattenTerrainInEditMode)
        {
            FlattenTerrain();
        }else if (loadHeightMapInEditMode)
        {
            LoadHeightMapImage();
        }
    }

    void OnDestroy()
    {
        if (flattenTerrainOnExit)
        {
            FlattenTerrain();
        }
    }
}
