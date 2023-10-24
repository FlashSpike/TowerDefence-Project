using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;  //Storing Current Target Variables

    [Header("Attributes")]
    public float range = 15f; //Setting a Range for the Turret
    public float fireRate = 1f; //Shooting Rate / Second
    private float fireCountdown = 0f; //Shooting Cycle
    public float turnSpeed = 10f; //turret turnSpeed

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy"; //Making enemyTag = Enemy

    public Transform partToRotate; //Making the Part a Public Variable
 
    public GameObject bulletPrefab;
    public Transform firepoint; //Bullet spawnpoint


    // Start is called before the first frame update
    void Start()
    {
        //Target Update Timer
        InvokeRepeating("UpdateTarget", 0f, 0.10f); //Setting a Interval for Seaching for Targets
    }


    //Search for Target(Enemys)
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //Search for the Enemies that are Tagged "Enemys" 
        float shortestDistance = Mathf.Infinity;    //Calculating the Shortest Distance to an Enemy, Infinate Distance when Enemy is not located
        GameObject nearestEnemy = null;             //Nearest Enemy from the turret
        foreach (GameObject enemy in enemies)       //Individual Enemy
        {
            float distanceToEnemies = Vector3.Distance(transform.position, enemy.transform.position); //Distance between the tower and the enemy
            if (distanceToEnemies < shortestDistance)
            {                                             //If distanceToEnemies is less than shortestDistance(Enemies coming closer to turret)                
                shortestDistance = distanceToEnemies;     //Set shortestDistance as distanceToEnemies(Updating the new distanceToEnemies)
                nearestEnemy = enemy;                     //nearestEnemy = enemy of the turret
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) //If enemies are found within the range of tower
        {
            target = nearestEnemy.transform; //target = nearestEnemy
        }
        else 
        {
            target = null;  //target = nothing
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Idle state for Turret
        if (target == null)     //If there is no target found, do nothing.
            return;

        //Target Lock On
        Vector3 dir = target.position - transform.position;     //To point the barrel in the direction of the enemies
        Quaternion lookRotation = Quaternion.LookRotation(dir); //Rotate to look at the direction
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //(Smoothing the Rotation overtime * Set Turn Speed) X, Y, Z Axis of Unity = EulerAngles
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //Only Moving the Y Axis when rotating

        //Shooting
        if (fireCountdown <= 0f)            //If Shooting Time = Now
        {
            Shoot();                        //Shoot
            fireCountdown = 1f / fireRate;  //Shooting Cycle / Shooting Speed = Shooting Speed
        }

        fireCountdown -= Time.deltaTime;    //Smoother Bullets, frame indepentdent, Run it over mutiple frames to continue with other task

        void Shoot()
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,firepoint.position,firepoint.rotation); //Spawning a Bullet in the direction to target
            Bullet bullet = bulletGO.GetComponent<Bullet>(); //Find component from Bullet Script

            if (bullet != null)         //If bullet exist
                bullet.Seek(target);    //Seek Target
        }
    }

    //Display of Turret Range
    void OnDrawGizmosSelected() //Displaying the Range of Turret when Selected
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
