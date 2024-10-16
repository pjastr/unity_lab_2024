using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class RequireAndDisallowExample : MonoBehaviour
{
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Rigidbody component is present as required.");
        }
        else
        {
            Debug.LogError("Rigidbody component is missing, which should not happen due to [RequireComponent].");
        }
    }
}

/*
 * Explanation of Attributes:
 * - [RequireComponent(typeof(Component))]: Forces the GameObject to have the specified component before adding this script.
 * - [DisallowMultipleComponent]: Prevents multiple instances of the same script from being added to a single GameObject.
 */
