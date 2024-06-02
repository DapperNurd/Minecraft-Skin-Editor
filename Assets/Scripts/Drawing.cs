using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.PlayerSettings;

public class Drawing : MonoBehaviour
{
    Camera drawingCam;

    Texture2D drawingTexture;
    [SerializeField] Texture2D baseTexture;

    [SerializeField] GameObject model;

    int resolution = 64; // This should not be changed

    Color drawingColor;

    // Start is called before the first frame update
    void Start()
    {
        drawingCam = FindObjectOfType<CameraController>().drawingCam;

        drawingTexture = new Texture2D(resolution, resolution);
        drawingTexture.filterMode = FilterMode.Point;

        Renderer renderer = model.GetComponent<Renderer>();
        renderer.material.mainTexture = drawingTexture;

        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.mainTexture = drawingTexture;

        if (baseTexture != null) {
            drawingTexture.SetPixels(baseTexture.GetPixels());
            drawingTexture.Apply();
        }

        drawingColor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = drawingCam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out RaycastHit hit, 100)) {
            Vector2Int pos = Vector2Int.RoundToInt(new Vector2(hit.point.x / 10, hit.point.y / 10) * resolution);
            UpdateTexture(pos.x, pos.y, drawingColor);
        }
    }

    private void UpdateTexture(int x, int y, Color color) {
        drawingTexture.SetPixel(x, y, color);
        drawingTexture.Apply();
    }
}
