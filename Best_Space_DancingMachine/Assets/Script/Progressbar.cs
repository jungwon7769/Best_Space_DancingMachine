using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {

    public Slider progressbar;
    public float maxvalue = 100.0f;
    Dance dance = Dance.getInstance();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        normal();
    }

    public void normal() // 기본 작동하는 프로그래스바 (1초)
    {
        progressbar.maxValue = maxvalue;
        progressbar.value += Time.deltaTime * 100;
        if (progressbar.value == 100f)
        {
            progressbar.value = 0.0f;
            PlayerData.getInstance().money += 1;
        }
    }

    public void danceList()
    {
       
    }


}
