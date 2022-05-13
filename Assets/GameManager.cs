using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
public Pokemon pokemon1;
public Pokemon pokemon2;
public Pokemon pokemon3;
public Pokemon pokemon4;


    // Start is called before the first frame update
    void Start()
    {
        pokemon1 = PokemonFactory.Create(7, "Squirtle");
        pokemon2 = PokemonFactory.Create(8, "Eevee");
        pokemon3 = PokemonFactory.Create(5, "Psyduck");
        pokemon4 = PokemonFactory.Create(10, "Growlithe");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartBattle()
    {

    }

    void EndBattle()
    {

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
