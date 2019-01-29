using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnBoundaries
{
    public float bottom, top, left, right;
}

public class PowerUpsSpawnController : MonoBehaviour
{
    public GameObject powerUpsParent;
    public GameObject[] powerUps;
    public float[] primarySideValue = new float[4];
    public SpawnBoundaries boundaries;

    private void Start()
    {
        InvokeRepeating("PowerUpsSpawner", 8f, 5f);
    }

    private void PowerUpsSpawner()
    {
        int side = Random.Range(0, 4);
        float secondarySideValue;
        Vector3 spawnPosition;

        switch (side)
        {
            case 0:
                {
                    secondarySideValue = Random.Range(boundaries.bottom, boundaries.top);
                    spawnPosition = new Vector3(primarySideValue[side], secondarySideValue, 0f);
                    break;
                }
            case 1:
                {
                    secondarySideValue = Random.Range(boundaries.left, boundaries.right);
                    spawnPosition = new Vector3(secondarySideValue, primarySideValue[side], 0f);
                    break;
                }
            case 2:
                {
                    secondarySideValue = Random.Range(boundaries.bottom, boundaries.top);
                    spawnPosition = new Vector3(primarySideValue[side], secondarySideValue, 0f);
                    break;
                }
            case 3:
                {
                    secondarySideValue = Random.Range(boundaries.left, boundaries.right);
                    spawnPosition = new Vector3(secondarySideValue, primarySideValue[side], 0f);
                    break;
                }
            default:
                {
                    spawnPosition = new Vector3(0f, 0f, 0f);
                    break;
                }
        }
        GameObject powerUp = Instantiate(powerUps[Random.Range(0, 2)], spawnPosition, Quaternion.identity);
        powerUp.GetComponent<PowerUpsMovementController>().Move(side);
        powerUp.transform.parent = powerUpsParent.transform;
    }
}
