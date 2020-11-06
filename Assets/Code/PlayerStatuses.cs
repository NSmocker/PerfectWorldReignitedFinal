using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System.Globalization;

public class PlayerStatuses : MonoBehaviour
{
    [Header("Default Vars")]
    Rigidbody rb;
    public int level = 1;
    public float HP = 100;
    public float Mana = 100;
    public float EXP = 100;
    public float move_speed;

    public float max_HP = 100;
    public float max_Mana = 100;
    public float need_EXP = 100;

    public float HP_Regen =2;
    public float Mana_Regen = 2;



    [Header("UI Vars")]
    public TextMeshProUGUI HP_ui;
    public TextMeshProUGUI Mana_ui;
    public TextMeshProUGUI EXP_ui;
    public TextMeshProUGUI Level_ui;
    public Image fill_hp;
    public Image fill_mana;
    public Image fill_xp;






    public void GetDamage(int damage)
    {
        HP -= damage;
        //Todo find nearest player
     
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (HP < max_HP) HP += 0.02f *HP_Regen;
        if (Mana < max_Mana) Mana += 0.02f * Mana_Regen;

    }
    public void UI_Update() 
    {
        HP_ui.text = HP.ToString("F", CultureInfo.InvariantCulture)+" / "+ max_HP.ToString("F0", CultureInfo.InvariantCulture);
        

        Mana_ui.text = Mana.ToString("F", CultureInfo.InvariantCulture) + " / " + max_Mana.ToString("F0", CultureInfo.InvariantCulture);

        EXP_ui.text = EXP.ToString("F", CultureInfo.InvariantCulture) + " / " + need_EXP.ToString("F0", CultureInfo.InvariantCulture);
        
        Level_ui.text = level.ToString();


        float hp_fil = HP / max_HP;
        float mana_fil = Mana / max_Mana;
        float exp_fil = EXP / need_EXP;

 


        fill_hp.fillAmount = hp_fil;
        fill_mana.fillAmount = mana_fil;
        fill_xp.fillAmount = exp_fil;
      

}


// Update is called once per frame
void Update()
    {
        UI_Update();
       


    }
}
