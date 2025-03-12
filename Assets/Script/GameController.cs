using UnityEngine;

public class GameController : MonoBehaviour
{
    public string currentState; // Exempel p� att anv�nda string ist�llet f�r enum
    private int score;

    void Start()
    {
        currentState = "Loading";  // Initialt tillst�nd
        score = 0;
        // Initiera spelet h�r
    }

    void Update()
    {
        if (currentState == "Playing")
        {
            // Spelet �r ig�ng, kan l�gga till logik h�r
        }
        else if (currentState == "Paused")
        {
            // Spelet �r pausat, logik f�r paus h�r
        }
    }

    public void StartGame()
    {
        currentState = "Playing";  // Byter till Playing
        // Starta spelet h�r
    }

    public void UpdateScore(int points)
    {
        score += points;
        // Uppdatera po�ngen p� UI
    }

    public void PauseGame()
    {
        currentState = "Paused";  // Byter till Paused
        // Pausa spelet h�r
    }

    public void RestartGame()
    {
        currentState = "Loading";  // �terg� till loading state
        score = 0;
        // �terst�ll spelet till startl�ge
        StartGame();
    }
}
