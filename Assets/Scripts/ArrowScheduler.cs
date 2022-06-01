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
    // Start is called before the first frame update
    void Start()
    {
        // reads in the level
        string file_path = "./Assets/Scripts/Prologlevel.txt";
        StreamReader inp_stm = new StreamReader(file_path);
        while(!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine( );
            Debug.Log(inp_ln);
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
        inp_stm.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (q.Count > 0) 
        { 
            ArrowSpec curSpec;
            curSpec = (ArrowSpec)q.Dequeue();
            var gameObj = Instantiate(curSpec.arrow, curSpec.arrow.transform.position, Quaternion.identity);
            gameObj.transform.parent = gameObject.transform;
            gameObj.GetComponent<NoteObject>().PlayerController = GameObject.Find("Camber").GetComponent<PlayerController>();
        }
    }
}
