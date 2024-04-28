// Jimmy Vegas Unity Tutorials
// This Script is for counting down

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public AudioSource readyFX;
    public AudioSource goFX;
    

    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.5f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1.3f);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1.7f);
        countDown1.SetActive(true);
        readyFX.Play();
        PlayerMove.canMove = true;
       
    }

}