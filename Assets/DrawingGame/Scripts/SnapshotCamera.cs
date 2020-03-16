using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SnapshotCamera : MonoBehaviour
{
    int resWidth = 256;
    int resHeight = 256;
    Camera snapCam;
    public GameObject canvas,eraser;
    // Start is called before the first frame update
    void Start()
    {
        snapCam = GetComponent<Camera>();
        if(snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);
    }

    public void CallTakeSnapShot()
    {
        snapCam.gameObject.SetActive(true);
        canvas.SetActive(false);
        eraser.SetActive(false);
    }

    private void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string filename = SnapshotName();
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log("SnapShot Taken");
            snapCam.gameObject.SetActive(false);
            canvas.SetActive(true);
            eraser.SetActive(true);
        }
    }

    string SnapshotName()
    {
        return string.Format("{0}/Snapshots/snap_{1}x{2}_{3}.png",
            Application.dataPath,
            resWidth,
            resHeight,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
            );
    }
}
