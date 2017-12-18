using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceItem : MonoBehaviour {

    /*UI*/
    public Image Dance_Img;
    public Text Name;
    public Text Effect;
    public Text Price;
    public Text Level;
    public Slider Progressbar;


    /*정보*/
    public int num;
    public string name;
    public string effect;
    public int price;
    public float priceUP;
    public int earn;
    public float earnUP;
    public float playTime;

    public void Start()
    {
        //setProgressbar();
    }

    public void Update() // 가격갱신
    {
        setProgressbar();
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
