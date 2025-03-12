using UnityEngine;
using UnityEngine.UI; // För UI-komponenter

public class ScoreController : MonoBehaviour
{
    public Text scoreText; // UI Text-komponent som visar spelarens poäng
    private int score;     // Spelarens poäng

    void Start()
    {
        score = 0;  // Sätt startpoängen till 0
        UpdateScoreUI();
    }

    // Uppdatera poäng UI-texten
    public void UpdateScore(int points)
    {
        score += points;  // Lägg till poängen
        UpdateScoreUI();   // Uppdatera UI med den nya poängen
    }

    // Uppdaterar UI-texten som visar spelarens poäng
    private void UpdateScoreUI()
    {
        scoreText.text = "Poäng: " + score.ToString();
    }
}
