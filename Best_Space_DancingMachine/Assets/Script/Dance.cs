using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dance : MonoBehaviour {
    private static Dance instance = null;

    public class DanceInfo
    {
        public string name; // 댄스 이름
        public int level; // 댄스 레벨
        public int num; // 댄스 번호
        public float price; // 댄스 가격 
        public float LvUP; // 댄스 레벨업 비율
        public float earn; // 댄스로 벌수 있는 돈
        public float playTime; // 댄스 재생 시간
    }

    public GameObject dance_Prefab;
    public GameObject parent_obj;
    
    public List<DanceInfo> danceList;


    private Dance()
    {
        danceList = new List<DanceInfo>();
        addDanceList();
    }

    public void Start()
    {
        printDanceList();
    }

    public void printDanceList()
    {
        GameObject temp;

        for (int i = 0; i < danceList.Count; i++)
        {

            temp = Instantiate(dance_Prefab);
            temp.transform.parent = parent_obj.transform;
            temp.name = "추가";
            temp.GetComponent<DanceItem>().Name.text = danceList[i].name;
            temp.GetComponent<DanceItem>().Price.text = danceList[i].price.ToString();
            temp.GetComponent<DanceItem>().Level.text = "Lv. " + danceList[i].level;
            temp.GetComponent<DanceItem>().playTime = danceList[i].playTime;
            temp.GetComponent<DanceItem>().earn = danceList[i].earn;
            temp.GetComponent<DanceItem>().price = danceList[i].price;
            temp.GetComponent<DanceItem>().level = danceList[i].level;
            temp.GetComponent<DanceItem>().num = danceList[i].num;
            temp.GetComponent<DanceItem>().LvUP = danceList[i].LvUP;
        }
    }
    

    public static Dance getInstance()
    {
        if(instance == null)
        {
            instance = new Dance();
        }

        return instance;
    }

    public void addDanceList()
    {
      
       addDance("손뼉치기", 1, 1, 100.0f, 1.1f, 10f, 1f);
       addDance("낄낄", 2, 1, 100.0f, 1.1f, 100f, 0.5f);
        
    }
    
    /// <summary>
    /// 댄스 정보 입력해서 리스트안에 넣기
    /// </summary>
    /// <param name="name"></param>
    /// <param name="num"></param>
    /// <param name="price"></param>
    /// <param name="LvUp"></param>
    /// <param name="earn"></param>
    /// <param name="playTime"></param>
    public void addDance(string name, int num, int level, float price, float LvUp, float earn, float playTime)
    {
        DanceInfo dance = new DanceInfo();

        dance.name = name;
        dance.num = num;
        dance.level = level;
        dance.price = price;
        dance.LvUP = LvUp;
        dance.earn = earn;
        dance.playTime = playTime;

        danceList.Add(dance);
        
    }



}
