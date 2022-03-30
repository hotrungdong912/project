using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private EnemyMove enemytarget;

    [Header("Atributes")]
    public float range = 20f;
    public float fireRate = 1f;

    [Header("UserBullet(defaul)")]
    public GameObject bulletPrefab;
    

    [Header("UserPoison")]
    public bool userPoison = false;

    public int dameOverTime = 10;
    public float starttimePoison = 5f; 
    
    float timePoison ;

    [Header("UserCanon")]
    public bool userCanon = false;
    public GameObject shootEffect;
    public Transform muzzle;

    [Header("UserWizzard")]
    public bool userWizzard = false;
    public LineRenderer lighning;
    public float timeFrozen ;
    public int dame = 10;
    public ParticleSystem par;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnspeed = 10f;
    private float fireCountdown = 0f;
    public Transform firePoint;

    [SerializeField] private AudioSource arrowhit1;
    [SerializeField] private AudioSource arrowhit2;
    // Start is called before the first frame update
    void Start()
    {
        timePoison = starttimePoison;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearesEnemy = null;

        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearesEnemy = enemy;
            }

            if (nearesEnemy != null && shortesDistance <= range)
            {
                target = nearesEnemy.transform;
                enemytarget = nearesEnemy.GetComponent<EnemyMove>();
            }else
            {
                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if (userWizzard)
            {
                if (lighning.enabled)
                {
                    lighning.enabled = false;
                    par.Stop();
                    arrowhit2.Stop();
                }
            }
            return;
        }
        if(userWizzard == true)
        {           
            Lighning();           
        }
        else
        {
            LookOntarget();
    
                if (fireCountdown <= 0f)
                {
                    
                    Shoot();
                    fireCountdown = 1f / fireRate;
                    arrowhit1.Play();

            }
                fireCountdown -= Time.deltaTime;
        }

        
      
    }
    void Lighning()
    {
        
        if (!lighning.enabled)
        {
            lighning.enabled = true;
            par.Play();
            arrowhit2.Play();
        }
        lighning.SetPosition(0,firePoint.position);
        lighning.SetPosition(1,target.position);

        enemytarget.TakeDame(dame * Time.deltaTime);
        enemytarget.Slow(timeFrozen);
        Vector3 dir = firePoint.position - target.position;

        par.transform.position = target.position + dir.normalized * 1.2f;
        par.transform.rotation = Quaternion.LookRotation(dir);
    }
    void UserPoison()
    {
        StartCoroutine(Poison()); 
    }
    IEnumerator Poison()
    {
        while (timePoison > 0)
        {
            for (int i = 0; i < timePoison; i++)
            {
                Debug.Log("Dame");
            }
            timePoison--;
            enemytarget.TakeDame(dameOverTime);
            yield return new WaitForSeconds(1);
        }
        Debug.Log(timePoison);
        timePoison = starttimePoison;

    }
    void LookOntarget()
    {
        //target look on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot()
    {
        
        GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
       
        if (bullet != null )
        {
            bullet.Seek(target);
            if (userPoison == true)
            {
                UserPoison();
            }
            if (userCanon == true)
            {
                Instantiate(shootEffect, muzzle.position, muzzle.rotation);
            }
            if(userWizzard == true)
            {
               
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
