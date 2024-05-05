using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameOverCanvas gameOverCanvas; // Reference to the canvas with the game over message

    void Start()
    {
        // Deactivate the game over canvas at the start of the game
        gameOverCanvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider's gameObject has the tag "Rock"
        if (other.gameObject.CompareTag("rock"))
        {
            // Trigger game over behavior
            gameOverCanvas.ShowGameOver();
        }
    }
}
