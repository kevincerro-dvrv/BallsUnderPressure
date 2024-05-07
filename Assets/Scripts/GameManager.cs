using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject ballPrefab;
    private Vector3 ballSource = new Vector3 (0, 0.6f, 0);
    private float maxSpeed = 50f;

    private bool ballSourceActive;
    // Start is called before the first frame update
    void Start() {
        ballSourceActive = false;
        StartCoroutine(SpawnBall());        
    }

    // Update is called once per frame
    void Update() {
        //Mientras se presione la espaciadora se espanean bolas
        //a una cadencia de 10 por  segundo
        ballSourceActive = Input.GetKey(KeyCode.Space);       
    }

    private IEnumerator SpawnBall() {
        while(true) {
            if(ballSourceActive) {
                GameObject ballGO = Instantiate(ballPrefab, ballSource, Quaternion.identity);
                ballGO.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * maxSpeed, ForceMode.Force);

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
