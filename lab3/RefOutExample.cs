using UnityEngine;

public class RefOutExample : MonoBehaviour
{
    void Start()
    {
        // Using ref argument
        int refValue = 10;
        Debug.Log("Initial refValue: " + refValue);
        ModifyValueUsingRef(ref refValue);
        Debug.Log("Modified refValue: " + refValue); // Outputs: 20

        // Using out argument
        int outValue;
        ModifyValueUsingOut(out outValue);
        Debug.Log("Modified outValue: " + outValue); // Outputs: 30

        // Without ref or out
        int normalValue = 10;
        Debug.Log("Initial normalValue: " + normalValue);
        ModifyValueWithoutRefOrOut(normalValue);
        Debug.Log("Modified normalValue: " + normalValue); // Outputs: 10 (no change)
    }

    void ModifyValueUsingRef(ref int value)
    {
        // The ref keyword allows us to modify the original value
        value *= 2;
    }

    void ModifyValueUsingOut(out int value)
    {
        // The out keyword requires the method to assign a value before the method returns
        value = 30;
    }

    void ModifyValueWithoutRefOrOut(int value)
    {
        // Without ref or out, this is just a copy of the original value
        value *= 2;
    }
}

/*
 * Explanation of ref and out:
 * - ref: The argument passed with ref must be initialized before it is passed to the method. The method can then modify the original value.
 * - out: The argument passed with out does not need to be initialized before passing it to the method. The method must assign a value before returning.
 * - Without ref or out: The argument is passed by value, meaning a copy is made, and any changes made inside the method do not affect the original variable.
 * - In the example above, ModifyValueUsingRef modifies the original value of refValue, ModifyValueUsingOut assigns a new value to outValue, and ModifyValueWithoutRefOrOut does not affect the original normalValue.
 */
