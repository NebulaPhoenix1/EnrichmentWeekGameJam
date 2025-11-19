using UnityEngine;
using UnityEditor;

public class PlayerPrefsEditor : EditorWindow
{
    // Variable to hold the value while we edit it in the window
    private int editedHigh;
    private const string KeyName = "HighScore";

    [MenuItem("Tools/Player Preferences")]
    public static void OpenWindow()
    {
        PlayerPrefsEditor window = (PlayerPrefsEditor)EditorWindow.GetWindow(typeof(PlayerPrefsEditor));
        window.titleContent = new GUIContent("Player Preferences");
        window.Show();
    }

    // 1. Load the current value when the window opens
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(KeyName))
        {
            editedHigh = PlayerPrefs.GetInt(KeyName);
        }
    }

    // 2. Rename OUI to OnGUI (Standard Unity method for Editor UI)
    void OnGUI()
    {
        GUILayout.Label("High Score Settings", EditorStyles.boldLabel);

        // Display the CURRENT saved value for reference
        EditorGUILayout.LabelField("Current Saved Value:", PlayerPrefs.GetInt(KeyName, 0).ToString());
        
        EditorGUILayout.Space();

        // Create the Input Field
        // We assign the result back to 'editedHigh' to update it as the user types
        editedHigh = EditorGUILayout.IntField("New High Score:", editedHigh);

        EditorGUILayout.Space();

        // 3. Add a Save Button
        if (GUILayout.Button("Save High Score"))
        {
            PlayerPrefs.SetInt(KeyName, editedHigh);
            PlayerPrefs.Save(); // Writes to disk immediately
            Debug.Log($"High Score updated to: {editedHigh}");
        }

        // Optional: Add a Reset Button
        if (GUILayout.Button("Reset Highscore"))
        {
            PlayerPrefs.DeleteKey(KeyName);
            editedHigh = 0;
            Debug.Log("High Score key deleted.");
        }
    }
}