using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] AudioClip correctSFX;
    [SerializeField] AudioClip wrongSFX;
    [SerializeField] [Range(0, 1f)] float volume = 0.5f;

    private Hint _hint;
    private GameManager _gameManager;
    private DuckSpawner _duckSpawner;
    private SoundManager _soundManager;
    private Camera _cam;
    private bool isMatch = false;


    private void Awake()
    {
        _cam = Camera.main;
        _gameManager = FindObjectOfType<GameManager>();
        _duckSpawner = FindObjectOfType<DuckSpawner>();
        _hint = FindObjectOfType<Hint>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isMatch = transform.tag == collision.tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isMatch = false;
    }

    private void OnMouseUp()
    {
        if (isMatch)
        {
            ProccessCorrectMatch();
        }
        else
        {
            ProccessWrongMatch();
        }
    }

    private void ProccessWrongMatch()
    {
        _soundManager.WrongSound(transform.position);
        transform.position = startPosition.position;
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void ProccessCorrectMatch()
    {
        _gameManager.ducksLeft--;
        _soundManager.PopSound(transform.position);
        transform.gameObject.SetActive(false);
    }

    private void OnMouseDrag()
    {
        if (_duckSpawner.arePositioned == false) return;
        _gameManager.inActiveTimer = 8;
        _hint.CancelHint();

        transform.position = GetMousePosition();
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    Vector3 GetMousePosition()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
