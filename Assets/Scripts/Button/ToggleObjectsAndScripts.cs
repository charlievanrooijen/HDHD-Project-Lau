using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq; // For convenience methods on arrays

public class ToggleObjectsScriptsAndAudio : MonoBehaviour
{
    public XRBaseInteractable interactableButton; // Reference to the XR button
    public GameObject[] objectsToToggle; // Array of GameObjects to toggle
    public MonoBehaviour[] scriptsToToggle; // Array of scripts (MonoBehaviour) to toggle
    public AudioSource[] audioSourcesToToggle; // Array of AudioSource components to toggle

    void OnEnable()
    {
        interactableButton.selectEntered.AddListener(ToggleActiveState);
    }

    void OnDisable()
    {
        interactableButton.selectEntered.RemoveListener(ToggleActiveState);
    }

    private void ToggleActiveState(SelectEnterEventArgs arg)
    {
        // Toggle GameObjects
        foreach (var obj in objectsToToggle)
        {
            obj.SetActive(!obj.activeSelf);
        }

        // Toggle scripts
        foreach (var script in scriptsToToggle)
        {
            script.enabled = !script.enabled;
        }

        // Toggle AudioSources
        foreach (var audioSource in audioSourcesToToggle)
        {
            audioSource.enabled = !audioSource.enabled;
        }
    }
}
