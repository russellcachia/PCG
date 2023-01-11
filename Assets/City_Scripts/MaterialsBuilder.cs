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
        
        //index 7
        Material randomMaterial = new Material(Shader.Find("Specular"));
        randomMaterial.color = Random.ColorHSV(0f,1f,0f,1f,0f,1f);
        

        materialsList.Add(whiteMaterial);       //0
        materialsList.Add(blackMaterial);       //1
        materialsList.Add(grayMaterial);        //2
        materialsList.Add(blueMaterial);        //3
        materialsList.Add(greenMaterial);       //4
        materialsList.Add(yellowMaterial);      //5
        materialsList.Add(redMaterial);         //6
        materialsList.Add(randomMaterial);      //7
    }

    public List<Material> MaterialsList(){
        return materialsList;
    }
}
