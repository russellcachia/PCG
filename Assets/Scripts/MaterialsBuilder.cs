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

        //index 3
        Material blueMaterial = new Material(Shader.Find("Specular"));
        blueMaterial.color = Color.blue;

        //index 4
        Material greenMaterial = new Material(Shader.Find("Specular"));
        greenMaterial.color = Color.green;

        //index 5
        Material yellowMaterial = new Material(Shader.Find("Specular"));
        yellowMaterial.color = Color.yellow;

        //index 6
        Material redMaterial = new Material(Shader.Find("Specular"));
        redMaterial.color = Color.red;



        materialsList.Add(whiteMaterial);
        materialsList.Add(blackMaterial);
        materialsList.Add(grayMaterial);
        materialsList.Add(blueMaterial);
        materialsList.Add(greenMaterial);
        materialsList.Add(yellowMaterial);
        materialsList.Add(redMaterial);
    }

    public List<Material> MaterialsList(){
        return materialsList;
    }
}
