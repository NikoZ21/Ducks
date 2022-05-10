using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float speed = 1f;
    public bool arePositioned = false;

    [Header("Blue Duck")]
    [SerializeField] Transform blueDuck;
    [SerializeField] Transform blueDuckPlaceHolder;
    [SerializeField] bool playOnceBlue = true;

    [Header("Yellow Duck")]
    [SerializeField] Transform yellowDuck;
    [SerializeField] Transform yellowDuckPlaceHolder;
    [SerializeField] bool playOnceYellow = true;

    [Header("Purple Duck")]
    [SerializeField] Transform purpleDuck;
    [SerializeField] Transform purpleDuckPlaceHolder;
    [SerializeField] bool playOncePurple = true;

    private Vector3 _blueStartPosition;
    private Vector3 _yellowStartPosition;
    private Vector3 _purpleStartPosition;

    private SoundManager _soundManager;


    private void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        _blueStartPosition = blueDuck.position;
        _yellowStartPosition = yellowDuck.position;
        _purpleStartPosition = purpleDuck.position;
    }

    void Update()
    {
        SpawnDucks();
        Sounds();
    }

    private void SpawnDucks()
    {
        if (arePositioned) return;
        blueDuck.position = Vector2.MoveTowards(blueDuck.position, blueDuckPlaceHolder.position, speed * Time.deltaTime);
        yellowDuck.position = Vector2.MoveTowards(yellowDuck.position, yellowDuckPlaceHolder.position, speed * Time.deltaTime);
        purpleDuck.position = Vector2.MoveTowards(purpleDuck.position, purpleDuckPlaceHolder.position, speed * Time.deltaTime);
    }

    private void Sounds()
    {
        if (blueDuck.position == blueDuckPlaceHolder.position && playOnceBlue)
        {
            _soundManager.DuckStoppingSound(blueDuck.position);
            playOnceBlue = false;
        }
        if (yellowDuck.position == yellowDuckPlaceHolder.position && playOnceYellow)
        {
            _soundManager.DuckStoppingSound(yellowDuck.position);
            playOnceYellow = false;
        }
        if (purpleDuck.position == purpleDuckPlaceHolder.position && playOncePurple)
        {
            _soundManager.DuckStoppingSound(purpleDuck.position);
            playOncePurple = false;
            arePositioned = true;
        }
    }

    public void resetPositions()
    {
        blueDuck.position = _blueStartPosition;
        yellowDuck.position = _yellowStartPosition;
        purpleDuck.position = _purpleStartPosition;

        arePositioned = false;
    }

    public void resetSounds()
    {
        playOnceBlue = true;
        playOncePurple = true;
        playOnceYellow = true;
    }
}
