using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float goAgainDelay = 0.5f;
    [SerializeField] ParticleSystem correctVFX;

    private ProgressBar _progressBar;
    private DragAndDrop[] _dragAndDrops;
    private DuckSpawner _duckSpawner;
    private SoundManager _soundManager;

    public float ducksLeft = 3;
    public float inActiveTimer = 10;


    private void Awake()
    {
        _dragAndDrops = FindObjectsOfType<DragAndDrop>();
        _duckSpawner = FindObjectOfType<DuckSpawner>();
        _progressBar = FindObjectOfType<ProgressBar>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (ducksLeft <= 0)
        {
            GoAgain();
        }

        if (_progressBar.GetProgressBar() >= 5)
        {
            ProccessWin();
            RestartGame(); 
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoAgain()
    {
        ProccessWin();
        ActivateDucks();
        _duckSpawner.resetPositions();
        _duckSpawner.resetSounds();
        ducksLeft = 3;
        inActiveTimer = 10;
    }

    private void ProccessWin()
    {
        correctVFX.Play();
        _soundManager.CorrectSound();
        _progressBar.UpdateProgressBar();
    }

    private void ActivateDucks()
    {
        foreach (var dragAndDrop in _dragAndDrops)
        {
            dragAndDrop.gameObject.SetActive(true);
        }
    }
}
