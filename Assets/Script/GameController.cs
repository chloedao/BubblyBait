using UnityEngine;

public class GameController : MonoBehaviour
{
    public string currentState; // Exempel på att använda string istället för enum
    private int score;

    void Start()
    {
        currentState = "Loading";  // Initialt tillstånd
        score = 0;
        // Initiera spelet här
    }

    void Update()
    {
        if (currentState == "Playing")
        {
            // Spelet är igång, kan lägga till logik här
        }
        else if (currentState == "Paused")
        {
            // Spelet är pausat, logik för paus här
        }
    }

    public void StartGame()
    {
        currentState = "Playing";  // Byter till Playing
        // Starta spelet här
    }

    public void UpdateScore(int points)
    {
        score += points;
        // Uppdatera poängen på UI
    }

    public void PauseGame()
    {
        currentState = "Paused";  // Byter till Paused
        // Pausa spelet här
    }

    public void RestartGame()
    {
        currentState = "Loading";  // Återgå till loading state
        score = 0;
        // Återställ spelet till startläge
        StartGame();
    }
}
