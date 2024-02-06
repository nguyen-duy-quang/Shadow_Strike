using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed;
    public float nextWPDistance;
    public Seeker seeker;
    public SpriteRenderer characterSR;
    private Transform target;
    Path path;

    Coroutine moveCoroutine;

    private void Start()
    {
        target = FindObjectOfType<Player>().gameObject.transform;

        InvokeRepeating("CaculatePath", 0, 0.5f);
    }

    private void CaculatePath()
    {
        if (target != null && seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, OnPathCallBack);
        }
    }


    private void OnPathCallBack(Path p)
    {
        if (p.error) return;

        path = p;

        //Move to target
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if(moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveTargetCoroutine());
    }    

    private IEnumerator MoveTargetCoroutine()
    {
        int currentWP = 0;

        while(currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector3 force = direction * moveSpeed * Time.deltaTime;
            transform.position += force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if(distance < nextWPDistance)
            {
                currentWP++;
            }
            if (force.x != 0)
                if (force.x < 0) 
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
                else
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
            yield return null;
        }    
    }    
}
