using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public int disRun;
    private bool isAddingDis = false;
    public float disDelay = 0.35f;

    // Update is called once per frame
    void Update()
    {
        if (!isAddingDis)
        {
            isAddingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        isAddingDis = false;
    }
}
