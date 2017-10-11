using System.Collections;
using UnityEngine;

public class Top : MonoBehaviour {

    private void Start () {
        Screen.SetResolution(600, 978, false);
    }

    public void StartGame () {
        Application.LoadLevel("Game");
    }
}
