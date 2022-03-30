using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waySpawn : MonoBehaviour
{
    public static int EnemiesAlives = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public Text WayCountDown;

    public float timeBetweenWave = 5f;

    private float countdown = 2f;

    public static int starwayIndex = 0;

    public static int  wayIndex ;

    public GameManager gameManager;

    
    void Start() 
    { 
        EnemiesAlives = 0;
        EnemyMove.enemiesPlay = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlives > 0)
        {
            return;
        }
        if (EnemyMove.enemiesPlay == 0)
        {            
            if (wayIndex < waves.Length)
            {
                countdown -= Time.deltaTime;
            }
        }
        if (EnemyMove.enemiesPlay == 0)
        {
            if(wayIndex == waves.Length)
            {
                gameManager.winLevel();
                wayIndex = 0;
                this.enabled = false;
                return;
            }          
        }
        if (countdown <= 0f )
        {           
            if (wayIndex < waves.Length)
            {

                    if (EnemyMove.enemiesPlay == 0)
                    {                       
                        StartCoroutine(SpawnWave());
                        countdown = timeBetweenWave;
                    }
                    
            }
            

        }      
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        WayCountDown.text = string.Format("{0:00.00}", countdown);
        
    }
    IEnumerator SpawnWave()
    {
        PlayerStart.Rounds++;

        Wave wave = waves[wayIndex];
        EnemiesAlives = wave.enemies.Length;
        

        for (int z = 0; z < wave.enemies.Length; z++)
        {
            for (int i = 0; i < wave.enemies[z].count; i++)
            {
                SpawnEnemy(wave.enemies[z].enemy);
               
                yield return new WaitForSeconds(1f / wave.rate);
                EnemyMove.enemiesPlay++;
            }
        }
        wayIndex++;        
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position,spawnPoint.rotation);        
    }

}
