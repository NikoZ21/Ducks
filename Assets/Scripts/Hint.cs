using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] Transform[] ducks;
    [SerializeField] Transform[] buckets;
    [SerializeField] float hintDelay = 1f;

    private GameManager _gameManager;
    private Coroutine _hintCoroutine;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        DisableHints();
    }

    private void DisableHints()
    {
        foreach (var item in ducks)
        {
            item.GetChild(1).gameObject.SetActive(false);
        }
        foreach (var item in buckets)
        {
            item.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        _gameManager.inActiveTimer -= Time.deltaTime;
        if (_gameManager.inActiveTimer <= 0)
        {
            _hintCoroutine = StartCoroutine(ShowHint());
            _gameManager.inActiveTimer = 8;
        }
    }

    private IEnumerator ShowHint()
    {
        int hintIndex = Random.Range(0, ducks.Length);
        Transform hintDuck = ducks[hintIndex].transform;
        Transform childDuck = hintDuck.GetChild(1);
        childDuck.gameObject.SetActive(true);
        string tag = hintDuck.tag;

        yield return new WaitForSeconds(hintDelay);

        childDuck.gameObject.SetActive(false);
        Transform hintBucket = GetMatchingBucket(tag);
        Transform childBucket = hintBucket.GetChild(1);
        childBucket.gameObject.SetActive(true);

        yield return new WaitForSeconds(hintDelay);
        childBucket.gameObject.SetActive(false);

    }

    private Transform GetMatchingBucket(string tag)
    {
        foreach (var item in buckets)
        {
            if (item.tag == tag)
                return item;
        }
        return null;
    }


    public void CancelHint()
    {
        if (_hintCoroutine == null) return;
        StopCoroutine(_hintCoroutine);
        DisableHints();
    }
}
