using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Grayscale : MonoBehaviour
{
    // variables
    [SerializeField]
    Material greyscaleMat = null;

    [SerializeField]
    Material colorMat = null;

    // states
    [SerializeField]
    BoolVariable isExplorationLevel = null;
    

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        if (isExplorationLevel.Value)
        {
            // Copy the source Render Texture to the destination,
            // applying the material along the way.
            Graphics.Blit(src, dest, greyscaleMat);
        }
        else
        {
            Graphics.Blit(src, dest,colorMat);
        }
    }
}
