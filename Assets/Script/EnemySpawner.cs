using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnDelay = 3f;

    [Header("References To Inject")]
    public Transform player;                      
    public Transform[] patrolPoints;              

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        if (ai != null)
        {
            ai.spawner = this;
            ai.player = player;
            ai.patrolPoints = patrolPoints;
        }
    }

    public void RespawnEnemy()
    {
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnEnemy();
    }
}
