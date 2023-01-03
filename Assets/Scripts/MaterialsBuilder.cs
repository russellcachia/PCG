using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsBuilder
{
    private List<Material> materialsList = new List<Material>();

    public MaterialsBuilder()
    {
        //index 0
        Material whiteMaterial = new Material(Shader.Find("Specular"));
        whiteMaterial.color = Color.white;

        //index 1
        Material blackMaterial = new Material(Shader.Find("Specular"));
        blackMaterial.color = Color.black;

        //index 2
        Material grayMaterial = new Material(Shader.Find("Specular"));
        grayMaterial.color = Color.gray;


        materialsList.Add(whiteMaterial);
        materialsList.Add(blackMaterial);
        materialsList.Add(grayMaterial);
    }

    public List<Material> MaterialsList(){
        return materialsList;
    }
}
