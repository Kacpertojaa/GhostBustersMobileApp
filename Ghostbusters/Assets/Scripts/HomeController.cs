using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script has just started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotoGame()
    {
        SceneManager.LoadScene(SceneData.gameview);
    }
}
