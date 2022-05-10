using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBucket : MonoBehaviour
{
    [SerializeField] ParticleSystem spawnVFX;

    void Start()
    {
        EnableSprite(false);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Instantiate(spawnVFX, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.4f);
        EnableSprite(true);
    }

    private void EnableSprite(bool state)
    {
        GetComponent<SpriteRenderer>().enabled = state;
    }
}
