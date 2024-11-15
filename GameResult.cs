using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    void Start()
    {
        // Call update text method when the game starts
        UpdateResultText();
    }

    // Mehotd to update the result displayed in the game
    void UpdateResultText()
    {
        // Check if the PlayerPrefs key exists to avoid errors
        if (PlayerPrefs.HasKey("ResultText"))
        {
            // Get the result text
            string resultText = PlayerPrefs.GetString("ResultText");
            
            // Find the text component with the "WinOrLose" tag and update its text
            Text resultTextComponent = GameObject.FindGameObjectWithTag("WinOrLose").GetComponent<Text>();
        
            if (resultTextComponent != null)
            {
                // Set the text of the component
                resultTextComponent.text = resultText;
            }
            // Delete the "ResultText" key from PlayerPrefs to prevent displaying it again
            PlayerPrefs.DeleteKey("ResultText");
        }
    }
}
