using UnityEngine;
using System.Collections.Generic;

public class RandomCubeGenerator : MonoBehaviour
{
    private List<GameObject> cubes = new List<GameObject>();
    private int maxCubes = 10;
    private float spawnInterval = 1f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            GenerateCube();
            timer = 0f;
        }
    }

    void GenerateCube()
    {
        if (cubes.Count >= maxCubes)
        {
            GameObject oldestCube = cubes[0];
            cubes.RemoveAt(0);
            Destroy(oldestCube);
        }

        // Create a new cube at position (0, 0, 0)
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = Vector3.zero;

        // Assign a random color to the cube
        Renderer renderer = cube.GetComponent<Renderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);

        // Add a Rigidbody component to apply force
        Rigidbody rb = cube.AddComponent<Rigidbody>();

        // Apply a random force in a random direction
        Vector3 randomForce = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        rb.AddForce(randomForce, ForceMode.Impulse);

        // Add the cube to the list
        cubes.Add(cube);
    }
}
