using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public GameObject moster_to_spawn;
    public float count;
    public List<GameObject> spawned_monsters;
    public float spawn_cd,spawn_timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawing() 
    {
        spawned_monsters.Add(Instantiate(moster_to_spawn, transform.position, transform.rotation));
    }
    // Update is called once per frame
    void Update()
    {
        spawn_cd -= Time.deltaTime;
        if (spawned_monsters.Count < count && spawn_cd<0) 
        {
            spawn_cd = spawn_timer;
            Spawing();

        }




        
    }
}
