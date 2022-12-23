using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] gameob;
    GameObject spawnmonster;
    public Transform leftpos, rightpos;
    
    int RandIndex;
    int Randside;

    void Start()
    {
    StartCoroutine(SpawnM());
    }
    // Update is called once per frame
    IEnumerator SpawnM()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 7));
            RandIndex = Random.Range(0, gameob.Length);
            Randside = Random.Range(0, 2);
            spawnmonster = Instantiate(gameob[RandIndex]);
            if (Randside == 0)
            {
                spawnmonster.transform.position = leftpos.position;
                spawnmonster.GetComponent<monster>().speed = Random.Range(1, 4);
            }
            else
            {
                spawnmonster.transform.position = rightpos.position;
                spawnmonster.GetComponent<monster>().speed = -Random.Range(1, 4);
                spawnmonster.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
        }
    }
}
