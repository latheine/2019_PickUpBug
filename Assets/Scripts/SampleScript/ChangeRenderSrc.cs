using UnityEngine;

public class ChangeRenderSrc : MonoBehaviour
{
    public RenderTexture source;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(source, dest);
    }
}