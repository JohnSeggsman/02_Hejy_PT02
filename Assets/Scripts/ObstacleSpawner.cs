using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle;

    void Start()
    {
        StartCoroutine(TimedSpawner(1));
    }

    private IEnumerator TimedSpawner(int Timer)
    {
        while (true)
        {
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position = new Vector3(Random.Range(-3, 3), 0, 6), Quaternion.identity);
            yield return new WaitForSeconds(Timer);
        }
    }
}