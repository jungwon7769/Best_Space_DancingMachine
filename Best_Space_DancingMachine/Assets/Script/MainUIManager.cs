using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour {

    public Text money;
    public Text day;
    public Text placeName;

    public Button dance;
    public Button sound;
    public Button coordi;
    public Button place;

    public GameObject dancePanel;
    public GameObject soundPanel;
    public GameObject coordiPanel;
    public GameObject placePanel;

	// Use this for initialization
	void Start () {
        dancePanel.SetActive(true); // dance default
        soundPanel.SetActive(false);
        coordiPanel.SetActive(false);
        placePanel.SetActive(false);
	}

    void Update()
    {
        money.text = PlayerData.getInstance().money.ToString();
        day.text = "DAY. " + PlayerData.getInstance().day;
        placeName.text = PlayerData.getInstance().place;
    }

    public void onClick_Dance()
    {
        panelActive(dancePanel, soundPanel, coordiPanel, placePanel);

    }

    public void onClick_Sound()
    {
        panelActive(soundPanel, dancePanel, coordiPanel, placePanel);
    }

    public void onClick_Coordi()
    {
        panelActive(coordiPanel, dancePanel, soundPanel, placePanel);
    }

    public void onClick_Place()
    {
        panelActive(placePanel, dancePanel, soundPanel, coordiPanel);
    }

    /// <summary>
    /// 패널비활, active 빼고 모두비활
    /// </summary>
    /// <param name="active"></param>
    /// <param name="panel1"></param>
    /// <param name="panel2"></param>
    /// <param name="panel3"></param>
    public void panelActive(GameObject active, GameObject panel1, GameObject panel2, GameObject panel3)
    {
        active.SetActive(true);
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }
}
