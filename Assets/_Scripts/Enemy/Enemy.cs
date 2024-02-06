using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;

    public Seeker seeker;
    public bool updateContinuesPath;

    // Shoot
    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;

    private bool reachDestination = false;
    Path path;
    Coroutine moveCoroutine;

    private void Start()
    {
        InvokeRepeating("CaculatePath", 0, 0.5f);

        reachDestination = true;
    }

    private void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(fireCooldown < 0)
        {
            fireCooldown = timeBtwFire;

            //Shoot
            EnemyFireBullet();
        }    
    }

    private void EnemyFireBullet()
    {
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);

            Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
            Vector3 playerPos = player.transform.position;
            Vector3 direction = playerPos - transform.position;
            rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
        }
    }


    private void CaculatePath()
    {
        Vector2 target = FindTaget();

        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathCallBack);
    }    

    private void OnPathCallBack(Path p)
    {
        if (p.error) return;
        path = p;

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (gameObject.activeSelf)  // Kiểm tra xem đối tượng có đang active hay không
        {
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(MoveTargetCoroutine());
        }
    }


    private IEnumerator MoveTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;

        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            // Xác định hướng từ enemy đến player
            float xDirection = Mathf.Sign(direction.x);

            // Quay mặt về hướng của player
            if (xDirection != 0)
            {
                // Đặt scale.x để quay mặt về hướng player
                transform.localScale = new Vector3(xDirection * 0.1f, 0.1f, 1f);
            }

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
                currentWP++;

            yield return null;
        }

        reachDestination = true;
    }


    private Vector2 FindTaget()
    {
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            Vector3 playerPos = player.transform.position;

            if (roaming == true)
            {
                return (Vector2)playerPos + (Random.Range(3f, 4f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
            }
            else
            {
                return playerPos;
            }
        }
        else
        {
            // Trả về một vị trí mặc định nếu không tìm thấy Player
            return Vector2.zero;
        }
    }
}
