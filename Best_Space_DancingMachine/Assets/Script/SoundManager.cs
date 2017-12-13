using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SOUND_NAME
{
    normal = 0, // 기본 게임 소리
   
};

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioClip[] audioClipList;

    public AudioSource bgmSource;
    public AudioClip audioClip;

    public float volume_bgm;
    public bool isMute = false;//true면 음소거
    
    private List<AudioSource> listAudio;




    //접근용
    public static SoundManager getInstance()
    {
        if (instance == null)
            instance = new SoundManager();
        return instance;
    }



    //스타트보다 먼저실행
    void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
    }


    // Use this for initialization
    void Start()
    {
        //환경설정불러오기
        volume_bgm = PlayerPrefs.GetFloat("Sound_vol_bgm", 1.0f);
       
        bgmSource = gameObject.AddComponent<AudioSource>();

        if (isMute)
            muteBgm();

        listAudio = new List<AudioSource>();
        
        
        object[] temp;
        temp = Resources.LoadAll("Sounds");
        audioClipList = new AudioClip[temp.Length]; //리소스갯수로변경함
        
        for (int i = 0; i < temp.Length; i++)
        {
            audioClipList[i] = temp[i] as AudioClip;
        }
        
        bgmSource.PlayOneShot(audioClip);
        
    }


    private void OnDestroy()
    {
        //환경설정저장
        PlayerPrefs.SetFloat("Sound_vol_bgm", volume_bgm);
        PlayerPrefs.Save();
    }

    //==========재생할거 찾기=============
    public AudioClip findAudioClip(SOUND_NAME s)
    {
        return audioClipList[(int)s];
    }



    //------------소스를 재생시키는것
    public void playBgm()
    {
        if (!isMute)
        {
            bgmSource.Play();
            bgmSource.loop = true;
            bgmSource.volume = volume_bgm;
        }
    }

    public void playBgm(AudioClip audio)
    {
        //현정수정, isMute더라도 bgm수정은 반영되도록함
        bgmSource.clip = audio;

        bgmSource.Play();
        bgmSource.loop = true;
        if (isMute) bgmSource.volume = 0f;
        else bgmSource.volume = volume_bgm;
    }

    public void stopBgm()
    {
        bgmSource.Stop();
    }


    //현정추가, 씬바껴도 계속 남아서 재생될 오디오
    /// <summary>
    /// Audio Loop Play(DontDestroy)
    /// </summary>
    /// <param name="audio">AudioClip</param>
    /// <param name="name">GameObject's Name</param>
    public AudioSource playDontDestroyLoop(AudioClip audio, string name)
    {
        GameObject go = new GameObject(name);
        AudioSource au = go.AddComponent<AudioSource>();
        au.volume = volume_bgm;
        au.clip = audio;
        au.loop = true;
        DontDestroyOnLoad(go);
        au.Play();
        listAudio.Add(au);
        return au;
    }

    //현정추가, 위에서 재생시킨 오디오 삭제가능
    /// <summary>
    /// Audio Loop Destroy
    /// </summary>
    /// <param name="name"></param>
    public void DestroyLoop(string name)
    {
        for (int i = 0; i < listAudio.Count; i++)
        {
            if (listAudio[i].gameObject.name.Equals(name))
            {
                GameObject go = listAudio[i].gameObject;
                listAudio.RemoveAt(i);
                Destroy(go);
                break;
            }
        }
    }

    //현정추가, DontDestroy + Loop 시킨 오디오 전부삭제
    /// <summary>
    /// All Loop Sound Destroy
    /// </summary>
    public void AllDestroyLoop()
    {
        for (int i = listAudio.Count - 1; i >= 0; i++)
        {
            AudioSource go = listAudio[i];
            listAudio.Remove(go);
            Destroy(go.gameObject);
        }
    }
    

    public void setVolumeBgm(float pVol_bgm)
    {
        volume_bgm = pVol_bgm;
        bgmSource.volume = pVol_bgm;

        for (int i = 0; i < listAudio.Count; i++)
        {
            listAudio[i].volume = pVol_bgm;
        }
    }



    public void muteBgm()
    {
        isMute = true;
        bgmSource.volume = 0;

    }

    public void unMuteBgm()
    {
        isMute = false;
        bgmSource.volume = volume_bgm;

    }



}