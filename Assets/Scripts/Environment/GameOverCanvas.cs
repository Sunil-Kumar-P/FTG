using UnityEngine;
using UnityEngine.SceneManagement; // Add this for scene management
using UnityEngine.UI;
using TMPro;
public class GameOverCanvas : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static bool GameOver = false;
    public void ShowGameOver()
    {
        // Enable the canvas to show the "Game Over" message
        gameObject.SetActive(true);
        DisplayScore();
        GameOver=true;
        // Stop the game (optional)
        // Time.timeScale = 0f;
    }

    public void DisplayScore()
    {
        text.text = "Coins: "+calculateCoins.coinCount.ToString();
    }

    public static void RestartGame()
    {
        // You can implement your restart logic here
        // For example, you can reload the current scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        calculateCoins.coinCount = 0;
        GameOver = false;
        Time.timeScale = 1f;
    }
}
