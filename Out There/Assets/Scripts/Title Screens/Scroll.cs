using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scroll : MonoBehaviour
{
    // Update is called once per frame
    public float scrollSpeed = 15;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 loclVectorUp = transform.TransformDirection(0, 1, 0);
        pos += loclVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title Screen");
        }
    }
}
