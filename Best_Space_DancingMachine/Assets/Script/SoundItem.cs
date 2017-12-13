using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundItem : MonoBehaviour {

    public Text Name;
    public Text Effect;
    public Text Price;
    public Button btn_get;
    public Image image;
    
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;

    public int num;
    public SoundEffect effect;
    public string name;
    public float price;
    public AudioClip audio;
    
    public void Start()
    {
        
    }

    public void Update()
    {
        setting();   
    }
    public void onclick_Get() // 사운드 구매버튼
    {
        PlayerData playerData = PlayerData.getInstance();

        if (playerData.money > price) // 가진돈 가격보단 많아야 살수있음.
        {
            playerData.money -= price;
            btn_get.interactable = false; // 더이상 구매 못하게

        }

    }

    public void setting()
    {
        Price.text = price.ToString();
        imageChange();
    }

    public void imageChange()
    {
        switch(effect)
        {
            case (SoundEffect)0: image.sprite = image1 ;  break;
            case (SoundEffect)1: image.sprite = image2; break;
            case (SoundEffect)2: image.sprite = image3; break;
        }

    }
    
}
