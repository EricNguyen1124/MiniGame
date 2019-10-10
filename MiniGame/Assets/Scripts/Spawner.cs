using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject myPrefab;
    Vector3 randomSize;
    float spawnOffset;

    void Start()
    {
        StartCoroutine(Delayer());
        spawnOffset = 5f;
    }

    IEnumerator Delayer()
    {
        for (int i = 1; i < 10; i++)
        {
            yield return new WaitForSeconds(2);

            randomSize.Set(Random.Range(0.5f, 3f), Random.Range(0.5f, 3f), Random.Range(0.5f, 3f));
            myPrefab.transform.localScale = randomSize;
            Instantiate(myPrefab, new Vector3(0, spawnOffset, 0), Quaternion.identity);

            spawnOffset = spawnOffset + randomSize.y + 1f;
        }
        Debug.Log("DONE");
    }
}
