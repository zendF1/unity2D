using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject stoneObject_1;
    [SerializeField]
    private GameObject stoneObject_2;
    //[SerializeField]
    //private GameObject stoneObject_3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner_1());
        StartCoroutine(Spawner_2());
        //StartCoroutine(Spawner_3());
    }

    IEnumerator Spawner_1() {
        yield return new WaitForSeconds(2);

        Vector3 positionPipe = stoneObject_1.transform.position;
        positionPipe.y = Random.Range(-2.5f, 2.5f);
        Instantiate (stoneObject_1, positionPipe, Quaternion.identity);
         StartCoroutine(Spawner_1());
    }
    IEnumerator Spawner_2()
    {
        yield return new WaitForSeconds(4);

        Vector3 positionPipe = stoneObject_2.transform.position;
        positionPipe.y = Random.Range(-2.5f, 2.5f);
        Instantiate(stoneObject_2, positionPipe, Quaternion.identity);
        StartCoroutine(Spawner_2());
    }
    //IEnumerator Spawner_3()
    //{
    //    yield return new WaitForSeconds(7);

    //    Vector3 positionPipe = stoneObject_3.transform.position;
    //    positionPipe.y = Random.Range(-1.5f, 2.5f);
    //    Instantiate(stoneObject_3, positionPipe, Quaternion.identity);
    //    StartCoroutine(Spawner_3());
    //}
}
