using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 10;
    public float jumpForce = 5; // Adjust as needed
    private GameObject Player;

    public string apiUrl = "http://127.0.0.1:3000/api/playerposition"; // Replace with your actual API URL
    public string jsonResponse;
    void Start()
    {
        StartCoroutine(GetDataContinuously());
    }

     IEnumerator GetDataContinuously()
    {
        while (true)
        {
            yield return GetData();
            yield return new WaitForSeconds(1f); // Adjust the interval as needed
        }
    }
     IEnumerator GetData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error fetching data: " + request.error);
            }
            else
            {
                jsonResponse = request.downloadHandler.text;
                JSONNode jsonNode = JSON.Parse(jsonResponse);

                // Check if the JSON response is an array
                if (jsonNode.IsArray)
                {
                    // Access the first element of the array
                    JSONNode firstElement = jsonNode[0];

                    // Extract the "gridPosition" property
                    JSONNode gridPositionNode = firstElement["gridPosition"];

                    // Access individual properties of "gridPosition"
                    bool left = gridPositionNode["left"].AsBool;
                    bool right = gridPositionNode["right"].AsBool;
                    bool center = gridPositionNode["center"].AsBool;
                    bool top = gridPositionNode["top"].AsBool;
                    // Move the player based on gridPosition data
                    if (left && !IsPlayerOnLeft())
                    {
                        MovePlayerToLeft();
                        Debug.Log("left");
                    }
                    else if (right && !IsPlayerOnRight())
                    {
                        MovePlayerToRight();
                        Debug.Log("Right");
                    }
                    else if (center && !IsPlayerInCenter())
                    {
                        MovePlayerToCenter();
                        Debug.Log("center");
                    }
                    if (IsPlayerGrounded() && top)
                    {
                        PerformJump();
                        Debug.Log("top");
                    }
                }
                else
                {
                    Debug.LogError("JSON response is not an array.");
                }
            }
        }
    }
     bool IsPlayerGrounded()
    {
        // Check if the player is grounded (e.g., touching the ground)
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }

    void PerformJump()
    {
        // Perform a jump by applying a vertical velocity
        // GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        transform.Translate(Vector3.up * Time.deltaTime * jumpForce, Space.World);
    }
    bool IsPlayerOnLeft()
    {
        // Check if the player is on the left side
        return transform.position.x < -0.1f;
    }

    bool IsPlayerOnRight()
    {
        // Check if the player is on the right side
        return transform.position.x > 0.1f;
    }

    bool IsPlayerInCenter()
    {
        // Check if the player is in the center
        return transform.position.x == 0;
    }

    void MovePlayerToLeft()
    {
        // Move the player to the left
        transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
    }

    void MovePlayerToRight()
    {
        // Move the player to the right
          transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
    }

    void MovePlayerToCenter()
    {
        // Move the player to the center
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    void ClampPositionToBounds()
    {
        Vector3 playerSize = Player.transform.localScale;
        float minX = Player.transform.position.x - playerSize.x / 2;
        float maxX = Player.transform.position.x + playerSize.x / 2;
        float minZ = Player.transform.position.z - playerSize.z / 2;
        float maxZ = Player.transform.position.z + playerSize.z / 2;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);
        transform.position = clampedPosition;
    }
    void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // Move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        // Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }



        // Move in the y-direction when W or Space is pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpForce, Space.World);
        }
    }



}
