using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundItem : MonoBehaviour {

    /*UI*/
    public Image Sound_Img;
    public Text Name;
    public Text Effect;
    public Text Price;
    public Sprite sound1, sound2, sound3;

    /*정보*/
    public int num;
    public string name;
    public string effect;
    public int price;
    public float benefit;


    public void Start()
    {
        imgChange();
    }
    
    public void imgChange()
    {
        switch(num)
        {
            case 1: case 2: Sound_Img.sprite = sound1; break;
            case 3: case 4: Sound_Img.sprite = sound2; break;
            case 5: Sound_Img.sprite = sound3; break;

        }
    }

  
}
