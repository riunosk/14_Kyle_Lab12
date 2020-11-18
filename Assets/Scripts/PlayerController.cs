using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public float moveSpeed;
    public float rotateSpeed;
    public GameObject collectedCoins;
    private int coinCount;
    private int totalCoinCount;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Coin")
		{
            coinCount++;
            collectedCoins.GetComponent<Text>().text = "Coins Collected : " + coinCount;
            Destroy(other.gameObject);
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        moveSpeed = 5;
        rotateSpeed = 300;
        totalCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
		{
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
		}
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
		{ 
            transform.Rotate(new Vector3(0, -Time.deltaTime * rotateSpeed, 0));
		}
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.RightArrow)))
		{
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
		}
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.DownArrow)))
		{
            transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
		}
        if (coinCount == totalCoinCount)
		{
            print("You win!");
            SceneManager.LoadScene("Win");
		}
        if (transform.position.y < -5)
		{
            print("You lose");
            SceneManager.LoadScene("Lose");
		}
    }
}
