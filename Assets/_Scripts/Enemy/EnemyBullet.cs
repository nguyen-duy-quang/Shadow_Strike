using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 2f;

    public PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Hàm này được gọi khi có trigger va chạm
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có tag là "Player" hay không
        if (other.CompareTag("Player"))
        {
            // Nếu là nhân vật Player, hủy đối tượng đạn
            Destroy(gameObject);
            if(playerHealth != null)
            {
                playerHealth.playerHitDamage(damage);
            }
        }
    }
}
