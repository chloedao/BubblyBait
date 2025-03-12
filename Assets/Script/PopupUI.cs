using UnityEngine;
using UnityEngine.UI; // För UI-komponenter

public class PopupUI : MonoBehaviour
{
    public Text popupMessage;  // UI-texten för att visa popup meddelanden

    // Visa popup med meddelande
    public void ShowPopup(string message)
    {
        popupMessage.text = message;
        popupMessage.gameObject.SetActive(true); // Gör popup synlig
    }

    // Dölja popup
    public void HidePopup()
    {
        popupMessage.gameObject.SetActive(false); // Dölj popup
    }
}
