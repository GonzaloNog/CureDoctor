using UnityEngine;

[ExecuteInEditMode]
public class VHSPostProcessing : MonoBehaviour
{
    public Material vhsMaterial; // Material con el Shader VHS

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (vhsMaterial != null)
        {
            Graphics.Blit(src, dest, vhsMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
