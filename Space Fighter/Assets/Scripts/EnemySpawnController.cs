using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundaries
{
    public float bottom, top, left, right;
}

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemiesParent;
    public GameObject[] enemies;
    public float[] primarySideValue = new float[4];
    public Boundaries boundaries;
    
    private void Start()
    {
        InvokeRepeating("EnemySpawner", 2f, 0.75f);
    }

    private void EnemySpawner()
    {
        int side = Random.Range(0, 4);
        float secondarySideValue;
        Vector3 spawnPosition;

        switch(side)
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
        GameObject enemy = Instantiate(enemies[Random.Range(0, 3)], spawnPosition, Quaternion.identity);
        enemy.GetComponent<EnemyMovementController>().Move(side);
        enemy.transform.parent = enemiesParent.transform;
     }
}
