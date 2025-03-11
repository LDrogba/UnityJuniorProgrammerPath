using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] backgroundObjects;
    [SerializeField]
    float speed = 1f;

    float distBetweenBackgrounds;
    // Start is called before the first frame update
    void Start()
    {
        distBetweenBackgrounds = Mathf.Abs(backgroundObjects[0].transform.position.x - backgroundObjects[1].transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject background in backgroundObjects)
        {
            background.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (background.transform.position.x <= -63)
            {
                background.transform.position = new Vector3(background.transform.position.x + distBetweenBackgrounds * 2, background.transform.position.y, background.transform.position.z);
            }
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed; 
    }
}
