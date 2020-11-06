using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePart : MonoBehaviour
{
    public int damage_count;
    public Rigidbody owner_monster;
    public Rigidbody owner_player;

    public AudioSource source;
    public AudioClip blocksound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DamagePart") 
        {

            if (owner_monster != null) {
                owner_monster.AddForce(-owner_monster.transform.forward);
                source.PlayOneShot(blocksound);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
