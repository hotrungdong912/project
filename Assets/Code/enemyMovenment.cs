using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class enemyMovenment : MonoBehaviour
{
    private Transform target;
    private EnemyMove enemy;
    private Turret tur;

    private int wavepointIndex = 0;
    void Start()
    {
        tur = GetComponent<Turret>();
        enemy = GetComponent<EnemyMove>();
        target = Waypoint.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.LookAt(target);

        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextPoint();           
        }
        enemy.speed = enemy.startSpeed;      
    }
    private void GetNextPoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            EndPath();
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;


        target = Waypoint.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStart.Lives--;
        waySpawn.EnemiesAlives--;
        Destroy(gameObject);
    }
}
