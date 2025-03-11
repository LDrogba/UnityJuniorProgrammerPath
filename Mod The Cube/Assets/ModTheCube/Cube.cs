using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotationSpeed = 10;
    public Vector3 rotationAngle = Vector3.zero;
    public float scaleSpeed = 10;
    public Vector3 scale = Vector3.one;
    public Vector3 materialColor = Vector3.one * 10;
    public float materialAlpha = 255;

    Material material;


    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(rotationAngle * Time.deltaTime * rotationSpeed);
        transform.localScale += scale * scaleSpeed * Time.deltaTime;

        material.color = new Color(materialColor.x/100, materialColor.y/100, materialColor.z/100, materialAlpha/100);
    }
}
