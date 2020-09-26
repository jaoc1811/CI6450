using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject beer;

    float timer;

    bool first;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        first = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= Time.time && GameObject.FindGameObjectsWithTag("beer").Length <= 10){
            Dictionary<int, Node> graphNodes = GameObject.Find("basanta").GetComponent<PathFinding>().graph.nodes;
            Vector3 position = graphNodes[Random.Range(0,graphNodes.Count)].center;
            beer.transform.position = position;
            Instantiate(beer);
            if(first){
                for (int i = 0; i < 2; i++){
                    position = graphNodes[Random.Range(0,graphNodes.Count)].center;
                    beer.transform.position = position;
                    Instantiate(beer);
                }
                
                first = false;
            }
            
            timer = Time.time + 3;

        }
    }
}
