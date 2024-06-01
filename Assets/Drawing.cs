using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Drawing : MonoBehaviour
{

    [SerializeField] Camera drawingCam;

    Texture2D drawingTexture;

    // Start is called before the first frame update
    void Start()
    {
        int resolution = 64;

        drawingTexture = new Texture2D(resolution, resolution);
        for(int i = 0; i < resolution; i++) {
            for(int j = 0; j < resolution; j++) {
                drawingTexture.SetPixel(i, j, new Color((float)i/resolution, (float)i/resolution, (float)i/resolution));
            }
        }
        drawingTexture.Apply();

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = drawingTexture;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = drawingCam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
    }
}
