using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public int damage = 20;

    

    public float speed = 70f;

    public float explosionRadius = 0f;

    public GameObject BulletEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject Effect = (GameObject)Instantiate(BulletEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 5f);

        if (explosionRadius > 0f)
        {
            Exlope();
        }
        else
        {
            Dame(target);
        }
      
        Destroy(gameObject);
        
    }
    void Exlope()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in coliders)
        {
            if(collider.tag == "Enemy")
            {
                Dame(collider.transform);
            }
        }
    }
    void Dame(Transform enemy)
    {
        EnemyMove e = enemy.GetComponent<EnemyMove>();
        if(e!= null)
        {
            e.TakeDame(damage);
        }
       
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
