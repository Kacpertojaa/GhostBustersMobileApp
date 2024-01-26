using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectChange : MonoBehaviour
{
    public GameObject[] domki;
    public bool allowsSceneTransition = false;

    void Start()
    {
        Invoke("ObjectChangeColor", 5f);
    }

    void ObjectChangeColor()
    {
        if (domki.Length == 0)
        {
            Debug.LogError("Brak dost�pnych obiekt�w w tablicy domki.");
            return;
        }

        int randomDomIndex = Random.Range(0, domki.Length);
        GameObject randomDom = domki[randomDomIndex];

        Renderer renderer = randomDom.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Zmiana koloru na czarny
            renderer.material.color = Color.black;

            // Dodanie interakcji 
            randomDom.AddComponent<BoxCollider>(); // Dodanie collidera, aby obiekt by� klikalny
            randomDom.AddComponent<ObjectClickHandler>(); // Dodanie skryptu obs�uguj�cego klikni�cie
        }
    }
}

public class ObjectClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        // Po klikni�ciu, przej�cie do innej sceny
        SceneManager.LoadScene(SceneData.MenuView);
    }
}
