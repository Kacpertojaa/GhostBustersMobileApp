using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectChange : MonoBehaviour
{
    public GameObject exit;
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
        Instantiate(exit, randomDom.transform.position, Quaternion.identity);
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
