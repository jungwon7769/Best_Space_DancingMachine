using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SoundEffect
{
  money = 0,
  rock = 1,
  feverOccurDown =2, // 발생시간 빨라짐
  feverTimeUp = 3, // 피버시간 길어짐
    
};
public class Sound : MonoBehaviour {
    private static Sound instance = null;


    public GameObject sound_Prefab;
    public GameObject parent_obj;

    public List<SoundInfo> soundList;
    public AudioClip audioclip;

    private Sound()
    {
        soundList = new List<SoundInfo>();
        addSoundList();
    }

    public void Start()
    {
        printSoundList();
    }
    public static Sound getInstance()
    {
        if (instance == null)
            instance = new Sound();

        return instance;
    }

    public class SoundInfo
    {
        public int num; // 사운드 번호
        public SoundEffect effect; // 사운드 효과
        public string name;// 사운드 이름
        public float price; // 사운드 가격
        public AudioClip audio; // 사운드
    }

    public void printSoundList()
    {
        GameObject temp;

        for (int i = 0; i < soundList.Count; i++)
        {
            
            temp = Instantiate(sound_Prefab);
            temp.transform.parent = parent_obj.transform;
            temp.name = "음악추가";
            temp.GetComponent<SoundItem>().Name.text = soundList[i].name;
            temp.GetComponent<SoundItem>().effect = (SoundEffect)soundList[i].effect;

        }
    }



    public void addSoundList()
    {
        addSound(1, (SoundEffect)1, "흥얼", 100f, audioclip);
       
    }


    /// <summary>
    /// 사운드 목록 추가 
    /// </summary>
    /// <param name="num"></param>
    /// <param name="effect"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="audio"></param>
    public void addSound(int num, SoundEffect effect, string name, float price, AudioClip audio)
    {
        SoundInfo sound = new SoundInfo();

        sound.num = num;
        sound.effect = effect;
        sound.name = name;
        sound.price = price;
        sound.audio = audio;

        soundList.Add(sound);

    }

}
