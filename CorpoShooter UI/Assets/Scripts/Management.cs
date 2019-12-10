using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Management : MonoBehaviour
{
    public Text TouchToZdard;
    /*Color green = new Color(59, 173, 40);
    Color yellow = new Color(229, 236, 28);
    Color black = new Color(0, 0, 0);*/
    void Start()
    {
        TouchToZdard = GetComponent<Text>();
        StartBlinking();
    }
    void Update()
    {
       
    }

    IEnumerator Blink()
    {
        while(true)
        {
            switch (TouchToZdard.color.a.ToString())
            {
                case "0":
                    TouchToZdard.color = new Color(TouchToZdard.color.r, TouchToZdard.color.g, TouchToZdard.color.b, 1);
                    yield return new WaitForSeconds(.3f);
                    break;
                case "1":
                    TouchToZdard.color = new Color(TouchToZdard.color.r, TouchToZdard.color.g, TouchToZdard.color.b, 0);
                    yield return new WaitForSeconds(.3f);
                    break;
                default:
                    break;
            }
        }
    }
    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }

    public void TouchToStartClick()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(activeScene);
        SceneManager.LoadSceneAsync(1);
    }
}
