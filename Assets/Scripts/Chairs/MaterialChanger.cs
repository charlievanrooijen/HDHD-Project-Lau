using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material[] materials; // Array of materials to cycle through
    public Renderer[] targetRenderers; // Array of renderers to change materials of
    private int currentMaterialIndex = 0; // Current index in the materials array

    // Call this method to change to the next material
    public void ChangeToNextMaterial()
    {
        if (materials.Length == 0 || targetRenderers.Length == 0) return;

        // Update the material index
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;

        // Apply the new material to all target renderers
        foreach (var renderer in targetRenderers)
        {
            renderer.material = materials[currentMaterialIndex];
        }
    }
}
