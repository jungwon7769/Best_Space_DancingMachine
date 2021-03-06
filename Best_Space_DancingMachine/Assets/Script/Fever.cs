﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fever : MonoBehaviour {

    public Slider feverbar;
    public Button btn_fever;
    public Text clickText;
    public float maxFever = 100.0f;


    public void Start()
    {
        clickText = GetComponent<MainUIManager>().clickmoney;
    }
    public void Update()
    {
        if (PlayerData.getInstance().fever)
            feverMode();
    }
    public void onclick_fever() // 100채우면 피버모드
    {
        float maxFever = 100.0f;
        feverbar.maxValue = maxFever;
        PlayerData.getInstance().isChange = true;

        feverbar.value += 2;
        StartCoroutine("btnClicker");

        PlayerData.getInstance().danceNum = 100;

        if (feverbar.value == maxFever)
        {
            PlayerData.getInstance().fever = true;
            btn_fever.interactable = false;
        }

    }

    IEnumerator btnClicker()
    {
        clickText.enabled = true;
        yield return new WaitForSeconds(0.1f);
        clickText.enabled = false;
    }


    public void feverMode() // 피버모드 발동
    {
        feverbar.value -= Time.deltaTime * 100 * 10f;
        Debug.Log(feverbar.value);

        if (feverbar.value == 0.0f)
        {
            PlayerData.getInstance().fever = false;
            btn_fever.interactable = true;
        }
    }




}
