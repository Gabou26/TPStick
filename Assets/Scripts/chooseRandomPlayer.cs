using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseRandomPlayer : MonoBehaviour
{
    private Dictionary<Color,string> listPlayerColor_Name = new Dictionary<Color,string>();
    private Color pink = new Color(1f, 0.3f, 0.5f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        listPlayerColor_Name.Add(pink,"Le Garde du corps");
        listPlayerColor_Name.Add(Color.red,"Le Sumo");
        listPlayerColor_Name.Add(Color.blue,"Le Comique");
        listPlayerColor_Name.Add(Color.green,"L'Avocat");
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach(GameObject go in allObjects){
            if(go.name == "Player(Clone)"){
                Color color = go.GetComponentInChildren<SkinnedMeshRenderer>().material.color;
                if(color == pink){ // La couleur pink n'est pas bien reconnu lors de l'appel de contains key (color)
                    listPlayerColor_Name.Remove(pink);
                }
                if(listPlayerColor_Name.ContainsKey(color)){
                    listPlayerColor_Name.Remove(color);
                } 
            }
        }
        List<Color> keyList = new List<Color>(listPlayerColor_Name.Keys);
        var nbValue = keyList.Count;
        var newColor = keyList[Random.Range(0,nbValue)];
        var newName = listPlayerColor_Name[newColor];
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = newColor;
        GetComponentInChildren<UIHealth>().setPlayerName(newName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
