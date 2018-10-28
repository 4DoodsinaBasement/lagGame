using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikesTag : MonoBehaviour {

	public string scene = "Lose_Menu";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            SceneManager.LoadScene(scene);
        }
    }
}
