using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("AI Settings")]
    public Transform player;
    public float chaseRange = 10f;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    private NavMeshAgent agent;

    [Header("Health")]
    public int hitsToKill = 2;
    private int currentHits = 0;

    [Header("Spawner Reference")]
    public EnemySpawner spawner; // Gán khi spawn

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextPatrolPoint();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= chaseRange)
        {
            agent.SetDestination(player.position); 
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                GoToNextPatrolPoint(); // Patrol
            }
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    // 👉 Bạn thêm hàm này nếu chưa có:
    public void TakeDamage()
    {
        currentHits++;
        if (currentHits >= hitsToKill)
        {
            Die();
        }
    }

    void Die()
    {
        
        if (KillCounter.instance != null)
        {
            KillCounter.instance.AddKill();
        }

        if (spawner != null)
        {
            spawner.RespawnEnemy();
        }

        Destroy(gameObject);
    }
}
