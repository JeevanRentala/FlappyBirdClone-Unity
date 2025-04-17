using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBuilder : MonoBehaviour
{
    [SerializeField] public GameObject pipeCratePrefab;
    [SerializeField] public Transform topPipe;
    [SerializeField] public Transform bottomPipe;

    public int minBottomCrates = 1;
    public int maxBottomCrates = 6;
    public float crateHeight = 1f;

    private float bottomStartY = -3.5f;
    private float gapSizeInCrates = 2f;

    void Start()
    {
        BuildPipe();
    }

    void BuildPipe()
    {
        // Random number of bottom crates
        int bottomCount = Random.Range(minBottomCrates, maxBottomCrates + 1);

        // Gap starts right after the last bottom crate
        float topStartY = bottomStartY + bottomCount * crateHeight + gapSizeInCrates * crateHeight;

        // Calculate how many top crates can fit above, but at least 1
        int maxTopY = 6; // Adjust based on your scene's vertical limit
        int topCount = Mathf.FloorToInt((maxTopY - topStartY) / crateHeight);
        topCount = Mathf.Max(1, topCount); // Always have at least one top crate

        BuildBottomPipe(bottomCount);
        BuildTopPipe(topCount, topStartY);
    }

    void BuildBottomPipe(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float y = bottomStartY + i * crateHeight;
            Vector3 pos = new Vector3(bottomPipe.position.x, y, bottomPipe.position.z);
            Instantiate(pipeCratePrefab, pos, Quaternion.identity, bottomPipe);
        }
    }

    void BuildTopPipe(int count, float startY)
    {
        for (int i = 0; i < count; i++)
        {
            float y = startY + i * crateHeight;
            Vector3 pos = new Vector3(topPipe.position.x, y, topPipe.position.z);
            Instantiate(pipeCratePrefab, pos, Quaternion.identity, topPipe);
        }
    }
}
