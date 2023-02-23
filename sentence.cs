using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sentence : MonoBehaviour
{
    [Header("UI�ե�")]
    public TextMeshProUGUI textLabel;
    public Image faceImage;
    [Header("�奻���")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    [Header("�Y��")]
    public Sprite face01, face02;

    bool textFinished;

    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFormFile(textFile);
       //index = 0;
    }
    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count) {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R)&&textFinished) {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI( ));
        }
    }
    void GetTextFormFile(TextAsset file) {
        textList.Clear();
        index = 0;
        var lineDate=file.text.Split('\r','\n', (char)System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lineDate) {
            textList.Add(line);
        }
    }
    IEnumerator SetTextUI() {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index].Trim().ToString()) {
            case "�Z�h":
                faceImage.sprite = face01;
                index++;
                break;
            case "����":
                faceImage.sprite = face02;
                index++;
                break;
        }

        for (int i = 0; i < textList[index].Length; i++) {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;
    }
}
