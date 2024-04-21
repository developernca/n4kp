using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EachQuestPanel : MonoBehaviour
{
    // Question UIs
    public GameObject objPanelKanryo;
    public RectTransform topPanelRect;
    public Text txtQuestId;
    public Text txtQuestion;
    public Text[] txtAnsLabelArr;
    public Image imgAnsCorrect;
    public Image imgAnsWrong;
    public Text txtAnswerNum;
    // answer
    public int answer;
    // toogle group component
    public ToggleGroup tgGroup;

    private void OnEnable()
    {
        RenshuKanryoHandler.Kanyo += OnKanryo;
    }

    private void OnDisable()
    {
        RenshuKanryoHandler.Kanyo -= OnKanryo;
    }

    /// <summary>
    ///     Call when kanryo button is clicked to check answer. (Callback)
    /// </summary>
    public void OnKanryo()
    {
        objPanelKanryo.SetActive(true);
        Toggle tg = tgGroup.GetFirstActiveToggle();
        int choosen = tg == null ? -99 : int.Parse(tg.name);
        if (choosen == answer)// correct answer
        {
            imgAnsCorrect.gameObject.SetActive(true);
            RenshuKanryoHandler.kanryoMark += 1;
        }
        else// wrong answer
        {
            imgAnsWrong.gameObject.SetActive(true);
        }
        txtAnswerNum.gameObject.SetActive(true);
        txtAnswerNum.text = answer.ToString();
    }
}
