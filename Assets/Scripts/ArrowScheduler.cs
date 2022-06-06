using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ArrowScheduler : MonoBehaviour
{
    private Queue q = new Queue();
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject right;
    [SerializeField] private string levelFile;
    [SerializeField] int offset;
    private float songTime = 0;
    private ArrowSpec curSpec;
    private bool moreArrows = true;
    private bool hasStarted = false;
    [SerializeField]
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        // reads in the level
        Object level = Resources.Load<TextAsset>(levelFile);
        string data = level.ToString();
        string[] lines = data.Split('\n');
        foreach (string line in lines)
        {
            string[] parameters = line.Split(' ');
            ArrowSpec specs = new ArrowSpec();
            specs.direction = int.Parse(parameters[0]);
            specs.hitTime = int.Parse(parameters[1]);
            switch(specs.direction) 
            {
                case 0:
                    specs.arrow = this.left;
                    break;
                case 1:
                    specs.arrow = this.down;
                    break;
                case 2:
                    specs.arrow = this.up;
                    break;  
                case 3:
                    specs.arrow = this.right;
                    break; 
            }
            q.Enqueue(specs);
        }
        curSpec = (ArrowSpec)q.Dequeue();
    }

    // Update is called once per frame
    void Update()
    {
        // Stop the game if the player dies.
        if (hasStarted && playerController.PlayerHealthBarController.CurrentValue != 0f) {
            this.songTime += Time.deltaTime * 1000;
            if (songTime >= curSpec.hitTime - offset) 
            {
                if (moreArrows == true) {
                    this.GetComponent<ArrowFactory>().Build(curSpec.arrow);
                    /*
                    var gameObj = Instantiate(curSpec.arrow, curSpec.arrow.transform.position, Quaternion.identity);
                    gameObj.transform.parent = gameObject.transform;
                    gameObj.GetComponent<NoteObject>().PlayerController = GameObject.Find("Camber").GetComponent<PlayerController>();
                    */
                    if (q.Count == 0) 
                    { 
                        moreArrows = false;
                    }
                }
                if (q.Count > 0) 
                { 
                    curSpec = (ArrowSpec)q.Dequeue();
                    // double araoroarws 
                    if (songTime >= curSpec.hitTime - offset)  
                    {
                        this.GetComponent<ArrowFactory>().Build(curSpec.arrow);
                        /*
                        var gameObj = Instantiate(curSpec.arrow, curSpec.arrow.transform.position, Quaternion.identity);
                        gameObj.transform.parent = gameObject.transform;
                        gameObj.GetComponent<NoteObject>().PlayerController = GameObject.Find("Camber").GetComponent<PlayerController>();
                        */
                        if (q.Count == 0) 
                        { 
                            moreArrows = false;
                        }
                        if (q.Count > 0) 
                        {
                            curSpec = (ArrowSpec)q.Dequeue();
                        }
                    }
                }
            }
        }
        else 
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
                this.songTime = 0;
            }
        }
    }
}
