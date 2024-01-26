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
            Debug.LogError("Brak dostêpnych obiektów w tablicy domki.");
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
        // Po klikniêciu, przejœcie do innej sceny
        SceneManager.LoadScene(SceneData.MenuView);
    }
}
