using UnityEngine;

public class TestAttributes : MonoBehaviour
{
    // Private field, visible in the Unity inspector due to the [SerializeField] attribute
    [SerializeField]
    private int serializedPrivateValue = 30;

    // Public field, hidden in the inspector due to the [HideInInspector] attribute
    [HideInInspector]
    public int hiddenPublicValue = 40;

    // Field with a range slider in the inspector, allowing values between 0 and 100
    [Range(0, 100)]
    public int rangedValue = 50;

    // Field with a tooltip, displaying a description when hovering over the field in the inspector
    [Tooltip("This is a value with a tooltip to describe its purpose.")]
    public int valueWithTooltip = 10;

    // Field allowing multiline text input in the inspector
    [Multiline]
    public string multilineText = "This is a multiline text field.";

    // Field allowing text input in a larger text area in the inspector
    [TextArea]
    public string textArea = "This is a larger text area for input.";

    void Start()
    {
        Debug.Log("Serialized Private Value: " + serializedPrivateValue);
        Debug.Log("Hidden Public Value: " + hiddenPublicValue);
        Debug.Log("Ranged Value: " + rangedValue);
        Debug.Log("Value With Tooltip: " + valueWithTooltip);
        Debug.Log("Multiline Text: " + multilineText);
        Debug.Log("Text Area: " + textArea);
    }
}

/*
 * Explanation of Attributes:
 * - [SerializeField]: Makes a private field visible in the Unity inspector, allowing it to be edited without exposing it to other scripts.
 * - [HideInInspector]: Hides a public field from the Unity inspector.
 * - [Range(min, max)]: Allows the value of the field to be set using a slider in the inspector, between the specified min and max values.
 * - [Tooltip("Description")]: Adds a tooltip that appears when hovering over the field in the inspector.
 * - [Multiline]: Allows input of multiline text in the inspector.
 * - [TextArea]: Creates a larger text area for input in the inspector.
 */
