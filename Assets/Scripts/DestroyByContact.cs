using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Cannot find 'GameController' script");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        else
        {
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                if (gameController != null)
                    gameController.GameOver();
                else
                    Debug.Log("There is not gameController reference");
            }

            Instantiate(explosion, transform.position, transform.rotation);

            if (gameController != null || other.tag != "Player")
                gameController.AddScore(scoreValue);
            else
                Debug.Log("There is not gameController reference");

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
