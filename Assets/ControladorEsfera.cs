using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEsfera : MonoBehaviour {

    public float speed;
    public Text text;
    public Text winText;

    private int count;
    
    void Start()
    {
        count = 0;
        text.text = "Puntos: 0";
        winText.text = "";
    }

	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        GetComponent<Rigidbody>().AddForce(direction * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickup")
        {
            Destroy(other.gameObject);

            UpdateCounter();
        }
    }

    void UpdateCounter()
    {
        text.text = "Puntos: " + ++count;

        int numPickups = GameObject.FindGameObjectsWithTag("pickup").Length;

        if(numPickups == 1)
        {
            winText.text = "Has ganado!";
        }
    }

}
