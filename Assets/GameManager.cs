using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

public bool combat = false; 
int enemy;
public GameObject ui;

private static List<Pokemon> roster = new List<Pokemon>();
private static List<Pokemon> wild = new List<Pokemon>();
public static List<GameObject> model = new List<GameObject>();
public GameObject pokemon0;
public GameObject pokemon1;
public GameObject pokemon2;
public GameObject pokemon3;
public GameObject pokemon4;
public GameObject pokemon5;
public GameObject pokemon6;
public GameObject pokemon7;
public Transform combatTF;
public Transform lastPosition;
public Transform enemypmon;
public Transform pmon;
public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        roster.Add(PokemonFactory.Create(7, "Squirtle"));
        roster.Add(PokemonFactory.Create(8, "Eevee"));
        roster.Add(PokemonFactory.Create(5, "Psyduck"));
        roster.Add(PokemonFactory.Create(10, "Growlithe"));

        wild.Add(PokemonFactory.Create(4,"snorlax"));
        wild.Add(PokemonFactory.Create(4,"oddish"));
        wild.Add(PokemonFactory.Create(4,"kakuna"));
        wild.Add(PokemonFactory.Create(4,"dugtrio"));

        model.Add(pokemon0);
        model.Add(pokemon1);
        model.Add(pokemon2);
        model.Add(pokemon3);
        
        ui.transform.GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[0].name;
        ui.transform.GetChild(0).GetChild(1).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[1].name;
        ui.transform.GetChild(0).GetChild(2).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[2].name;
        ui.transform.GetChild(0).GetChild(3).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[3].name;


    }

    // Update is called once per frame
    void Update()
    {
        if (combat)
        {
            StartBattle();
            player.GetComponent<Movement>().enabled = !player.GetComponent<Movement>().enabled;
            combat = false;
        }
    }

    void StartBattle()
    {
        lastPosition.transform.position = player.transform.position;
        lastPosition.transform.rotation = player.transform.rotation;

        player.transform.position = combatTF.transform.position;
        player.transform.rotation = combatTF.transform.rotation;
        int enemy = Random.Range(0,3);

        Instantiate(model[enemy],enemypmon.transform.position, enemypmon.transform.rotation);
    }
    public void Chosepokemon( )
    {
        for(int i = 0; i<roster.Count; i++)
        {
            if(ui.transform.GetChild(0).GetChild(i).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text == roster[i].name)
            {

            }
        }
    }

    void Attack()
    {

    }

    void EnemyBattle()
    {

    }

    void Leave()
    {

    }


}
