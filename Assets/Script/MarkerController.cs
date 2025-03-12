using UnityEngine;

public class MarkerController : MonoBehaviour
{
    public Vector3 position;   // Positionen för markeringen
    public string color;       // Färg för markeringen (t.ex. röd eller grön)

    // Spawnar en markering vid en viss plats
    public void SpawnMarker(Vector3 spawnPosition)
    {
        position = spawnPosition;
        transform.position = position;
        Debug.Log("Marker spawnad vid: " + position);
    }

    // Uppdaterar markeringens position baserat på användarens rörelse
    public void UpdatePosition(Vector3 newPosition)
    {
        position = newPosition;
        transform.position = position;
        Debug.Log("Marker uppdaterad till: " + position);
    }

    // Ändrar markeringens färg (t.ex. grön för fiskbar plats, röd för icke-fiskbar plats)
    public void ChangeColor(string newColor)
    {
        color = newColor;
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            if (newColor == "Green")
            {
                renderer.material.color = Color.green;
            }
            else if (newColor == "Red")
            {
                renderer.material.color = Color.red;
            }
        }
        Debug.Log("Marker färg ändrad till: " + color);
    }
}
