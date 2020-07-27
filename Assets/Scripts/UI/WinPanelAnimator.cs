using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelAnimator : MonoBehaviour
{
    [SerializeField]
    private Sprite fullStar;
    [SerializeField]
    private List<Image> stars;
    [SerializeField]
    private List<Image> buttons;

    private int score = 3;

    private void OnEnable()
    {
        StartCoroutine(Pop());
    }

    private IEnumerator Pop()
    {
        transform.localScale = Vector3.zero;
        while(transform.localScale.x < 1.2f)
        {
            float scaleFactor = Mathf.Lerp(transform.localScale.x, 1.3f, Time.fixedDeltaTime);
            transform.localScale = Vector3.one * scaleFactor;
            yield return new WaitForEndOfFrame();
        }

        while(transform.localScale.x > 1.0f)
        {
            float scaleFactor = Mathf.Lerp(transform.localScale.x, 0.9f, Time.fixedDeltaTime);
            transform.localScale = Vector3.one * scaleFactor;
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.one;

        yield return DisplayStars();

        yield return FadeButtons();
    }

    private IEnumerator DisplayStars()
    {
        for(int i = 0; i < score; i++)
        {
            stars[i].sprite = fullStar;
            yield return new WaitForSeconds(0.75f);
        }
    }

    private IEnumerator FadeButtons()
    {
        for (float alpha = 0.0f; alpha < 1.0f; alpha += Time.deltaTime)
        {
            foreach (var button in buttons)
            {
                Color color = button.color;
                color.a = alpha;
                button.color = color;
            }

            yield return new WaitForEndOfFrame();
        }
    }

}
