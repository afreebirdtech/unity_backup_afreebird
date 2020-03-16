using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GetImage : MonoBehaviour
{
    string path = string.Format("{0}/Snapshots",Application.dataPath);
    // Start is called before the first frame update

    string txtName = "smile.png";  // your filename
    Vector2 size = new Vector2(256, 256); // image size

    private void Start()
    {
        Texture2D text2d = loadImage(size,path);

    }
    

    private static Texture2D loadImage(Vector2 size, string filePath)
    {

        byte[] bytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
        texture.filterMode = FilterMode.Trilinear;
        texture.LoadImage(bytes);

        return texture;
    }
}
