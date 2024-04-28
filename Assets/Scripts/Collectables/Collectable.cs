using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int coinCount;
    public Text coinCountDisplay; // Reference to the Text component in the UI

    void Update()
    {
        // Update the text of the coinCountDisplay to show the current coin count
        coinCountDisplay.text = coinCount.ToString();
    }
}
