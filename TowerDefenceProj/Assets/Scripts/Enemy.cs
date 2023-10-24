using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    //Enemies Speed
    public float startingSpeed = 16f;           //Control the Speed of Enemy in Editor(Public)
    private float speed;
    //Enemies Health
    public float startingHealth = 100;            //Enemies Health
    private float health;

    //Enemies Value
    public int value = 50;              //Cash Earned Per Enemy Death

    [Header("Unity Setup Fields")]
    private Transform target;           //Enemy Target
    private int wavepointIndex = 0;     //Starting Waypoint (0 = 1st waypoint)

    public GameObject deathEffect;      //Effect upon death

    [Header("Unity Stuff")]
    public Image healthBar;             //Health Bar Image

    void Start()
    {
        health = startingHealth;
        speed = startingSpeed;

        target = Waypoints.points[0];   //referencing the waypoints script (Waypoints.cs)
    }

    //Enemies Damage Taken
    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startingHealth;   //Health Bar Amount

        if (health <= 0)
        {
            Die();
        }
    }

    //Upon Enemies Death
    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);

        PlayerStats.Money += value;   //When an Enemey dies add the Money to Player Stats Script
        
        Destroy(gameObject);
        
    }

    //Route for Enemies
    private void Update()
    {
        Vector3 dir = target.position - transform.position; //vector3 = (x,y,z). Moving all 3 axis together towards the target's direction
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //move direction and distance(Translate), fixed length, and speed(normalized) * speed (our speed above^) * speed with (Time.delta Time) to make the enemy frame indepentdent, moving in world axis

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) //check for distance if reached 0.2f get next waypoint position
        {
            GetNextWaypoint(); //get next waypoint
        }
    }

    //Path of WayPoints
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length -1) //if enemy reaches the end(last waypoint), else it will follow the waypoint path
        {
            EndPath();           //End of waypoint 
            return;              //execute
        }

        void EndPath()
        {
            PlayerStats.Lives--; //-1 Live Per Enemy reaching the end
            Destroy(gameObject); //destroy enemy object
        }

       wavepointIndex++; //get next waypoint
       target = Waypoints.points[wavepointIndex]; //referencing waypoint.cs script
    }
}
