using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    //Fade To Other Scene
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //Fade In
    IEnumerator FadeIn() //Fade in Animation
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    //Fade Out
    IEnumerator FadeOut(string scene) //Fade out Animation
    {
        float t = 1f;

        while (t < 0f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene); //Load Scene
    }
}
