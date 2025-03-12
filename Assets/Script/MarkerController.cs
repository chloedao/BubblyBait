using UnityEngine;

public class MarkerController : MonoBehaviour
{
    public Vector3 position;   // Positionen f�r markeringen
    public string color;       // F�rg f�r markeringen (t.ex. r�d eller gr�n)

    // Spawnar en markering vid en viss plats
    public void SpawnMarker(Vector3 spawnPosition)
    {
        position = spawnPosition;
        transform.position = position;
        Debug.Log("Marker spawnad vid: " + position);
    }

    // Uppdaterar markeringens position baserat p� anv�ndarens r�relse
    public void UpdatePosition(Vector3 newPosition)
    {
        position = newPosition;
        transform.position = position;
        Debug.Log("Marker uppdaterad till: " + position);
    }

    // �ndrar markeringens f�rg (t.ex. gr�n f�r fiskbar plats, r�d f�r icke-fiskbar plats)
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
        Debug.Log("Marker f�rg �ndrad till: " + color);
    }
}
