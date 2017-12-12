using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {

    public Slider progressbar;
    public float maxvalue = 100.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        progressbar.maxValue = maxvalue;
        progressbar.value += Time.deltaTime * 100;
        if (progressbar.value == 100f)
        {
            progressbar.value = 0.0f;
            PlayerData.getInstance().money += 1;
        }
    }
}
