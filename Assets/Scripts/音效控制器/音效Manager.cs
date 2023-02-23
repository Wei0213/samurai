using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class 音效Manager : MonoBehaviour
{
    static 音效Manager instance;
    [Header("背景音樂")]
    public AudioClip 背景音樂_一般;
    public AudioClip 背景音樂_森林;
    public AudioClip 背景音樂_村莊;
    public AudioClip 背景音樂_魔王;
    public AudioClip 背景音樂_ToBeContinue;

    [Header("主角音效")]
    public AudioClip 主角音效_走路;
    public AudioClip 主角音效_揮刀;
    public AudioClip 主角音效_飛鏢;
    public AudioClip 主角音效_喝藥水;
    public AudioClip 主角音效_受傷;



    [Header("怪物音效")]
    public AudioClip 怪物音效_熊吼;
    public AudioClip 怪物音效_毛毛蟲死掉;
    public AudioClip 怪物音效_四天王揮拳;
    public AudioClip 怪物音效_四天王拍地板;

    [Header("場景音效")]
    public AudioClip 場景音效_鋼鐵;
    public AudioClip 場景音效_傳送門;
    public AudioClip 場景音效_按鈕;
    //各種AudioSource
    AudioSource 背景音樂Source;
    AudioSource 主角音效Source;
    AudioSource 怪物音效Source;
    AudioSource 場景音效Source;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        背景音樂Source = gameObject.AddComponent<AudioSource>();
        主角音效Source = gameObject.AddComponent<AudioSource>();
        怪物音效Source = gameObject.AddComponent<AudioSource>();
        場景音效Source = gameObject.AddComponent<AudioSource>();
    }
    //背景音樂
    public static void 播放背景音樂_封面()
    {
        instance.背景音樂Source.clip = instance.背景音樂_一般;
        instance.背景音樂Source.loop = true;
        instance.背景音樂Source.Play();
    }
    public static void 播放背景音樂_森林()
    {
        instance.背景音樂Source.clip = instance.背景音樂_森林;
        instance.背景音樂Source.loop = true;
        instance.背景音樂Source.Play();
    }
    public static void 播放背景音樂_村莊()
    {
        instance.背景音樂Source.clip = instance.背景音樂_村莊;
        instance.背景音樂Source.loop = true;
        instance.背景音樂Source.Play();
    }
    public static void 播放背景音樂_魔王()
    {
        instance.背景音樂Source.clip = instance.背景音樂_魔王;
        instance.背景音樂Source.loop = true;
        instance.背景音樂Source.Play();
    }
    public static void 播放背景音樂_ToBeContinue()
    {
        instance.背景音樂Source.clip = instance.背景音樂_ToBeContinue;
        instance.背景音樂Source.loop = true;
        instance.背景音樂Source.Play();
    }

    //主角音效
    public static void 播放主角音效_走路()
    {
        instance.主角音效Source.clip = instance.主角音效_走路;
        instance.主角音效Source.Play();
    }
    public static void 播放主角音效_揮刀()
    {
        instance.主角音效Source.clip = instance.主角音效_揮刀;
        instance.主角音效Source.Play();
    }
    public static void 播放主角音效_飛鏢()
    {
        instance.主角音效Source.clip = instance.主角音效_飛鏢;
        instance.主角音效Source.Play();
    }
    public static void 播放主角音效_喝藥水()
    {
        instance.主角音效Source.clip = instance.主角音效_喝藥水;
        instance.主角音效Source.Play();
    }
    public static void 播放主角音效_受傷()
    {
        instance.主角音效Source.clip = instance.主角音效_受傷;
        instance.主角音效Source.Play();
    }
    

    //怪物音效
    public static void 播放怪物音效_熊吼()
    {
        instance.怪物音效Source.clip = instance.怪物音效_熊吼;
        instance.怪物音效Source.Play();
    }
    public static void 播放怪物音效_毛毛蟲死掉()
    {
        instance.怪物音效Source.clip = instance.怪物音效_毛毛蟲死掉;
        instance.怪物音效Source.Play();
    }
    public static void 播放怪物音效_四天王揮拳()
    {
        instance.怪物音效Source.clip = instance.怪物音效_四天王揮拳;
        instance.怪物音效Source.Play();
    }
    public static void 播放怪物音效_四天王拍地板()
    {
        instance.怪物音效Source.clip = instance.怪物音效_四天王拍地板;
        instance.怪物音效Source.Play();
    }
    

    //場景音效
    public static void 播放場景音效_鋼鐵()
    {
        instance.場景音效Source.clip = instance.場景音效_鋼鐵;
        instance.場景音效Source.Play();
    }
    public static void 播放場景音效_傳送門()
    {
        instance.場景音效Source.clip = instance.場景音效_傳送門;
        instance.場景音效Source.Play();
    }
    public static void 播放場景音效_按鈕()
    {
        instance.場景音效Source.clip = instance.場景音效_按鈕;
        instance.場景音效Source.Play();
    }
    
}
