using UnityEngine;
using UnityEngine.UI;

public class timeDisplay : MonoBehaviour
{
    public Text timeText; // Reference to the UI Text component

    void Start()
    {
        // Call UpdateTime function immediately and then every second using InvokeRepeating
        UpdateTime();
        InvokeRepeating(nameof(UpdateTime), 1f, 1f);
    }

    void UpdateTime()
    {
        // Get the current system time
        System.DateTime currentTime = System.DateTime.Now;

        // Format the time as a string
        string timeString = currentTime.ToString("HH:mm:ss");

        // Set the text of the UI Text component to the formatted time
        timeText.text = timeString;
    }
}
