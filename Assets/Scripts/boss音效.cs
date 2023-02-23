using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss音效 : MonoBehaviour
{
    public void 揮拳() {
        音效Manager.播放怪物音效_四天王揮拳();
    }
    public void 拍地板() {
        音效Manager.播放怪物音效_四天王拍地板();
    }
}
