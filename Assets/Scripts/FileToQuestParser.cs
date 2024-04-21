using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileToQuestParser : MonoBehaviour
{
    public GameObject pfbEachQuest;
    public RectTransform scrollContentRect;

    private void Awake()
    {
        QuestList list = JsonUtility.FromJson<QuestList>(Resources.Load<TextAsset>("JSON/renshu" + Constants.RENSHU_NUM).text);
        int numberOfQuest = list.items.Count;
        scrollContentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Constants.Q_PANEL_HEIGHT * numberOfQuest);
        SaveQuestionCount(numberOfQuest);
        foreach (EachQuestData item in list.items)
        {
            // Set to scroll view content
            GameObject obj = Instantiate(pfbEachQuest, transform);// parent transform will be Scroll Content GO
            EachQuestPanel script = obj.GetComponent<EachQuestPanel>();
            script.txtQuestion.text = item.q;
            script.txtQuestId.text = item.id.ToString();
            string[] optionList = item.o.Split("、");// non-answers list
            int answer = Random.Range(0, 4);// where to put answer 0..3
            script.answer = answer + 1;// 1 .. 4
            int len = optionList.Length;
            bool ansAdded = false;
            for (int i = 0; i < 4; i++)
            {
                if (answer == i)
                {
                    script.txtAnsLabelArr[i].text = item.a;
                    ansAdded = true;
                    continue;
                }
                if (ansAdded)
                {
                    script.txtAnsLabelArr[i].text = optionList[i - 1];
                    continue;
                }
                script.txtAnsLabelArr[i].text = optionList[i];
            }
            //
            RectTransform rect = script.topPanelRect;
            script.topPanelRect.localPosition = new Vector3(rect.localPosition.x, (Constants.Q_PANEL_HEIGHT * -1) * (item.id - 1), rect.localPosition.z);
        }
    }

    private void SaveQuestionCount(int count)
    {
        PlayerPrefs.SetInt(Constants.RENSHU_QUEST_CNT + Constants.RENSHU_NUM, count);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class QuestList
    {
        public List<EachQuestData> items;
    }
}
