using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

public bool combat = false; 
bool inCombat = false;
int enemy;
int min;
public GameObject ui;
public Canvas canvas;



private static List<Pokemon> roster = new List<Pokemon>();
private static List<Pokemon> wild = new List<Pokemon>();
public Transform combatTF;
public Transform enemypmon;
public Transform pmon;
public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        roster.Add(PokemonFactory.Create(4, "Squirtle"));
        roster.Add(PokemonFactory.Create(4, "Eevee"));
        roster.Add(PokemonFactory.Create(4, "Psyduck"));
        roster.Add(PokemonFactory.Create(4, "Growlithe"));

        wild.Add(PokemonFactory.Create(4,"snorlax"));
        wild.Add(PokemonFactory.Create(4,"oddish"));
        wild.Add(PokemonFactory.Create(4,"dugtrio"));
        wild.Add(PokemonFactory.Create(4,"kakuna"));
    }

    // Update is called once per frame
    void Update()
    {
        if (combat)
        {
            StartBattle();
            player.GetComponent<Movement>().enabled = false;
            combat = false;
        }
        if (inCombat)
        {
        canvas.transform.GetChild(5).GetComponent<Slider>().maxValue = roster[min].maxHp;
        canvas.transform.GetChild(5).GetComponent<Slider>().value = roster[min].hp;

        canvas.transform.GetChild(4).GetComponent<Slider>().maxValue = wild[enemy].maxHp;
        canvas.transform.GetChild(4).GetComponent<Slider>().value = wild[enemy].hp;

        canvas.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = roster[min].name;
        canvas.transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>().text = wild[enemy].name;
        }
    }

    void StartBattle()
    {
        player.transform.position = combatTF.transform.position;
        player.transform.rotation = combatTF.transform.rotation;
        enemy = Random.Range(0,3);
        min = 0;

        Instantiate(Resources.Load(wild[enemy].name),enemypmon.transform.position, enemypmon.transform.rotation, enemypmon);
        Instantiate(Resources.Load(roster[min].name),pmon.transform.position, pmon.transform.rotation, pmon);

        ui.transform.GetChild(0).gameObject.SetActive(true);
        ui.transform.GetChild(3).gameObject.SetActive(true);
        
        ui.transform.GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Figth";
        ui.transform.GetChild(0).GetChild(1).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = "pokemon";
        ui.transform.GetChild(0).GetChild(2).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = "items";
        ui.transform.GetChild(0).GetChild(3).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Run";
        inCombat = true;
       

    }
    public void Battle( )
    {
        ui.transform.GetChild(0).gameObject.SetActive(false);
        ui.transform.GetChild(2).gameObject.SetActive(true);
        
        if (roster[min].moves.Count > 1)
        {
            ui.transform.GetChild(2).GetChild(0).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[min].moves[0].name;
            ui.transform.GetChild(2).GetChild(0).GetChild(1).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[min].moves[1].name;
        }   
        else
        {
            ui.transform.GetChild(2).GetChild(0).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[min].moves[0].name;
        }  

    }
    public void Chosepokemon( )
    {
        for(int i = 0; i < roster.Count; i++)
        {
            ui.transform.GetChild(1).GetChild(i).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = roster[i].name;
        }

        ui.transform.GetChild(0).gameObject.SetActive(false);
        ui.transform.GetChild(1).gameObject.SetActive(true);

        if(pmon.transform.GetChild(0).gameObject != null)
        {
            Destroy(pmon.transform.GetChild(0).gameObject);
        } 
    }
    public void Switch()
    {
        switch (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text)
        {
            case "Squirtle":
                Instantiate(Resources.Load(roster[0].name),pmon.transform.position, pmon.transform.rotation, pmon);
                min = 0;
                break;

            case "Eevee":
                Instantiate(Resources.Load(roster[1].name),pmon.transform.position, pmon.transform.rotation, pmon);
                min = 1;
                break;

            case "Psyduck":
                Instantiate(Resources.Load(roster[2].name),pmon.transform.position, pmon.transform.rotation, pmon);
                min = 2;
                break;

            case "Growlithe":
                Instantiate(Resources.Load(roster[3].name),pmon.transform.position, pmon.transform.rotation, pmon);
                min = 3;
                break;

            default:
                break;
        }

        ui.transform.GetChild(1).gameObject.SetActive(false);
        ui.transform.GetChild(0).gameObject.SetActive(true);
        wild[enemy].Attack(roster[min]);
        if (roster[min].hp <= 0)
            {   
                ui.transform.GetChild(1).GetChild(min).transform.GetComponent<Button>().interactable = false;
                Chosepokemon();
            }
    }

    public void Leave( )
    {
       if(Random.Range(0,10) > 3)
       {
           Endbattle();
       }
       else
       {
           Debug.Log("kan ikke komme væk");
           wild[enemy].Attack(roster[min]);
       }
    }

    public void Atk()
    {
        wild[enemy].Attack(roster[min]);
        roster[min].Attack(wild[enemy]); 
        ui.transform.GetChild(2).gameObject.SetActive(false);
        ui.transform.GetChild(0).gameObject.SetActive(true);
        
        if (roster[min].hp <= 0)
        {   
            ui.transform.GetChild(1).GetChild(min).transform.GetComponent<Button>().interactable = false;
            Chosepokemon();
        }
        if (wild[enemy].hp <= 0)
        {
            Endbattle();
        }
       
    }

    void Endbattle()
    {
        Destroy(pmon.transform.GetChild(0).gameObject);
        Destroy(enemypmon.transform.GetChild(0).gameObject);
        player.GetComponent<Movement>().enabled = true;
        for(int i = 0; i < 4; i++)
        {
            ui.transform.GetChild(i).gameObject.SetActive(false);
        }

        for(int i = 0; i < 4; i++)
        {
            wild[i].Restore();
        }
        for(int i = 0; i < 4; i++)
        {
            roster[i].Restore();
        }
        
    }
}
