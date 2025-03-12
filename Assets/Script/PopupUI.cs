using UnityEngine;
using UnityEngine.UI; // F�r UI-komponenter

public class PopupUI : MonoBehaviour
{
    public Text popupMessage;  // UI-texten f�r att visa popup meddelanden

    // Visa popup med meddelande
    public void ShowPopup(string message)
    {
        popupMessage.text = message;
        popupMessage.gameObject.SetActive(true); // G�r popup synlig
    }

    // D�lja popup
    public void HidePopup()
    {
        popupMessage.gameObject.SetActive(false); // D�lj popup
    }
}
