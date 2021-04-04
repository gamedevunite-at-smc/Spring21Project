using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float animationSpeed = 10.0f;

    private Color _color;
    public Color color
    {
        set
        {
            if (_color != value)
            {
                _color = value;

                StopAllCoroutines();
                StartCoroutine(LerpColor());
            }
        }
}

    private Color _currentColor;
    public Color currentColor
    {
        set
        {
            spriteRenderer.color = value;
            _currentColor = value;
        }
    }

    public void SetColor(Color color)
    {
        currentColor = color;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator LerpColor()
    {
        while(_currentColor != _color)
        {
            currentColor = Color.Lerp(_currentColor, _color, Time.deltaTime * animationSpeed);

            yield return null;
        }
    }

}
