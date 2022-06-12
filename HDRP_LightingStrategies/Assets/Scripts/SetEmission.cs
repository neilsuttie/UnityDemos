using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEmission : MonoBehaviour
{
    public Renderer _emissiveObject;
    // Start is called before the first frame update
    void Start()
    {
        _emissiveObject = GetComponent<Renderer>();
        _emissiveObject.material.EnableKeyword("_EmissionColor");
    }

    public void SetEmissiveMaterial(bool isOn)
    {
        if (isOn)
        {
            _emissiveObject.material.SetFloat("_EmissiveIntensity", 20);
            UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(_emissiveObject.material);
        }
        else
        {
            _emissiveObject.material.SetFloat("_EmissiveIntensity", 0);
            UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(_emissiveObject.material);
        }

    }

    public static void UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(Material material)
    {
        const string kEmissiveColorLDR = "_EmissiveColorLDR";
        const string kEmissiveColor = "_EmissiveColor";
        const string kEmissiveIntensity = "_EmissiveIntensity";

        if (material.HasProperty(kEmissiveColorLDR) && material.HasProperty(kEmissiveIntensity) && material.HasProperty(kEmissiveColor))
        {
            // Important: The color picker for kEmissiveColorLDR is LDR and in sRGB color space but Unity don't perform any color space conversion in the color
            // picker BUT only when sending the color data to the shader... So as we are doing our own calculation here in C#, we must do the conversion ourselves.
            Color emissiveColorLDR = material.GetColor(kEmissiveColorLDR);
            Color emissiveColorLDRLinear = new Color(Mathf.GammaToLinearSpace(emissiveColorLDR.r), Mathf.GammaToLinearSpace(emissiveColorLDR.g), Mathf.GammaToLinearSpace(emissiveColorLDR.b));
            material.SetColor(kEmissiveColor, emissiveColorLDRLinear * material.GetFloat(kEmissiveIntensity));
        }
    }
}
