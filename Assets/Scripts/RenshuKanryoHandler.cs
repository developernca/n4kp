using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RenshuKanryoHandler : MonoBehaviour
{
    public static event Action Kanyo;
    public static int kanryoMark;
    public RectTransform rectTransScrollContent;
    public Button btnKanryo;
    public Button btnRetake;
    public Text txtBtnKanryoText;
    public Text txtBtnRetakeText;
    private bool takeTest;
    private void Awake()
    {
        takeTest = false;
        kanryoMark = 0;
    }

    private void OnEnable()
    {
        CloseScene.DisposeScene += OnDisposeScene;
    }

    private void Start()
    {
        txtBtnKanryoText.text = mmfont.Net.Converter.Uni2ZG(MmConstants.BTN_KANYO);
        txtBtnRetakeText.text = mmfont.Net.Converter.Uni2ZG(MmConstants.BTN_RETAKE);
    }

    private void OnDisable()
    {
        CloseScene.DisposeScene -= OnDisposeScene;
    }

    private void OnDisposeScene()
    {
        if (!takeTest) return;
        SaveRenshuResultPercentage();
    }

    public void OnBtnKanryoClick()
    {
        // scroll content to the top BGN --
        Vector3 locPos = rectTransScrollContent.localPosition;
        rectTransScrollContent.localPosition = new Vector3(locPos.x, 0f, locPos.z);
        // scroll content to the top END --
        takeTest = true;
        btnKanryo.gameObject.SetActive(false);
        btnRetake.gameObject.SetActive(true);
        Kanyo?.Invoke();
    }

    public void OnBtnRetakeClick()
    {
        btnRetake.gameObject.SetActive(false);
        SaveRenshuResultPercentage();
        SceneManager.LoadScene(Constants.SN_EACH_RENSHU);
    }

    private void SaveRenshuResultPercentage()
    {
        float totalMark = kanryoMark;
        float totalQuest = PlayerPrefs.GetInt(Constants.RENSHU_QUEST_CNT + Constants.RENSHU_NUM);
        float percentage = (totalMark / totalQuest) * 100f;
        PlayerPrefs.SetInt(Constants.RENSHU_PERCENT + Constants.RENSHU_NUM, Mathf.RoundToInt(percentage));
    }
}
