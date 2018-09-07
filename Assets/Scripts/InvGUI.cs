using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvGUI : MonoBehaviour {
    bool active;
    GameObject inventory;
    // Use this for initialization
    void Start() {
        active = false;
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Update is called once per frame
    void Update() {
        checkInvPress();
    }

    void checkInvPress()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            print(active);
            if (!active)
            {
                inventory.gameObject.SetActive(true);
                active = true;
            }
            else
            {
                inventory.gameObject.SetActive(false);
                active = false;
            }
        }
    }
}
