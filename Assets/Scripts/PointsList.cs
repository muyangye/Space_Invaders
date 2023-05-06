using System.Collections;
using UnityEngine;

public class PointsList : MonoBehaviour
{
    // This is the script for the "points earned for killing each monster" animation on the menu page
    private float animTime = 0.4f;

    void Start()
    {
        StartCoroutine("StartAnimate");
    }

    IEnumerator StartAnimate()
    {
        // Since we are using coroutines, for loops don't work
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(6).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
        gameObject.transform.GetChild(7).gameObject.SetActive(true);
        yield return new WaitForSeconds(animTime);
    }
}
