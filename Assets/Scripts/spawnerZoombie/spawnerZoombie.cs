using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerZoombie : MonoBehaviour
{
    [SerializeField]
    private GameObject zoombie;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(Spawner_1());

    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(3);

        Vector3 positionTiger = zoombie.transform.position;
        //positionTiger.x = Random.Range(1f, 1.5f);
        positionTiger.y = Random.Range(1.5f, 4f);
        Instantiate(zoombie, positionTiger, Quaternion.identity);
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner_1()
    {
        yield return new WaitForSeconds(5);

        Vector3 positionTiger = zoombie.transform.position;
        //positionTiger.x = Random.Range(1f, 1.5f);
        positionTiger.y = Random.Range(1f, 3f);
        Instantiate(zoombie, positionTiger, Quaternion.identity);
        StartCoroutine(Spawner_1());
    }
}
