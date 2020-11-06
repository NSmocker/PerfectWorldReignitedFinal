using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGetter : MonoBehaviour
{

    public MonsterStats parent;
    public PlayerStatuses player_parent;
    public bool isPlayer;

    public List<Transform> damager_parents;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CheckDamagerParent(GameObject damager) 
    {
        damager_parents.Clear();
        var par = damager.gameObject.transform.parent;
        while (par != null)
        {   
            damager_parents.Add(par);
            par = par.transform.parent;
        }

    }
 
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DamagePart") 
        {
            CheckDamagerParent(other.gameObject);

            var block_damage=false;
            foreach (var par in damager_parents) 
            {
                if (par.tag == transform.tag) { block_damage = true;  }
            }

            if (block_damage == false)
            {
                if (isPlayer == false)
                {

                    var dam_part = other.gameObject.GetComponent<DamagePart>();
                    parent.GetDamage(dam_part.damage_count);
                    parent.isFighting = true;
                }
                else
                {
                    var dam_part = other.gameObject.GetComponent<DamagePart>();
                    player_parent.GetDamage(dam_part.damage_count);
                }
            }
            else { print("teammate damage blocked"); }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
