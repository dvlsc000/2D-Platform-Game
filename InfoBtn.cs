using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject infoPanel; // Reference to the panel containing additional info
    public Button button; // Reference to the button
    // Track if additional panel is visible
    private bool isAdditionalInfoVisible = false;

    void Start()
    {
        // Add a listener to the button click event
        button.onClick.AddListener(OnButtonClick);
        
        // Hide the additional info panel initially
        infoPanel.SetActive(false);
    }

    void OnButtonClick()
    {
        // Toggle the visibility of the additional info panel
        isAdditionalInfoVisible = !isAdditionalInfoVisible;
        // Set the panel's active state based on the flag
        infoPanel.SetActive(isAdditionalInfoVisible);
    }
}
