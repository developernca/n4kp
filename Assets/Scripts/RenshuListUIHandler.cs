using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenshuListUIHandler : MonoBehaviour
{
    public int renshuFileCount;
    public int mockCount;
    public GameObject objScrollContent;
    public GameObject pfbBtnEachRenshu;
    public RectTransform scrollContentRect;   

    private void Awake()
    {
        for (int i = 1; i <= mockCount; i++)
        {
            // init button
            GameObject obj = Instantiate(pfbBtnEachRenshu, objScrollContent.transform);
            obj.name = obj.name + "_" + i;
            if (i > renshuFileCount)
            {
                Button btn = obj.GetComponent<Button>();
                btn.interactable = false;
            }
            
        }
        scrollContentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 340f * Mathf.CeilToInt(mockCount / 3f));// mockCount will later be renshuFileCount
    }
}
