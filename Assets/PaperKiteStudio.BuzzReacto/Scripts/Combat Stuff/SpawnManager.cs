using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canPrefab;

    [SerializeField]
    private GameObject waterBottlePrefab;

    void Start()
    {
        StartCoroutine(Spawno2());
        StartCoroutine(SpawnH20());
    }

    IEnumerator Spawno2()
    {
        while(true)
        {
            Vector3 posToSPawn = new Vector3(12, Random.Range(-3f, 3.4f), 0);
            Instantiate(canPrefab, posToSPawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3.4f, 6f));
        }
    }

    IEnumerator SpawnH20()
    {
        while (true)
        {
            Vector3 posToSPawn = new Vector3(12, Random.Range(-3f, 3.4f), 0);
            Instantiate(waterBottlePrefab, posToSPawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2.5f, 6f));
        }
    }
}
