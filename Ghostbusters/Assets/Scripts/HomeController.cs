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
        // SprawdŸ, czy Audio Source zosta³ przypisany
        if (musicAudioSource == null)
        {
            // Je¿eli nie zosta³ przypisany, próbuj znaleŸæ go automatycznie w dzieciach tego obiektu
            musicAudioSource = GetComponent<AudioSource>();

            // Je¿eli wci¹¿ nie znaleziono, wypisz b³¹d
            if (musicAudioSource == null)
            {
                Debug.LogError("Music Audio Source not assigned and not found in children!");
                return;
            }
        }

        // SprawdŸ, czy przyciski zosta³y przypisane
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

        // Pocz¹tkowe ustawienia
        PlayMusic(); // Dodano w³¹czanie muzyki na starcie
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
        // W³¹cz muzykê
        if (musicAudioSource != null && !musicAudioSource.isPlaying)
        {
            musicAudioSource.Play();
        }
    }

    void StopMusic()
    {
        // Wy³¹cz muzykê
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
