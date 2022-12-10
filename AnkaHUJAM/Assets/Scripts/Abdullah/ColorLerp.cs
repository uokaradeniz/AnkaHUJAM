using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    public Image image;
    [SerializeField] private Color[] colors;
    [SerializeField] private float lerpTime;
    [SerializeField] private int index;
    [SerializeField] private float changer;

    private PlayerController playerController;
   
    
    void Start()
    {
        image = GetComponent<Image>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        image.color = Color.Lerp(image.color, colors[index], lerpTime * Time.deltaTime);

        changer = Mathf.Lerp(changer, 1f, lerpTime * Time.deltaTime);

        if (changer > 0.9f)
        {
            changer = 0;
            index++;


            if (index >= colors.Length)
            {
                index = 0;

            }

        }
        
    }
}
