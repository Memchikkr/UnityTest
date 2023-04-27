using UnityEngine;
using System.Collections;

public class JumpOnMouseDown : MonoBehaviour
{
    delegate void ColumnAction();
    ColumnAction actions;
    /// <summary>
    /// Для метода с цветом
    /// </summary>
    private Renderer rendererComponent;
    private Color newColor = Color.green;
    /// <summary>
    /// Для прыжка
    /// </summary>
    private float elapsedTime = 0f;
    Vector3 startingPos;
    Vector3 targetPos; 
    private Rigidbody rb;
    /// <summary>
    /// Для расширения и сужения
    /// </summary>
    private float targetWidth = 2f; 
    private float duration = 1f;
    private float startWidth;  
    private float currentTime = 0;
    /// <summary>
    /// Сохраняем значения Rigidbody, цвета и ширины объект
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rendererComponent = GetComponent<Renderer>();
        startWidth = transform.localScale.x;
    }
    /// <summary>
    /// Меняем цвет
    /// </summary>
    void ColorObject()
    {
        rendererComponent.material.color = newColor;
    }
    /// <summary>
    /// Осуществляем прыжок
    /// </summary>   
    void JumpObject()
    {
        startingPos = transform.position;
        targetPos = startingPos + new Vector3(0f, 5f, 0f);
        while (elapsedTime < 5f)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, (elapsedTime / 5f));
            elapsedTime += Time.deltaTime;
        }
    }
    /// <summary>
    /// Меняем ширину объекта
    /// </summary>
    void WidthObject()
    {
        currentTime += Time.deltaTime;
        float currentWidth = Mathf.Lerp(startWidth, targetWidth, currentTime / duration);
        transform.localScale = new Vector3(currentWidth, transform.localScale.y, transform.localScale.z);
        if (Mathf.Approximately(currentWidth, targetWidth))
        {
            currentTime = 0f;
        }
    }
    /// <summary>
    /// Возвращаем ширину объекта
    /// </summary>
    void ReturnWidth()
    {
        currentTime += Time.deltaTime;
        float currentWidth = Mathf.Lerp(targetWidth, startWidth, currentTime / duration);
        transform.localScale = new Vector3(currentWidth, transform.localScale.y, transform.localScale.z);
        if (Mathf.Approximately(currentWidth, startWidth))
        {
            currentTime = 0f;
            targetWidth = startWidth;
        }
    }
    IEnumerator ObjectAction()
    {
        actions = JumpObject;
        yield return new WaitForSeconds(1f);
        actions = ColorObject;
        yield return new WaitForSeconds(1f);
        actions = WidthObject;
        yield return new WaitForSeconds(1f);
        actions = ObjectFall;
        yield return new WaitForSeconds(1f);
        actions = ReturnWidth;
        yield return new WaitForSeconds(1f);

    }
    /// <summary>
    /// Отключаем isKinematic, чтобы объект упал
    /// </summary>
    void ObjectFall()
    {
        rb.isKinematic = false;
    }
    private void OnMouseDown()
    {
        StartCoroutine(ObjectAction());
    }
    private void Update()
    {
        actions?.Invoke();
    }
}