using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBihaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public AudioClip[] random_speech;


    public GameObject player;
    public float speek_distance=2;
    public float speek_timer, speek_cd=15f;




    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        speek_timer -= Time.deltaTime;
        var pl_dist = Vector3.Distance(transform.position, player.transform.position);
        if (pl_dist <= speek_distance && speek_timer < 0) 
        {
            speek_timer = speek_cd;
            source.PlayOneShot(random_speech[Random.Range(0, random_speech.Length)]);
        }
        
    }
}
