using UnityEngine;

public class ObjectChange : MonoBehaviour
{
    public GameObject[] domki;
    public bool allowsSceneTransition = false;

    void Start()
    {
        InvokeRepeating("ObjectChangeColor", 0f, 10f);
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

        Renderer renderer = randomDom.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.black;
            allowsSceneTransition = true;
        }
    }
}
