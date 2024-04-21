using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUIHandler : MonoBehaviour
{
    public Text txtDntDesc;
    public Text txtDntTitle;
    public Button btnToKanjiPractices;

    private void Awake()
    {
        txtDntDesc.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_DNT_DESC);
        txtDntTitle.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_APP_TITLE);
    }

    public void OnBtnToKanjiPracticesClick()
    {
        btnToKanjiPractices.interactable = false;
        // Goto reshu list scene
        SceneManager.LoadScene(Constants.SN_RENSHU_LIST);
    }
}
