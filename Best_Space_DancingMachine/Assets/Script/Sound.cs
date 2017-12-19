﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundInfo
{
    public int num;
    public string name;
    public string effect;
    public int price;
    public float benefit;

}

public class Sound : MonoBehaviour {

    private static Sound instance = null;

    public GameObject sound_Prefab;
    public GameObject parent_obj;

    public List<SoundInfo> soundList;

    public AudioSource sound_Source;
    public AudioClip audioClip;
    public float sound_volume;

    public AudioClip[] sound_Clip_list;

    public bool isMute = false;
    public bool isPlay = false;

    private Sound()
    {
        soundList = new List<SoundInfo>();
        
        addList();
    }

    
    void Awake()
    {
        if (Sound.instance == null)
            Sound.instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }


    public static Sound getInstance()
    {
        if (instance == null)
            instance = new Sound();

        return instance;
    }

    public void Start()
    {

        sound_Source = gameObject.AddComponent<AudioSource>();

        object[] temp;
        temp = Resources.LoadAll("Audio");
        sound_Clip_list = new AudioClip[temp.Length]; //리소스갯수로변경함

        for (int i = 0; i < temp.Length; i++)
        {
            sound_Clip_list[i] = temp[i] as AudioClip;
        }


        sound_Source.PlayOneShot(audioClip);

        create_Item(sound_Prefab, soundList);

    }

    public void playMusic(int num)
    {
        if (!isMute)
        {
            audioClip = sound_Clip_list[num-1];
            Debug.Log(sound_Clip_list[num-1]);
            sound_Source.clip = audioClip;

            sound_Source.Play();
            sound_Source.loop = true;
            sound_Source.volume = 1.0f;
        }

    }

    public void create_Item(GameObject prefab, List<SoundInfo> list)
    {
        GameObject item;

        for (int i = 0; i < list.Count; i++)
        {
            item = Instantiate(prefab, parent_obj.transform); // 생성
            item.transform.localScale = new Vector3(1, 1, 1); // 스케일 설정
            item.GetComponent<SoundItem>().num = list[i].num;
            item.GetComponent<SoundItem>().name = list[i].name;
            item.GetComponent<SoundItem>().effect = list[i].effect;
            item.GetComponent<SoundItem>().price = list[i].price;
            item.GetComponent<SoundItem>().benefit = list[i].benefit;

            item.GetComponent<SoundItem>().Name.text = list[i].name;
            item.GetComponent<SoundItem>().Effect.text = list[i].effect;
            item.GetComponent<SoundItem>().Price.text = money_view_change(list[i].price);
        }

    }

    public string money_view_change(int money)
    {

        if (money >= 10000)
        {
            if (money >= 100000000)
                return (money / 10000000) + "b";

            else
                return (money / 10000) + "a";
        }
        else
            return money.ToString();
    }

    public void addList()
    {
        addSound(1, "클럽비트", "돈 획득량 1.5배 증가", 50000, 1.5f);
        addSound(2, "이런저런", "돈 획득량 2배 증가", 1000000, 2.0f);
        addSound(3, "노래3", "돈 획득량 3배 증가", 10000000, 3.0f);
        addSound(4, "노래4", "돈 획득량 5배 증가", 100000000, 5.0f);
        addSound(5, "개발자의 노래", "돈 획득량 10배 증가", 1000000000, 10.0f);
    }

    public void addSound(int num, string name, string effect, int price, float benefit)
    {
        SoundInfo Sound_ = new SoundInfo();

        Sound_.num = num;
        Sound_.name = name;
        Sound_.effect = effect;
        Sound_.price = price;
        Sound_.benefit = benefit;

        soundList.Add(Sound_);

    }

}
