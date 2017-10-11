using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    public Text gameStatusText;

	void Update () {
        gameStatusText.text = GameStatus.gameStatus.ToString();
    }

    public void StartGame () {
        Application.LoadLevel("Game");
    }
}
