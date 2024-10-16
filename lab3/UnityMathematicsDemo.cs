using UnityEngine;
using Unity.Mathematics;

public class UnityMathematicsDemo : MonoBehaviour
{
    void Start()
    {
        // float3 example: Represents a vector of three floating-point numbers
        float3 vectorA = new float3(1f, 2f, 3f);
        float3 vectorB = new float3(4f, 5f, 6f);

        // math.dot: Calculates the dot product of two vectors
        float dotProduct = math.dot(vectorA, vectorB);
        Debug.Log("Dot product of vectorA and vectorB: " + dotProduct); // Outputs: 32

        // math.cross: Calculates the cross product of two vectors
        float3 crossProduct = math.cross(vectorA, vectorB);
        Debug.Log("Cross product of vectorA and vectorB: " + crossProduct); // Outputs: (-3, 6, -3)

        // math.normalize: Normalizes a vector (makes its magnitude equal to 1)
        float3 normalizedVector = math.normalize(vectorA);
        Debug.Log("Normalized vectorA: " + normalizedVector); // Outputs a unit vector in the same direction as vectorA

        // math.distance: Calculates the distance between two points
        float distance = math.distance(vectorA, vectorB);
        Debug.Log("Distance between vectorA and vectorB: " + distance); // Outputs the distance between vectorA and vectorB

        // math.clamp: Clamps a value between a minimum and a maximum
        float valueToClamp = 15f;
        float clampedValue = math.clamp(valueToClamp, 0f, 10f);
        Debug.Log("Clamped Value of 15 (0 to 10): " + clampedValue); // Outputs: 10
    }
}

/*
 * Explanation of Unity.Mathematics Methods:
 * - math.dot: Calculates the dot product of two vectors, which is useful for determining the angle between them or the magnitude of projection.
 * - math.cross: Calculates the cross product of two vectors, which results in a vector perpendicular to both input vectors.
 * - math.normalize: Normalizes a vector to a unit vector, maintaining direction but making its magnitude equal to 1.
 * - math.distance: Calculates the distance between two points in space.
 * - math.clamp: Clamps a value to ensure it falls within a specified range, similar to Mathf.Clamp.
 */
