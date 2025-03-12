using UnityEngine;

public class FishController : MonoBehaviour
{
    public float speed = 2f;         // Simhastighet
    public float rotationSpeed = 2f; // Hur snabbt fisken roterar
    public float swimRadius = 5f;    // Område där fisken simmar
    private Vector3 targetPosition;

    void Start()
    {
        SetNewTargetPosition();
    }

    void Update()
    {
        Swim();
    }

    void Swim()
    {
        // Flytta mot målposition
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // **ROTATION – VRID FISKEN MJUKT**
        Vector3 direction = (targetPosition - transform.position).normalized; // Riktning mot målet
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction); // Skapa en riktning att rotera mot
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Mjuk rotation
        }

        // Om fisken når målet, välj en ny position
        if (Vector3.Distance(transform.position, targetPosition) < 0.3f)
        {
            SetNewTargetPosition();
        }
    }

    void SetNewTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * swimRadius;
        randomDirection.y = transform.position.y; // Håll fisken på samma djup
        targetPosition = transform.position + randomDirection;
    }
}
