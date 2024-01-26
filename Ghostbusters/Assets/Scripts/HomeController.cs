using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public Button playButton;
    public Button stopButton;
    public Button startButton;
    public Button exitButton;
    public AudioSource musicAudioSource;

    void Start()
    {
        // Sprawd�, czy Audio Source zosta� przypisany
        if (musicAudioSource == null)
        {
            // Je�eli nie zosta� przypisany, pr�buj znale�� go automatycznie w dzieciach tego obiektu
            musicAudioSource = GetComponent<AudioSource>();

            // Je�eli wci�� nie znaleziono, wypisz b��d
            if (musicAudioSource == null)
            {
                Debug.LogError("Music Audio Source not assigned and not found in children!");
                return;
            }
        }

        // Sprawd�, czy przyciski zosta�y przypisane
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayMusic);
        }

        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopMusic);
        }

        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }

        // Pocz�tkowe ustawienia
        PlayMusic(); // Dodano w��czanie muzyki na starcie
    }

    public void gotoGame()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene(SceneData.MapView);
    }

    public void exitGame()
    {
        Debug.Log("Exiting the game");
        Application.Quit();
    }

    void PlayMusic()
    {
        // W��cz muzyk�
        if (musicAudioSource != null && !musicAudioSource.isPlaying)
        {
            musicAudioSource.Play();
        }
    }

    void StopMusic()
    {
        // Wy��cz muzyk�
        if (musicAudioSource != null && musicAudioSource.isPlaying)
        {
            musicAudioSource.Stop();
        }
    }

    void StartGame()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene(SceneData.MapView);
    }

    void ExitGame()
    {
        Debug.Log("Exiting the game");
        Application.Quit();
    }
}
