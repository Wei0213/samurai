using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class 血條 : MonoBehaviour
{
    [SerializeField] Gradient 漸層;
    [SerializeField] Image 血條圖像;
    [SerializeField] Slider 血量計;
    public void 改變漸層色() {
        血條圖像.color = 漸層.Evaluate(血量計.normalizedValue);

    }
}
