using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disableaftertime : MonoBehaviour
{
    float timeToDisable = 0.3f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToDisable;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
