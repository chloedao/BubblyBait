using UnityEngine;
using UnityEngine.UI; // F�r UI-komponenter

public class ScoreController : MonoBehaviour
{
    public Text scoreText; // UI Text-komponent som visar spelarens po�ng
    private int score;     // Spelarens po�ng

    void Start()
    {
        score = 0;  // S�tt startpo�ngen till 0
        UpdateScoreUI();
    }

    // Uppdatera po�ng UI-texten
    public void UpdateScore(int points)
    {
        score += points;  // L�gg till po�ngen
        UpdateScoreUI();   // Uppdatera UI med den nya po�ngen
    }

    // Uppdaterar UI-texten som visar spelarens po�ng
    private void UpdateScoreUI()
    {
        scoreText.text = "Po�ng: " + score.ToString();
    }
}
