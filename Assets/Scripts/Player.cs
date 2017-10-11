using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool isAnimation = true;
    public bool isJump = false;
    public int jumpCount = 0;
    public int secondJumpCount = 0; //此App預計以增加空中跳躍次數進行版本更新
    
    public int frameCountPerSeconds = 5;
    public float timer = 0f;
    public Sprite[] sprites;
    public Sprite[] sprites2;
    private SpriteRenderer spriteRenderer;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	void Update () {
		if (isAnimation) {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1f / frameCountPerSeconds));
            int frame = frameIndex % 2;
            spriteRenderer.sprite = sprites[frame];

            if (transform.position.y >= 1) {
                spriteRenderer.sprite = sprites2[0];
            }

            if (Input.GetButtonDown("Jump") && jumpCount < 2) {
                jumpCount++;
                this.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
            }

            if (transform.position.y <= 0) {
                Dead();
            }
        } else {
            spriteRenderer.sprite = sprites2[1];
            GameStatus.gameStatus = "Game Over";
            GoToResult();
        }
    }

    public void Dead () {
        isAnimation = false;
    }

    public void GoToResult () {
        Application.LoadLevel("Result");
    }

    public void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            if (jumpCount == 2) {
                secondJumpCount++;
            }
            jumpCount = 0;
        }
    }
}
