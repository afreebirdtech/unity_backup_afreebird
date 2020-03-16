using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferencePlayerController : MonoBehaviour
{
    public LayerMask mask;
    public GameObject circlePrefab;
    public Transform canvas;
    HashSet<GameObject> answers;
    int size = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        answers = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, mask))
            {
                answers.Add(hit.collider.gameObject);
                if(answers.Count > size)
                {
                    print(hit.collider);
                    Instantiate(circlePrefab, Input.mousePosition, Quaternion.identity,canvas);
                    DifferenceGameController.instance.GetScore();
                    size = answers.Count;
                }
            }
        }
        
    }
}
