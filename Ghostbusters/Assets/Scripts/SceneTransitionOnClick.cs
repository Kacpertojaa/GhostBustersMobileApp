using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionOnClick : MonoBehaviour
{
    public bool allowsSceneTransition = false;

    void Start()
    {
        if (allowsSceneTransition)
        {
            var clickable = gameObject.AddComponent<ClickableObject>()
        }
    }
}

