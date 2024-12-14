using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLights : MonoBehaviour {
    public int windowMaterialIndex;
    public Color lightColor;
    public bool areLightsOn;
    private Color defaultColor;
    private MeshRenderer mr;

    private void Start() {
        mr = GetComponent<MeshRenderer>();
        defaultColor = mr.sharedMaterials[windowMaterialIndex].color; // sharedMaterials ile başlangıç rengi
        SetLights(areLightsOn);
    }

    public void SetLights(bool isOn) {
        // Eğer ışık açıldıysa URP Lit shader'ını kullan, kapalıysa Standart Shader'a geç
        if (isOn) {
            mr.sharedMaterials[windowMaterialIndex].shader = Shader.Find("Universal Render Pipeline/Lit");
        } else {
            mr.sharedMaterials[windowMaterialIndex].shader = Shader.Find("Universal Render Pipeline/Unlit"); // Veya başka bir uygun shader
        }
        
        mr.sharedMaterials[windowMaterialIndex].color = isOn ? lightColor : defaultColor;
    }
}
