using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthTextUpdater : MonoBehaviour
{
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + Health.instance.GetHealth().ToString();
    }
}
