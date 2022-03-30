using UnityEngine.UI;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float starthealth = 100;
    public float startSpeed = 20f;
    
    
    public float speed ;
    private float health;

    public int worth = 100;
    public static int point ;
    public int startpoint;
    [HideInInspector]
    public static int enemiesPlay ;

    public bool death = false;

    public GameObject DeathEffect;

    [Header("Unity Stuff")]

    public Image healBar;

    public bool frozen = false;
    private void Start()
    {
        speed = startSpeed;

        health = starthealth;

        point = startpoint;
    }

    public void TakeDame(float amout)
    {
        if (death == false)
        {
            health -= amout;

            healBar.fillAmount = health / starthealth;

            if (health <= 0)
            {
                Die();
                death = true;
            }
        }
        
    }

    public void Slow(float pct)
    {
        speed = startSpeed *(1f- pct);
    }
    void Die()
    {
             
        GameObject Effect = (GameObject)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 5f);

        DestroyObject();

        waySpawn.EnemiesAlives--;

              
    }
    void DestroyObject()
    {
        death = false;
        Destroy(gameObject);
        PlayerStart.point += EnemyMove.point;
        PlayerStart.Money += worth;
        enemiesPlay--;
    }
   
}
