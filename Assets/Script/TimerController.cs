using UnityEngine;
using UnityEngine.UI; // För UI-komponenter

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 5f;  // Tiden för att fisken ska nappa (t.ex. 5 sekunder)
    public bool isTimerRunning = false;
    public Text timerText; // UI Text-komponent som visar timern

    void Update()
    {
        if (isTimerRunning)
        {
            // Minska tiden varje sekund
            timeRemaining -= Time.deltaTime;

            // Uppdatera timer-texten på UI
            timerText.text = Mathf.Ceil(timeRemaining).ToString();

            // Om tiden är slut, stoppa timern
            if (timeRemaining <= 0)
            {
                isTimerRunning = false;
                OnTimerEnd(); // Anropa en funktion när timern är slut
            }
        }
    }

    // Starta timern för fisken
    public void StartTimer()
    {
        timeRemaining = 5f; // Sätt starttiden
        isTimerRunning = true;
    }

    // Stoppa timern om användaren inte är stilla
    public void StopTimer()
    {
        isTimerRunning = false;
        timeRemaining = 0f;  // Nollställ tiden om timern stoppar innan den når noll
    }

    // Logik för vad som händer när timern är slut
    private void OnTimerEnd()
    {
        Debug.Log("Tid slut!");
        // Här kan du lägga till logik för att göra något när timern är slut, t.ex. fånga fisken.
    }
}
