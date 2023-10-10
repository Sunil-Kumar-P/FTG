using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic; // Added this line

public class APIAccess : MonoBehaviour
{
    public string apiUrl = "http://127.0.0.1:8000/api/items/?format=api";

    void Start()
    {
        StartCoroutine(GetDataFromAPI());
    }

    IEnumerator GetDataFromAPI()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResult = request.downloadHandler.text;
            Debug.Log(jsonResult);

            // Parse JSON and handle data
            HandleJSON(jsonResult);
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }
    }

    void HandleJSON(string json)
    {
        List<Item> items = JsonUtility.FromJson<List<Item>>(json);

        if (items != null)
        {
            foreach (Item item in items)
            {
                Debug.Log("ID: " + item.id + ", Name: " + item.name + ", Description: " + item.description);
            }
        }
        else
        {
            Debug.Log("Failed to parse JSON.");
        }
    }
}

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public string description;
}
