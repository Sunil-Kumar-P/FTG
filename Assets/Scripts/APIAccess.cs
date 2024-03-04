using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class APIAccess : MonoBehaviour
{
    public string apiUrl = " http://localhost:3000/api/person"; // Replace with your actual API URL

    private IEnumerator Start()
    {
        yield return StartCoroutine(GetData());
    }

    private IEnumerator GetData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Error fetching data: " + request.error);
            }
            else
            {
                Debug.Log("success");

                // Use the retrieved data in your game logic here
            }
        }
    }
}
