using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceItem : MonoBehaviour {

    /*UI*/
    public Image Place_img;
    public Text Name;
    public Text Effect;
    public Text Price;
    public Button Btn_buy;


    public Sprite map1, map2;

    public int num;
    public string name;
    public string effect;
    public int price;
    public float benefit;

    /*정보*/

	// Use this for initialization
	void Start () {

        imgChange();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void btn_buy() // 구매 버튼
    {
        PlayerData.getInstance().placeNum = num;
        /*
        PlayerData data = PlayerData.getInstance();
        
        if (data.money > price)
        {
            data.money -= price;
            data.placeNum = num;
        }
        else
            return;
            */
        
    }

    public void imgChange()
    {
        switch (num)
        {
            case 1: Place_img.sprite = map1; break;
            case 2: Place_img.sprite = map2; break;
        }
    }
}
