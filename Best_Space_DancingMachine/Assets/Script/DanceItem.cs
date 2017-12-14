using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceItem : MonoBehaviour {

    private static DanceItem instance = null;

    public Text Name;
    public Text Price;
    public Text Level;
    public Button btn_get;

    public int num;
    public float LvUP;
    public float level;
    public float price;
    public float playTime;
    public float earn;
    public Slider progressbar;
    public float maxvalue = 100.0f;

    private DanceItem()
    {

    }

    public static DanceItem getInstance()
    {
        if (instance == null)
            instance = new DanceItem();

        return instance;
    }

    public void Update()
    {
        settingProgressbar();
        Price.text = price.ToString();
        Level.text = "Lv. " + level;

    }

    public void onclick_Get() // 구매버튼
    {
        PlayerData playerData = PlayerData.getInstance();

        if (playerData.money > price) // 가진돈 가격보단 많아야 살수있음.
        {
            playerData.money -= price;
            level++;
            earn *= LvUP;
            price *= LvUP;
            playerData.danceNum = num;

        }

    }


    public void settingProgressbar()
    {
        progressbar.maxValue = maxvalue;
        progressbar.value += Time.deltaTime * 100 * playTime;
        if (progressbar.value == maxvalue)
        {
            progressbar.value = 0.0f;
            PlayerData.getInstance().money += earn;
        }
    }


}
