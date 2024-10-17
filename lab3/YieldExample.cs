using UnityEngine;
using System.Collections;

public class YieldExample : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GenerateNumbers());
    }

    IEnumerator GenerateNumbers()
    {
        Debug.Log("Starting number generation...");
        for (int i = 1; i <= 5; i++)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second before continuing
            Debug.Log("Generated number: " + i);
        }
        Debug.Log("Number generation complete.");
    }
}

/*
 * Explanation of yield:
 * - The yield keyword is used in coroutines to pause the execution of the function and resume it later.
 * - In the example above, GenerateNumbers is a coroutine that generates numbers with a delay of 1 second between each generation.
 * - yield return new WaitForSeconds(1) pauses the coroutine for 1 second, allowing other code to run before resuming.
 * - This approach is useful for creating non-blocking delays or implementing actions that happen over time.
 */
