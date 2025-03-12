using UnityEngine;
using UnityEngine.UI; // F�r UI-komponenter

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 5f;  // Tiden f�r att fisken ska nappa (t.ex. 5 sekunder)
    public bool isTimerRunning = false;
    public Text timerText; // UI Text-komponent som visar timern

    void Update()
    {
        if (isTimerRunning)
        {
            // Minska tiden varje sekund
            timeRemaining -= Time.deltaTime;

            // Uppdatera timer-texten p� UI
            timerText.text = Mathf.Ceil(timeRemaining).ToString();

            // Om tiden �r slut, stoppa timern
            if (timeRemaining <= 0)
            {
                isTimerRunning = false;
                OnTimerEnd(); // Anropa en funktion n�r timern �r slut
            }
        }
    }

    // Starta timern f�r fisken
    public void StartTimer()
    {
        timeRemaining = 5f; // S�tt starttiden
        isTimerRunning = true;
    }

    // Stoppa timern om anv�ndaren inte �r stilla
    public void StopTimer()
    {
        isTimerRunning = false;
        timeRemaining = 0f;  // Nollst�ll tiden om timern stoppar innan den n�r noll
    }

    // Logik f�r vad som h�nder n�r timern �r slut
    private void OnTimerEnd()
    {
        Debug.Log("Tid slut!");
        // H�r kan du l�gga till logik f�r att g�ra n�got n�r timern �r slut, t.ex. f�nga fisken.
    }
}
