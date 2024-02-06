using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage = 25f;

    public EnemyHealth enemyHealth;
    public BossHealth bossHealth;

    // Hàm này được gọi khi có trigger va chạm
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có tag là "Enemy" hay không
        if (other.CompareTag("Enemy"))
        {
            // Nếu là nhân vật Enemy, hủy đối tượng đạn
            Destroy(gameObject);

            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.EnemyHitDamage(damage);
        }
        else if (other.CompareTag("Boss"))
        {
            // Nếu là nhân vật Boss, hủy đối tượng đạn
            Destroy(gameObject);

            bossHealth = other.gameObject.GetComponent<BossHealth>();
            bossHealth.BossHitDamage(damage);
        }
    }
}
