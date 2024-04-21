using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnEachRenshu : MonoBehaviour
{
    public Text txtRenshuLvl;// button largest text
    public Text txtResTitle;// percentage title (Ya-Lard, etc)
    public Text txtResVal;// percentage value
    private int nameId;

    private void Start()
    {
        string[] arr = gameObject.name.Split("_");
        nameId = int.Parse(arr[1]);
        txtRenshuLvl.text = nameId.ToString();
        txtResTitle.text = mmfont.Net.Converter.Uni2ZG(MmConstants.RESULT);
        txtResVal.text = PlayerPrefs.GetInt(Constants.RENSHU_PERCENT + nameId, 0) + "%";
    }

    public void OnBtnClick()
    {
        Constants.RENSHU_NUM = nameId;
        SceneManager.LoadScene(Constants.SN_EACH_RENSHU);
    }
}
