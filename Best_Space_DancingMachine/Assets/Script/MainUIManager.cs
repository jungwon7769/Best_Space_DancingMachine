using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour {
    private static MainUIManager instance = null;

 
    public Text money;
    public Text day;
    public Text placeName;
  
    public GameObject dancePanel;
    public GameObject soundPanel;
    public GameObject heartPanel;
    public GameObject placePanel;
    


   private MainUIManager()
    {

    }

    public static MainUIManager getInstance()
    {
        if (instance == null)
            instance = new MainUIManager();

        return instance;
    }


    // Use this for initialization
    void Start () {
        dancePanel.SetActive(true); // dance default
        soundPanel.SetActive(false);
        heartPanel.SetActive(false);
        placePanel.SetActive(false);

        
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

    }

    public void onClick_Sound()
    {
        panelActive(soundPanel, heartPanel, placePanel);

    }

    public void onClick_Heart()
    {
        panelActive(heartPanel, soundPanel, placePanel);
    }

    public void onClick_Place()
    {
        panelActive(placePanel,soundPanel, heartPanel);
       
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
    
}
