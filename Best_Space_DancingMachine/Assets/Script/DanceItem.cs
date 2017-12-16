using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceItem : MonoBehaviour {

    private static DanceItem instance = null;

    public Text NAME;
    public Text LV;
    public Text PRICE;
    public Image image;
    public Slider Progressbar;
    public Button btn_buy;

    public int num;         // 댄스 넘버
    public string name;     // 댄스 이름
    public float price;     // 댄스 가격
    public float priceUP;   // 댄스 가격 강화비율
    public float earn;      // 댄스로 벌수 있는 돈
    public float earnUP;    // 댄스로 벌수있는돈 증가비율
    public float playTime;  // 댄스 재생시간

    public int danceLv;     // 댄스 레벨


    private DanceItem()
    {
        danceLv = 0;
    }

    public static DanceItem getInstance()
    {
        if (instance == null)
            instance = new DanceItem();

        return instance;
    }

    public void Update()
    {
        setProgressbar();
        PRICE.text = price.ToString();
        LV.text = "Lv. " + danceLv;

    }

    public void onclick_Buy() // 구매버튼
    {
        PlayerData playerData = PlayerData.getInstance();

        if (playerData.money > price) // 가진돈 가격보단 많아야 살수있음.
        {
            playerData.money -= price;
            //playerData.danceLv[0] = danceLv;
            danceLv++;
            earn *= earnUP;
            price *= priceUP;
            playerData.danceNum = num;
            playerData.isChange = true;

        }

    }



    public void setProgressbar()
    {
        Progressbar.maxValue = 100.0f;
        Progressbar.value += Time.deltaTime * 100 * playTime;

        if(Progressbar.value == 100.0f)
        {
            Progressbar.value = 0.0f;
            PlayerData.getInstance().money += earn;
        }
    }


}
