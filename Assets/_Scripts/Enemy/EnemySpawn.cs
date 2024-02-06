using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    public int maxEnemyList = 15;

    private WaitForSeconds spawnWait;
    public GameManager gameManager;

    void Start()
    {
        spawnWait = new WaitForSeconds(spawnInterval);

        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return spawnWait;

            if (gameManager.CanSpawnEnemy && enemyList.Count < maxEnemyList)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation, transform);
                enemyList.Add(enemy);
            }
            else
            {
                Debug.Log("Không tạo thêm enemy, hoặc đã đạt số lượng tối đa");
            }
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
        }
    }
}
