using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LayerManager : MonoBehaviour
{

    public List<Layer> layers;

    [SerializeField] Texture2D[] startingLayers;

    public Texture2D masterTexture;

    // Start is called before the first frame update
    void Start()
    {
        layers = new List<Layer>();

        foreach(Texture2D layer in startingLayers) {
            CreateLayer(layer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) {
            string list = "[";
            for(int i = 0; i < layers.Count; i++) {
                list += layers[i].texture.name;
                if(i < layers.Count - 1) list += ", ";
            }
            list += "]";
            Debug.Log(list);
        }
    }

    void CreateLayer() {
        Texture2D emptyTexture = new Texture2D(Drawing.resolution, Drawing.resolution);
        emptyTexture.filterMode = FilterMode.Point;
        // I may need to set all pixels to transparent.
        Layer newLayer = new Layer(emptyTexture, layers.Count + 1);
        layers.Add(newLayer);
    }

    void CreateLayer(Texture2D texture) {
        Layer newLayer = new Layer(texture, layers.Count + 1);
        layers.Add(newLayer);
    }
}
