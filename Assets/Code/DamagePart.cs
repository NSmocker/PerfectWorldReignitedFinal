using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePart : MonoBehaviour
{
    public int damage_count;
    public Rigidbody owner_monster;
 

    public AudioSource source;
    public AudioClip blocksound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "DamagePart") 
        {
            if (owner_monster) { owner_monster.AddForce(-owner_monster.transform.forward * 500f); owner_monster.gameObject.GetComponent<MonsterStats>().HP+=15; }

                source.PlayOneShot(blocksound);
            print("enemyblocked");
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
