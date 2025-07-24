using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Tự hủy sau 2 giây
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)  
            {
                enemy.TakeDamage(); // Gây 1 hit
            }
        }

        Destroy(gameObject); // Đạn biến mất
    }
}
