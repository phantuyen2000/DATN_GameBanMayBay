using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> meteors;
    [SerializeField] float minDelay = 5f;
    [SerializeField] float maxDelay = 10f;
    [SerializeField] float xMin=-8f;
    [SerializeField] float xMax=-3f;
    [SerializeField] float yMin=-8f;
    [SerializeField] float yMax=-3f;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            GameObject meClone = Instantiate(meteors[Random.Range(0, meteors.Count)], transform.position, Quaternion.identity) as GameObject;
            float scale = Random.Range(0.8f, 3f);
            meClone.transform.localScale = new Vector3(scale, scale, scale);
            meClone.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(xMin, xMax), (Random.Range(yMin, yMax)));
        }
    }
}
