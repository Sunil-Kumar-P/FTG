using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class calculateCoins : MonoBehaviour
{
    public static int coinCount;
    public TextMeshProUGUI text; 

    // Update is called once per frame
    void Update()
    {
        // Update the text of the coinCountDisplay to show the current coin count
        text.text = coinCount.ToString();
    }
}
