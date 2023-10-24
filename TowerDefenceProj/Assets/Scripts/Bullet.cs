using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float speed = 70f;            //Bullet Speed //Missile Speed

    public float explosionRadius = 0f;   //Explosion Aoe for the missile

    public int damage = 50;              //Bullet Damage //Missile Damage


    [Header("Unity Setup Fields")]
    public GameObject impactEffect;      //Bullet Impact Effect

    //Seeking Bullets
    public void Seek (Transform _target) //Bullets following the targets
    {
        target = _target;
    }
   void Update()
    {
        if (target == null)            //If no target
        {
            Destroy(gameObject);        //Destroy Bullet
            return;                    //End the Process
        }

        Vector3 dir = target.position - transform.position; //To fire the bullets in the direction of the enemies
        float distanceThisframe = speed * Time.deltaTime;   //Bullet moving in current frame

        if (dir.magnitude <= distanceThisframe)             //Distance Moved in Current Frame CANNOT be more than Distance from target
        {
            HitTarget();                                    //Target Hit
            return;                                         //End the Process
        }

                                                                              //Have not hitted a target
        transform.Translate(dir.normalized * distanceThisframe, Space.World); //Moving bullet at Constant Speed
                                                                              //Moving in World Space(To allow bullets to travel to target)

        transform.LookAt(target); //For Bullets to aim towards the target
    }

    //Targets Got Hit
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); //Spawnning the effect on impact
        Destroy (effectIns, 2f);

        if (explosionRadius > 0f)
        {
            Explode();           //Explode more than a Single Target
        } else
        {
            Damage(target);      //Explode Single Target
        }
        Destroy(gameObject);     //Destroy Enemy
        }

    //Missile upon impact
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //Shooting out a Sphere that overlaps to check for colliders that was HIT by the Sphere
        foreach (Collider collider in colliders)
            {
            if (collider.tag == "Enemy")    //If colliders hit have the Tag "enemy"
            {
                Damage(collider.transform); //Damage the enemy
            }
        }
    }
   
    //Damage Output per Hit
    void Damage(Transform enemy)  //Entire Enemy Game Object
    {
        Enemy e = enemy.GetComponent<Enemy>(); //Get Enemy Script inside of Enemy Game Object

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    //Display Missile Range
    void OnDrawGismoSelected()
    {
        Gizmos.color = Color.red; //Setting the range color red
        Gizmos.DrawWireSphere(transform.position, explosionRadius); //Show the missile radius
    }
}
