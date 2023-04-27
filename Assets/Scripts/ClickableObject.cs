using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Renderer rendererComponent;

    private bool isRed = false;
    /// <summary>
    /// Скорость мерцания
    /// <summary>
    private float blinkSpeed = 0.5f;
    /// <summary>
    /// Запоминаем изначальный цвет колонны
     /// <summary>
    private void Start()
    {
        rendererComponent = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        if (!isRed)
        {
            StartCoroutine(BlinkRed());
        }
    }
    /// <summary>
    /// Меняем цвет колонны и возвращаем изначальный
     /// <summary>
    private IEnumerator BlinkRed()
    {
        isRed = true;
        Color defaultColor = rendererComponent.material.color;
        Color redColor = Color.red;

        while (isRed)
        {
            rendererComponent.material.color = redColor;
            yield return new WaitForSeconds(blinkSpeed);
            rendererComponent.material.color = defaultColor;
            yield return new WaitForSeconds(blinkSpeed);
        }

        rendererComponent.material.color = defaultColor;
    }
}
