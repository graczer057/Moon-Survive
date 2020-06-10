using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public int damagePerShot = 20;                              //Damage of the bullets
    public float timeBetweenBullets = 0.10f;                    //Time you must wait to shot next bullet
    public float range = 100f;                                  //Range of the bullet
    
    float timer;                                                //Timer that counting time in some functions on the bellow
    Ray shootRay;                                               //Ray of our bullet
    RaycastHit shootHit;                                        //Ray when our bullet hit   
    ParticleSystem gunParticles;                                //Bullet Partcile
    LineRenderer gunLine;                                       //LineRender of our bullet
    AudioSource gunAudio;                                       //Audio when our bullet was shooted
    Light gunLight;                                             //Light when our byllet was shooted
    float effectsDisplayTime = 0.2f;                            //Display time of our bullet

    void Awake()
    {
        //Getting acces to our components on the awake of our game
        gunParticles = GetComponent<ParticleSystem>();          
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        
        timer += Time.deltaTime;                                                    //Setting timer

        if(Input.GetButtonDown ("Fire1") && timer >= timeBetweenBullets)            //If we press the Fire1 button (LMB) and the timer is bigger or equal than time betweenBullets then we calling a void Shoot
        {   
            Shoot();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)                        //if timer is bigger or equal than time betweenBullets * effect display then we calling void DisableEffects
        {
            DisableEffects();
        }
            
    }

    public void DisableEffects()
    {
        //In this function we disabling the gun Line and gunLight
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    public void Shoot()
    {
        timer = 0f;                                                                         //Setting timer to 0F(sec)

        gunAudio.Play();                                                                    //When we call this function setting a gunAudio to Play

        gunLight.enabled = true;                                                            //setting gunLight 

        gunParticles.Stop();                                                                //stopping the gunParticles and then playing 
        gunParticles.Play();

        gunLine.enabled = true;                                                             //Setting gunLine to true
        gunLine.SetPosition(0, transform.position);                                         //Setting position of gunLine

        shootRay.origin = transform.position;                                               //Setting shootRay origin
        shootRay.direction = transform.forward;                                             //Setting direction of shootRay
        Debug.DrawRay(transform.position, transform.forward, Color.red, 5f);                //Drawing ray from the position forward setting color to red 

        if(Physics.Raycast (shootRay, out shootHit, range))                                 //If we instantiate raycats in those parameters the...
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();        //Getting component to enemy health
            if(enemyHealth != null)                                                         //If this raycast not equal to hit the enemy then...
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);                      //Enemy taking damage 
            }
            gunLine.SetPosition(1, shootHit.point);                                         //Setting the position from player to enemy
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);           //Or when we aren't hit the enemy then raycast is drawing the line normally
        }

    }
}
