using UnityEngine;

public class MathfMethodsDemo : MonoBehaviour
{
    void Start()
    {
        // Mathf.Abs: Returns the absolute value
        float negativeValue = -10f;
        float absoluteValue = Mathf.Abs(negativeValue);
        Debug.Log("Absolute Value of -10: " + absoluteValue); // Outputs: 10

        // Mathf.Clamp: Clamps a value between a minimum and a maximum
        float valueToClamp = 15f;
        float clampedValue = Mathf.Clamp(valueToClamp, 0f, 10f);
        Debug.Log("Clamped Value of 15 (0 to 10): " + clampedValue); // Outputs: 10

        // Mathf.Lerp: Linearly interpolates between two values
        float lerpValue = Mathf.Lerp(0f, 100f, 0.25f);
        Debug.Log("Lerp between 0 and 100 at t=0.25: " + lerpValue); // Outputs: 25

        // Mathf.Sqrt: Returns the square root of a value
        float squareRootValue = Mathf.Sqrt(16f);
        Debug.Log("Square Root of 16: " + squareRootValue); // Outputs: 4

        // Mathf.Sin: Returns the sine of an angle (in radians)
        float angleInDegrees = 30f;
        float angleInRadians = Mathf.Deg2Rad * angleInDegrees;
        float sineValue = Mathf.Sin(angleInRadians);
        Debug.Log("Sine of 30 degrees: " + sineValue); // Outputs: 0.5

        // Mathf.Pow: Returns a value raised to a power
        float baseValue = 2f;
        float powerValue = 3f;
        float result = Mathf.Pow(baseValue, powerValue);
        Debug.Log("2 raised to the power of 3: " + result); // Outputs: 8
    }
}

/*
 * Explanation of Mathf Methods:
 * - Mathf.Abs: Returns the absolute value of a number, which is always positive.
 * - Mathf.Clamp: Clamps a value to ensure it falls between a specified minimum and maximum.
 * - Mathf.Lerp: Linearly interpolates between two values based on a parameter 't', where t is between 0 and 1.
 * - Mathf.Sqrt: Calculates the square root of a number.
 * - Mathf.Sin: Calculates the sine of an angle, where the input is in radians.
 * - Mathf.Pow: Raises a value to a specific power.
 */
