using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dance : MonoBehaviour {
    private static Dance instance = null;

    public DanceType danceType;
    public Text Name;
    public Text Price;
    public Text Earn;


    public class DanceType
    {
       public string danceName; // 댄스이름
       public int danceNum; // 댄스번호
       public int dancePrice;// 댄스 가격
       public float danceUp; // 댄스 강화 비율
       public float danceTime; // 댄스 한번 진행시간
    }

    private Dance()
    {
        danceType = new DanceType();
 
    }

    public static Dance getInstance()
    {
        if(instance == null)
        {
            instance = new Dance();
        }

        return instance;
    }

    public void danceList()
    {
        makeDance("손뼉치기", 1, 100, 1.1f, 0.5f);
    }

    public void makeDance(string name, int num, int price, float up, float time)
    {
        DanceType makedance = new DanceType();

        makedance.danceName = name;
        makedance.danceNum = num;
        makedance.dancePrice = price;
        makedance.danceUp = up;
        makedance.danceTime = time;

    }
  

}
