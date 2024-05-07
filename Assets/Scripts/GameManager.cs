using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    private Vector3 ballSource = new Vector3(0, 0.6f, 0);
    private bool spacePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    // Update is called once per frame
    void Update()
    {
        spacePressed = Input.GetKey(KeyCode.Space);
    }

    IEnumerator SpawnBalls()
    {
        while(true) {
            if (spacePressed) {
                Instantiate(ballPrefab, ballSource, Quaternion.identity);

                yield return new WaitForSeconds(0.2f);

                /*for (int i = 0; i < 50; i++) {
                    Instantiate(ballPrefab, ballSource, Quaternion.identity);
                }*/
            }

            yield return new WaitUntil(() => spacePressed);
        }
    }
}
