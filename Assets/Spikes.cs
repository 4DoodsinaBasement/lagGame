using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spikes : MonoBehaviour {

    bool SpikeCollision = false;
    private Vector2 collision = new Vector2(1f, 0.2f);
    [SerializeField] private Transform Damage;
    [SerializeField] private LayerMask itsDamage;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckCollision();
        if (SpikeCollision)
        {
            SceneManager.LoadScene("Animation_Scene");
        }
    }
    void CheckCollision()
    {
        SpikeCollision = false;
  


        Collider2D[] colliders1 = Physics2D.OverlapBoxAll(Damage.position, collision, itsDamage);
        for (int i = 0; i < colliders1.Length; i++)
        {
            if (colliders1[i].gameObject != gameObject)
                SpikeCollision = true;
        }
    }
}


