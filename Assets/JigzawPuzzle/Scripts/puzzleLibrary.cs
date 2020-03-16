using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PuzzleLibrary : MonoBehaviour
{

    public enum ImageLibraryType
    {
        art,
        people,
        invention
    };
    public ImageLibraryType imagelibraryType;//So it can understand which library is this one from
    public PuzzleLibItem[] puzzleLibItem;// = new PuzzleLibItem[100]
    public string[] arrayInfo;
    public Texture2D[] images;
    // Start is called before the first frame update


    void Start()
    {
        //generates the library item based on the string array otorged into it
        //puzzleLibItem.Add(new PuzzleLibItem(""));
        


    }

}
