using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ContextMenuExample : MonoBehaviour
{
    // Method that can be triggered from the context menu in the inspector
    [ContextMenu("Reset Values")]
    void ResetValues()
    {
        Debug.Log("Values have been reset.");
    }

    // Public field with a context menu item that triggers a method
    [ContextMenuItem("Log Value", "LogFieldValue")]
    public int valueWithContextMenuItem = 20;

    void LogFieldValue()
    {
        Debug.Log("Value With Context Menu Item: " + valueWithContextMenuItem);
    }
}

[InitializeOnLoad]
public class InitializeOnLoadExample
{
    static InitializeOnLoadExample()
    {
        Debug.Log("InitializeOnLoadExample has been initialized when Unity started.");
    }
}

/*
 * Explanation of Attributes:
 * - [ContextMenu("Option Name")]: Adds an option to the context menu in the inspector that, when selected, invokes the specified method.
 * - [ContextMenuItem("Option Name", "MethodName")]: Adds an item to the context menu for a specific field.
 * - [ExecuteInEditMode]: The script will run in the Unity Editor even when the game is not in play mode.
 * - [InitializeOnLoad]: The class is initialized when Unity starts.
 */
