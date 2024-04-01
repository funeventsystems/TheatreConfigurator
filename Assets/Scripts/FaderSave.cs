using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class DropdownData
{
    public string dropdownName;
    public string selectedOption;
}

public class FaderSave : MonoBehaviour
{
    public Dropdown[] dropdowns;
    public Button saveButton;

    private void Start()
    {
        // Assign a listener to the save button
        saveButton.onClick.AddListener(SaveDropdownValues);
    }

    private void SaveDropdownValues()
    {
        // Check if any dropdowns are assigned
        if (dropdowns == null || dropdowns.Length == 0)
        {
            Debug.LogWarning("No dropdowns assigned.");
            return;
        }

        // Create a list to store dropdown data
        List<DropdownData> dropdownDataList = new List<DropdownData>();

        // Loop through each dropdown and store its data
        foreach (Dropdown dropdown in dropdowns)
        {
            DropdownData dropdownData = new DropdownData();
            dropdownData.dropdownName = dropdown.name;

            // Check if dropdown is assigned and has options
            if (dropdown != null && dropdown.options != null && dropdown.options.Count > 0)
            {
                dropdownData.selectedOption = dropdown.options[dropdown.value].text;
                dropdownDataList.Add(dropdownData);
            }
            else
            {
                Debug.LogWarning("Dropdown " + dropdown.name + " is not properly assigned or has no options.");
            }

            // Debugging: Print dropdown name and selected option
            Debug.Log("Dropdown " + dropdownData.dropdownName + ", Selected Option: " + dropdownData.selectedOption);
        }

        // Convert dropdown data list to JSON
        string jsonData = SerializeDropdownDataList(dropdownDataList);

        // Save JSON string to PlayerPrefs
        PlayerPrefs.SetString("DropdownValues", jsonData);
        PlayerPrefs.Save();
        Debug.Log(jsonData);

        Debug.Log("Dropdown values saved to PlayerPrefs.");
    }

    // Custom serialization method for List<DropdownData>
    private string SerializeDropdownDataList(List<DropdownData> data)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("{\"DropdownData\": [");
        for (int i = 0; i < data.Count; i++)
        {
            if (i > 0)
                sb.Append(",");
            sb.Append("{");
            sb.Append("\"dropdownName\": \"" + data[i].dropdownName + "\",");
            sb.Append("\"selectedOption\": \"" + data[i].selectedOption + "\"");
            sb.Append("}");
        }
        sb.Append("]}");
        return sb.ToString();
    }
}
