using UnityEngine;

public class UnityLifecycleDemo : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake: Called once when the script instance is being loaded.");
    }

    void Start()
    {
        Debug.Log("Start: Called before the first frame update, after all Awake calls.");
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate: Called at a fixed time interval, used for physics-related updates.");
    }

    void Update()
    {
        Debug.Log("Update: Called once per frame, used for regular updates like input handling.");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate: Called once per frame, after all Update calls, used for operations that depend on Update.");
    }
}

/*
 * Explanation of Unity Lifecycle Methods:
 * - Awake: This method is called when the script instance is loaded, and is used for initialization before the game starts.
 * - Start: Called before the first frame update, after all Awake calls, and is used for any setup that relies on other objects being initialized.
 * - FixedUpdate: This method is called at consistent intervals, and is used for physics calculations to ensure consistent behavior regardless of frame rate.
 * - Update: Called once per frame, and is typically used for input handling and other per-frame logic.
 * - LateUpdate: Called once per frame, after all Update calls, making it ideal for operations that need to happen after Update, such as following a camera.
 */
