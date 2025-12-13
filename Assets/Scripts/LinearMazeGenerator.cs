using System.Collections.Generic;
using UnityEngine;

public class LinearMazeGenerator : MonoBehaviour
{
    [Header("Stage Settings")]
    public List<GameObject> stagePrefabs;
    public float stageLength = 20f; // width of each stage

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        // Create a copy so we don’t modify the original list
        List<GameObject> shuffledStages = new List<GameObject>(stagePrefabs);

        // Shuffle stages
        for (int i = 0; i < shuffledStages.Count; i++)
        {
            int randomIndex = Random.Range(i, shuffledStages.Count);
            GameObject temp = shuffledStages[i];
            shuffledStages[i] = shuffledStages[randomIndex];
            shuffledStages[randomIndex] = temp;
        }

        // Place stages in a row
        for (int i = 0; i < shuffledStages.Count; i++)
        {
            Vector3 position = new Vector3(i * stageLength, 0, 0);
            Instantiate(shuffledStages[i], position, Quaternion.identity, transform);
        }
    }
}
