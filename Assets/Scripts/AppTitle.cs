using UnityEngine;
using UnityEngine.UI;

public class AppTitle : MonoBehaviour
{
    public Text txtTitle;
    private void Awake()
    {
        txtTitle.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_APP_TITLE);
    }
}
