using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Controller : MonoBehaviour
{
    //ÝKÝ adet image koydum biri arka plan olarak diðeri de azalan barý göstermek için 
    public Image heal_linear_image; //Beyaz resmin konulduðu image bu 
    float heal_remaining;
    public float max_heal = 10.0f;
    public GameObject GameObject;

    void Start()
    {
        heal_remaining = max_heal;
        
    }

    void Update()
    {
        HealBar();
    }
    void HealBar()
    {
        if (heal_remaining > 0)
        {
            heal_remaining -= Time.deltaTime;
            heal_linear_image.fillAmount = heal_remaining / max_heal;

        }
        

    }
}
