using System.Collections;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public float groundRate = 0.1f;
    public GameObject[] ground;
    public int obstacleCount = 0;

    void Start () {
        InvokeRepeating("CreateGround", 0, groundRate);
        Invoke("CreateObstacle", 3);
    }
	
	void Update () {
		
	}

    public void CreateGround() {
        GameObject.Instantiate(ground[0], new Vector3(3.93f, -2.42f, 0f), Quaternion.identity);
    }

    public void CreateObstacle() {
        CancelInvoke("CreateGround");
        CancelInvoke("CreateObstacle");

        switch ((int)Random.RandomRange(0, 4)) {
            case 0:
                InvokeRepeating("CreateGround", 0.55f, groundRate);
                Invoke("CreateObstacle", 3);
                break;
            case 1:
                InvokeRepeating("CreateGround", 1.1f, groundRate);
                Invoke("CreateObstacle", 3);
                break;
            case 2:
                GameObject.Instantiate(ground[1], new Vector3(4.5f, -2.095f, 0f), Quaternion.identity);
                InvokeRepeating("CreateGround", 0f, groundRate);
                Invoke("CreateObstacle", 3);
                break;
            case 3:
                GameObject.Instantiate(ground[2], new Vector3(4.5f, -1.681f, 0f), Quaternion.identity);
                InvokeRepeating("CreateGround", 0f, groundRate);
                Invoke("CreateObstacle", 3);
                break;
        }

        if (obstacleCount == 21) {
            GameStatus.gameStatus = "Game Clear";
            Application.LoadLevel("Result");
        }

        obstacleCount++;
    }
}
