using System.Collections.Generic;
using UnityEngine;

public class LinearMazeGenerator : MonoBehaviour
{
    [Header("Stage Settings")]
    public GameObject fixedFirstStage;          // 👈 always used in slot 0
    public List<GameObject> stagePrefabs;        // 👈 remaining stages
    public float stageLength = 20f;

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        // Copy list so original isn't modified
        List<GameObject> shuffledStages = new List<GameObject>(stagePrefabs);

        // Shuffle remaining stages
        for (int i = 0; i < shuffledStages.Count; i++)
        {
            int randomIndex = Random.Range(i, shuffledStages.Count);
            (shuffledStages[i], shuffledStages[randomIndex]) =
                (shuffledStages[randomIndex], shuffledStages[i]);
        }

        int index = 0;

        // 🔹 Place fixed stage FIRST
        Instantiate(
            fixedFirstStage,
            new Vector3(index * stageLength, 0, 0),
            Quaternion.identity,
            transform
        );

        index++;

        // 🔹 Place shuffled stages AFTER
        foreach (GameObject stage in shuffledStages)
        {
            Instantiate(
                stage,
                new Vector3(index * stageLength, 0, 0),
                Quaternion.identity,
                transform
            );
            index++;
        }
    }
}
