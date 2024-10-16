using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class CollectionBenchmark : MonoBehaviour
{
    private List<int> list = new List<int>();
    private HashSet<int> hashSet = new HashSet<int>();
    private Dictionary<int, int> dictionary = new Dictionary<int, int>();
    private const int numElements = 100000;

    void Start()
    {
        Stopwatch stopwatch = new Stopwatch();

        // Benchmark List Add
        stopwatch.Start();
        for (int i = 0; i < numElements; i++)
        {
            list.Add(i);
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log("List Add: " + stopwatch.ElapsedMilliseconds + " ms");
        stopwatch.Reset();

        // Benchmark HashSet Add
        stopwatch.Start();
        for (int i = 0; i < numElements; i++)
        {
            hashSet.Add(i);
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log("HashSet Add: " + stopwatch.ElapsedMilliseconds + " ms");
        stopwatch.Reset();

        // Benchmark Dictionary Add
        stopwatch.Start();
        for (int i = 0; i < numElements; i++)
        {
            dictionary.Add(i, i);
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log("Dictionary Add: " + stopwatch.ElapsedMilliseconds + " ms");
        stopwatch.Reset();

        // Benchmark List Contains
        stopwatch.Start();
        for (int i = 0; i < numElements; i++)
        {
            list.Contains(i);
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log("List Contains: " + stopwatch.ElapsedMilliseconds + " ms");
        stopwatch.Reset();

        // Benchmark HashSet Contains
        stopwatch.Start();
        for (int i = 0; i < numElements; i++)
        {
            hashSet.Contains(i);
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log("HashSet Contains: " + stopwatch.ElapsedMilliseconds + " ms");
        stopwatch.Reset();

        // Benchmark Dictionary ContainsKey
        stopwatch.Start();
        for (int i = 0; i < numElements; i++)
        {
            dictionary.ContainsKey(i);
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log("Dictionary ContainsKey: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}

/*
 * Explanation:
 * - This script benchmarks common operations (Add and Contains) for different generic collections in C#.
 * - List, HashSet, and Dictionary are tested for adding elements and checking for their existence.
 * - The results show the relative performance of each collection type for the specified operations.
 *   Generally, HashSet and Dictionary are much faster for lookups compared to List.
 */
