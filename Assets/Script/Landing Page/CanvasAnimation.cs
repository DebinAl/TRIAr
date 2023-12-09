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

    float timer;
    float offset = 10f;
    float delay = 0.5f;
    float speed = 0.2f;
    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        _transparent = transform.Find("Transparent").GetComponent<Image>();
        _logo = transform.Find("Logo").GetComponent<RectTransform>();
        _text = transform.Find("Text").GetComponent<RectTransform>();
        _button = transform.Find("Button").GetComponent<RectTransform>();

        _logoPoint = new Vector2(_logo.anchoredPosition.x, _logo.anchoredPosition.y - offset);
        _textPoint = new Vector2(_text.anchoredPosition.x, _text.anchoredPosition.y - offset);
        _buttonPoint = new Vector2(_button.anchoredPosition.x, _button.anchoredPosition.y - offset);

        IntroAnimation();
    }

    void IntroAnimation()
    {
        TransparentChange();

        StartCoroutine(ObjectTransform());
    }

    void TransparentChange()
    {
        Color color = _transparent.color;
        color.a = 1f;
        timer = 1f;

        while(timer <= Time.deltaTime)
        {
            _transparent.color = color;

            color.a = color.a - 0.1f;

            timer -= Time.deltaTime;
        }
    }

    IEnumerator ObjectTransform()
    {
        yield return new WaitForSeconds(delay);
        _logo.position = Vector2.SmoothDamp(_logoPoint, _logo.position, ref velocity, speed);
    }
}
