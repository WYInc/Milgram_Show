using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    [SerializeField] private Animator FadeInAnimator;

    [SerializeField] private string FadeIn = "StartScreenFadeIn";

    [SerializeField] private string FadeOut = "StartScreenFadeOut";

    public GameObject FadeInCanvass;
    public GameObject FadeOutCanvass;

    // Start is called before the first frame update
    void Start()
    {
        FadeOutCanvass.SetActive(false);
        FadeInAnimator.Play(FadeIn);
        StartCoroutine(cancelFadeInImage());
    }

    IEnumerator cancelFadeInImage()
    {
        yield return new WaitForSeconds(3);
        FadeInCanvass.SetActive(false);
    }

    public void playFadeOut()
    {
        StartCoroutine(startFadeOutImage());
        FadeInCanvass.SetActive(true);
        FadeInAnimator.Play(FadeOut);
    }

    IEnumerator startFadeOutImage()
    {
        yield return new WaitForSeconds(3);
        FadeOutCanvass.SetActive(true);
    }

}
