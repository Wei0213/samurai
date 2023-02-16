using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 回到森林 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        音效Manager.播放背景音樂_森林();
    }

    public void 遇到魔王音效()
    {
        音效Manager.播放背景音樂_魔王();
    }
    public void 遇到ToBeContinue()
    {
        音效Manager.播放背景音樂_ToBeContinue();
    }
}
