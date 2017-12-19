using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour {

    public Text money;
    public Text day;
    public Text placeName;

    public Text clickmoney;

    public Text btntext_Dance;
    public Text btntext_Sound;
    public Text btntext_Heart;
    public Text btntext_Place;
    
    public Button dance;
    public Button sound;
    public Button heart;
    public Button place;

    public GameObject dancePanel;
    public GameObject soundPanel;
    public GameObject heartPanel;
    public GameObject placePanel;
    




    // Use this for initialization
    void Start () {
        dancePanel.SetActive(true); // dance default
        soundPanel.SetActive(false);
        heartPanel.SetActive(false);
        placePanel.SetActive(false);
        clickmoney.enabled = false;
        
	}

    void Update()
    {
        updatePlayerData();
        
    }

    public void updatePlayerData()
    {

        money.text = ((int)PlayerData.getInstance().money).ToString();
        day.text = "DAY. " + PlayerData.getInstance().day;
        placeName.text = PlayerData.getInstance().place;
   

      
    }


    public void onClick_Option()
    {

    }

  
    public void onClick_Dance()
    {
        soundPanel.SetActive(false);
        heartPanel.SetActive(false);
        placePanel.SetActive(false);

        colorChange(btntext_Dance, btntext_Sound, btntext_Place, btntext_Heart);
    }

    public void onClick_Sound()
    {
        panelActive(soundPanel, heartPanel, placePanel);
        colorChange(btntext_Sound, btntext_Dance, btntext_Place, btntext_Heart);

    }

    public void onClick_Heart()
    {
        panelActive(heartPanel, soundPanel, placePanel);
        colorChange(btntext_Heart, btntext_Sound, btntext_Dance, btntext_Place);
    }

    public void onClick_Place()
    {
        panelActive(placePanel,soundPanel, heartPanel);
        colorChange(btntext_Place, btntext_Heart, btntext_Sound, btntext_Dance);
    }

    /// <summary>
    /// 패널비활, active 빼고 모두비활
    /// </summary>
    /// <param name="active"></param>
    /// <param name="panel1"></param>
    /// <param name="panel2"></param>
    public void panelActive(GameObject active, GameObject panel1, GameObject panel2 )
    {
        active.SetActive(true);
        panel1.SetActive(false);
        panel2.SetActive(false);
    }

    /// <summary>
    /// Text 색상변경
    /// </summary>
    /// <param name="active"></param>
    /// <param name="text1"></param>
    /// <param name="text2"></param>
    /// <param name="text3"></param>
    public void colorChange(Text active, Text text1, Text text2, Text text3)
    {
        active.color = Color.white;
        text1.color = Color.black;
        text2.color = Color.black;
        text3.color = Color.black;

    }

    public void allBtn_TextBlack()
    {
        btntext_Heart.color = Color.black;
        btntext_Dance.color = Color.black;
        btntext_Place.color = Color.black;
        btntext_Sound.color = Color.black;
    }
}
