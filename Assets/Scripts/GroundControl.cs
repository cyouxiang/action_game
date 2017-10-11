using System.Collections;
using UnityEngine;

public class GroundControl : MonoBehaviour {

    public float groundMoveSpeed = 4f;

    void Update () {
		this.transform.Translate(Vector3.left * groundMoveSpeed * Time.deltaTime);
        Vector3 position = this.transform.position;

        if (position.x <= -4) {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {
            other.GetComponent<Player>().Dead();
        }
    }

}
