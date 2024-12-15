using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    ColorSettings settings;
    Texture2D texture;
    const int textureResolution = 50;

    public void UpdateSettings(ColorSettings settings)
    {
        if (!settings.planetMaterial)
        {
            settings.planetMaterial = new Material(Shader.Find("Shader Graphs/Planet Shader"));
        }

        this.settings = settings;
        if (!texture)
        {
            texture = new Texture2D(textureResolution, 1);
        }
    }

    public void UpdateElevation(MinMax elevationMinMax)
    {
        if (!settings.planetMaterial)
        {
            settings.planetMaterial = new Material(Shader.Find("Planet Shader"));
        }
        settings.planetMaterial.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max));
    }

    public void UpdateColors()
    {
        if (!settings.planetMaterial)
        {
            settings.planetMaterial = new Material(Shader.Find("Planet Shader"));
        }
        Color[] colors = new Color[textureResolution];
        for (int i = 0; i < textureResolution; i++)
        {
            colors[i] = settings.gradient.Evaluate(i / (textureResolution - 1f));
        }
        texture.SetPixels(colors);
        texture.Apply();
        settings.planetMaterial.SetTexture("_texture", texture);
    }
}
