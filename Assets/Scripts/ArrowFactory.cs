using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : MonoBehaviour
{   
    public GameObject Build(GameObject arrowPrefab)
    {
        // Instantiate the arrow and set its parent and Player Controller component.
        GameObject gameObj = Instantiate(arrowPrefab, arrowPrefab.transform.position, Quaternion.identity);
        gameObj.transform.parent = gameObject.transform;
        gameObj.GetComponent<NoteObject>().PlayerController = GameObject.Find("Camber").GetComponent<PlayerController>();
        return gameObj;
    }
}
