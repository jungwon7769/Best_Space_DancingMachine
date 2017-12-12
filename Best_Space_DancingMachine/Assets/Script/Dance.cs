using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dance : MonoBehaviour {
    private static Dance instance = null;

    public GameObject addItem;
    public GameObject test;

    public Text Name;
    public Text Price;
    public Text Earn;

    public bool isExist = false;
    public List<DanceType> danceList = new List<DanceType>();

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
       
    }

    public void Start()
    {
        if(!isExist)
        danceList1();
    }

    public static Dance getInstance()
    {
        if(instance == null)
        {
            instance = new Dance();
        }

        return instance;
    }

    public void danceList1()
    {
        isExist = true;
         testtest();

        for (int i = 0; i < danceList.Count; i++)
        {
            Name.text = danceList[i].danceName;
            Price.text = danceList[i].dancePrice.ToString();
            //Instantiate(addItem).transform.SetParent(test.transform);
        }

    }

    public void testtest()
    {
        addDanceList("손뼉치기", 1, 100, 1.1f, 0.5f);
    }

    public void addDanceList(string name, int num, int price, float up, float time) // 댄스 리스트에 추가하기
    {
        DanceType dance_ = new DanceType();

        dance_.danceName = name;
        dance_.danceNum = num;
        dance_.dancePrice = price;
        dance_.danceTime = time;
        dance_.danceUp = up;

        danceList.Add(dance_);

    }


  

}
