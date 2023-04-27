using UnityEngine;
using System.Collections;

public class ClickToFly : MonoBehaviour
{
    /// <summary>
    /// Переменная для плавного перемещения объекта
    /// <summary>
    private float elapsedTime = 0f;

    Vector3 startingPos;
    Vector3 targetPos;
    /// <summary>
    /// Создаём плавное пермещение
    /// <summary>
    IEnumerator LiftObject()
    {
    /// <summary>
    /// Запоминаем изначальную позицию и создаём конечную
    /// <summary>
    startingPos = transform.position;
    targetPos = startingPos + new Vector3(0f, 5f, 0f);

    /// <summary>
    /// Запускаем плавное перемещение вверх
    /// <summary>
    while (elapsedTime < 5f)
    {
        transform.position = Vector3.Lerp(startingPos, targetPos, (elapsedTime / 5f));
        elapsedTime += Time.deltaTime;
        yield return null;
    }
    }

    private void OnMouseDown()
    {
        StartCoroutine(LiftObject());
    }
}
