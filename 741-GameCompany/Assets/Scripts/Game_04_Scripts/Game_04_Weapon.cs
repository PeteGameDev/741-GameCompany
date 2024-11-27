using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_04_Weapon : MonoBehaviour
{
    public float gunRange, gunDamage, fireRate;
    public LayerMask enemyLayer;
    public Camera cam;
    float nextFire;
    public GameObject hitParticle;
    public ParticleSystem fireEffect;
    
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;
        nextFire = Time.time + fireRate;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, gunRange, enemyLayer)){
            Debug.Log(hit.transform.name);
            fireEffect.Play();
            Game_04_enemy enemyTarget = hit.transform.GetComponent<Game_04_enemy>();
            if(enemyTarget != null){
                enemyTarget.TakeDamage(gunDamage);
                
                GameObject particleClone = Instantiate(hitParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(particleClone, 2f);
            }
        }
    }
}
