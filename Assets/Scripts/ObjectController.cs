using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

    delegate void ColumnAction();
    ColumnAction actions;
    GameObject column;
    /// <summary>
    /// Красная колона
    /// </summary>
    GameObject redColumn;
    /// <summary>
    /// Синяя колона
    /// </summary>
    GameObject blueColumn;
    MeshRenderer myRenderer;
    Vector3 rotVector = new Vector3(0, 0.1f, 0);
    private void Start()
    {
        // получаем собственный MeshRenderer
        myRenderer = gameObject.GetComponent<MeshRenderer>();
        SetColumnsMesh();
        CreateColumns();
    }
    /// <summary>
    /// Создаём объект из нашего цилиндра, для инстанцирования
    /// </summary>
    void SetColumnsMesh()
    {
        column = new GameObject();
        column.AddComponent<MeshFilter>();
        column.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh; 
        column.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
    }
    /// <summary>
    /// Создаём и красим примитивы колонн из меша 
    /// </summary>
    void CreateColumns()
    {
        //Создаём экземпляры колонн
        redColumn = Instantiate(column,transform.position,Quaternion.identity);
        blueColumn = Instantiate(column, transform.position, Quaternion.identity);
        //Задаём цвета
        redColumn.GetComponent<MeshRenderer>().material.color = Color.red;
        blueColumn.GetComponent<MeshRenderer>().material.color = Color.blue;
        redColumn.SetActive(false);
        blueColumn.SetActive(false);
    }
    /// <summary>
    /// Вращение примитивов
    /// </summary>
    void MovePrimitives()
    {
        redColumn.SetActive(true);
        blueColumn.SetActive(true);
        redColumn.transform.Translate(Vector3.forward*Time.deltaTime);
        blueColumn.transform.Translate(Vector3.back * Time.deltaTime);
        if (myRenderer.enabled==true) HideMesh();

    }

    void RotationPrimitives()
    {
        transform.Rotate(rotVector);
    }
    IEnumerator ColumnsAction()
    {
        actions = RotationPrimitives;       
        yield return new WaitForSeconds(10f);
        actions = MovePrimitives;
        yield return new WaitForSeconds(4f);
        actions = StopActions;
        
    }
    void StopActions()
    {
        blueColumn.SetActive(false);
        Destroy(redColumn);
        ShowMesh();
        StopAllCoroutines();
    }
    private void OnMouseDown()
    {
        StartCoroutine(ColumnsAction());

    }
    void HideMesh()
    {
        myRenderer.enabled = false;
    }
    void ShowMesh()
    {
        myRenderer.enabled = true;
    }
    private void Update()
    {
        actions?.Invoke();
    }
}