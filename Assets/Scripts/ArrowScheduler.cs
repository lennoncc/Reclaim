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
        // TextAsset file_path = new TextAsset();
        Object file_path = Resources.Load<TextAsset>(levelFile);
        // Debug.Log(file_path);
        string input = file_path.ToString();
        // Debug.Log(file_path);
        // string file_path = "./Assets/Resources/Prologlevel.txt";
        // StreamReader inp_stm = new StreamReader(file_path);
        // var input = ""
        string[] inp_stm = input.Split('\n');
        foreach (string inp_ln in inp_stm)
        {
            // string inp_ln = inp_stm.ReadLine( );
            string[] parameters = inp_ln.Split(' ');
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
        // inp_stm.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted && playerController.PlayerHealthBarController.CurrentValue != 0f) {
            this.songTime += Time.deltaTime * 1000;
            if (songTime >= curSpec.hitTime - offset) 
            {
                if (moreArrows == true) {
                    var gameObj = Instantiate(curSpec.arrow, curSpec.arrow.transform.position, Quaternion.identity);
                    gameObj.transform.parent = gameObject.transform;
                    gameObj.GetComponent<NoteObject>().PlayerController = GameObject.Find("Camber").GetComponent<PlayerController>();
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
                        var gameObj = Instantiate(curSpec.arrow, curSpec.arrow.transform.position, Quaternion.identity);
                        gameObj.transform.parent = gameObject.transform;
                        gameObj.GetComponent<NoteObject>().PlayerController = GameObject.Find("Camber").GetComponent<PlayerController>();
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
