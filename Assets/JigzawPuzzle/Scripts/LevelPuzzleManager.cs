using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class LevelPuzzleManager : MonoBehaviour
{

    public RuntimeGeneration runtimeGeneration;
    public int puzzleRows = 3, puzzleCols = 3;
    public Texture2D[] inventionsImageLibrary; //Set the images for the inventions (AllofThem)
    public string[] inventionsInfoLibrary;

    public Texture2D[] peopleImageLibrary; //Set the images for the inventions (AllofThem)
    public string[] peopleInfoLibrary;

    public Texture2D[] artImageLibrary; //Set the images for the inventions (AllofThem)
    public string[] artInfoLibrary;



    public string info;
    public Texture2D image;
    public Text informationText;
    public CameraController cameraController;




    public enum ImageLibraryType
    

    {
        art,
        people,
        invention
    };
    public GameObject infoPanel;

    public ImageLibraryType ImageLibraryTypeToChoose;

    // Start is called before the first frame update
    void Start()
    {

        if(informationText == null)
        {
            informationText = FindObjectOfType<informationTextPuzzle>().GetComponent<Text>();
        }

        if(cameraController == null)
        {
            cameraController = FindObjectOfType<CameraController>().GetComponent < CameraController>();
        }


        if (runtimeGeneration == null)
        {
            runtimeGeneration = FindObjectOfType<RuntimeGeneration>().GetComponent<RuntimeGeneration>();
        }
        GeneratePuzzleOf();
        ToggleInfoPanel();
    }

    private void GeneratePuzzleOf()
    {
        runtimeGeneration.SetCols(puzzleRows);
        runtimeGeneration.SetRows(puzzleCols);
        randomizeLibrary(ImageLibraryTypeToChoose);
        runtimeGeneration.image = image; //Randomize this
        runtimeGeneration.GeneratePuzzle();
    }

    public void ToggleInfoPanel()
    {
        //if is active then deactivate
        if (infoPanel.activeSelf)
        {
            infoPanel.SetActive(false);
            cameraController.disablePanning = false;
            cameraController.disableZooming = false;
        }
        else
        {
            infoPanel.SetActive(true);
            cameraController.disablePanning = true;
            cameraController.disableZooming = true;
        }
    }


    public void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }



public void LoadMainMenu()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("GameGallery");

	}

    private void randomizeLibrary(ImageLibraryType imageLibraryType)
    {
        print(imageLibraryType);
        int randomInt = 0;
        switch (imageLibraryType)
        {
            case ImageLibraryType.invention:
                print("Working with inventions");
                randomInt = Random.Range(0, inventionsImageLibrary.Length - 1);
                selectImageFrom(inventionsImageLibrary, randomInt);
                selectTextFrom(inventionsInfoLibrary, randomInt);
                break;
            case ImageLibraryType.people:
                print("Working with People");
                randomInt = Random.Range(0, peopleImageLibrary.Length - 1);
                selectImageFrom(peopleImageLibrary, randomInt);
                selectTextFrom(peopleInfoLibrary, randomInt);
                break;

            case ImageLibraryType.art:
                print("Working with Art");
                randomInt = Random.Range(0, artImageLibrary.Length - 1);
                selectImageFrom(artImageLibrary, randomInt);
                selectTextFrom(artInfoLibrary , randomInt);
                break;
       
        }
    }

    private void selectImageFrom(Texture2D[] library,int index)
    {
        
        image = library[index];
        

    }

    private void selectTextFrom(string[] library,int index)
    {
        info = library[index];
        updateText();
    }

    void updateText()
    {
        informationText.text = info;
    }




}
