using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [Header("Default Vars")]
    Rigidbody rb;
    public int level = 1;
    public int HP = 100;
    public float move_speed;
    public bool isFighting; //Показатель находится ли моб в состоянии агресии.
    public Animator anim;
    public bool dead;


    [Header("Sound Vars")]
    public AudioSource source;
    public AudioClip idle_sound;
    public AudioClip attack_sound;
    public AudioClip hurt_sound;
    public AudioClip death_sound;

    public AudioClip block_sound;


    [Header("Non Agressive Vars")]
    public float idle_timer = 0;
    public float idle_cooldown = 20;
    public float walk_timer;


    [Header("Agressive Vars")]
    public float agr_timer = 20;
    public float min_agre_distance;
    public float current_distance;
    public GameObject agr_target;
    public float min_fight_distance = 1;


    public void Death()
    {


    }
    public void GetDamage(int damage)
    {

        anim.SetTrigger("Hurt");
        HP -= damage;
        source.PlayOneShot(hurt_sound);

        //Todo find nearest player
        var targets = GameObject.FindGameObjectsWithTag("Player");// select all players
        var min_selected_distance = 696969f;// 696969 flag that  no near player
        foreach (GameObject pl in targets)
        {
            var dist = Vector3.Distance(transform.position, pl.transform.position);
            if (dist < min_selected_distance) { min_selected_distance = dist; agr_target = pl; }//if its nearest- select target
        }

    }


    public void PlayAttackSound() 
    {
        source.PlayOneShot(attack_sound);
    }
    public void AgressiveBihaviour() 
    {
        if (agr_target != null) 
        {
            current_distance = Vector3.Distance(transform.position, agr_target.transform.position);
            if (current_distance > min_agre_distance){ isFighting = false;}
            if (current_distance > min_fight_distance)
            {
                var agr_target_pos = agr_target.transform.position;
                agr_target_pos.y = transform.position.y; //look at target
                transform.LookAt(agr_target_pos);
                rb.velocity = transform.forward * move_speed/2 + Physics.gravity;
                
            }
            else 
            {
                anim.SetTrigger("Attacking");
            }
          


        }
        
    }

    public void IdleBihaviour()
    {
        idle_timer -= Time.deltaTime;
        walk_timer += Time.deltaTime;
        if (walk_timer < 10)
        {
            var vel = rb.velocity;
            vel = transform.forward * (move_speed/2)+Physics.gravity;
            rb.velocity = vel;
        }

        if (idle_timer <= 0) 
        {
            idle_cooldown = Random.Range(5f,15f);
            idle_timer = idle_cooldown;
            walk_timer = 0;
            float random_angle = Random.Range(0f, 340f);
            transform.localEulerAngles = new Vector3(0, random_angle, 0);
            source.PlayOneShot(idle_sound);
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 0)
        {
            if (isFighting)
            {
                AgressiveBihaviour();
            }
            else
            {
                IdleBihaviour();
            }
        }
        else 
        {
            if (dead != true) 
            {
                dead = true;
                anim.SetTrigger("Dead");
                source.PlayOneShot(death_sound);
                Destroy(transform.gameObject, 5f);
            }

        }

        
    }
}
