using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAnimation : MonoBehaviour
{
    Image _transparent;
    RectTransform _logo;
    RectTransform _text;
    RectTransform _button;

    Vector2 _logoPoint;
    Vector2 _textPoint;
    Vector2 _buttonPoint;

    float offset = 90f;
    float delay = 0.2f;
    float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        _transparent = transform.Find("Transparent").GetComponent<Image>();
        _logo = transform.Find("Logo").GetComponent<RectTransform>();
        _text = transform.Find("Text").GetComponent<RectTransform>();
        _button = transform.Find("Button").GetComponent<RectTransform>();

        _logoPoint = new Vector2(_logo.anchoredPosition.x, _logo.anchoredPosition.y + offset);
        _textPoint = new Vector2(_text.anchoredPosition.x, _text.anchoredPosition.y + offset);
        _buttonPoint = new Vector2(_button.anchoredPosition.x, _button.anchoredPosition.y + offset);

        StartCoroutine(IntroAnimation());
        
    }

    private IEnumerator IntroAnimation()
    {
        TransparentChange();

        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveObject(_logo, _logoPoint));

        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveObject(_text, _textPoint));

        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveObject(_button, _buttonPoint));
    }

    private void TransparentChange()
    {
        
        _transparent.CrossFadeAlpha(0f, 1.2f, false);
    }

    private IEnumerator MoveObject(RectTransform rectTransform, Vector2 targetPosition)
    {
        Vector2 currentVelocity = Vector2.zero;

        while (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 0.01f)
        {
            rectTransform.anchoredPosition = Vector2.SmoothDamp(rectTransform.anchoredPosition, targetPosition, ref currentVelocity, speed);
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
    }
}
