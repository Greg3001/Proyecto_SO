using System;
using Ataque;
using Defensa;

public class Controles
{
    //Constructor

    public bool Arriba { get; set; }
    public bool Abajo { get; set; }
    public bool Derecha { get; set; }
    public bool Izquierda { get; set; }

    public bool Ataque { get; set; }
    public bool Defensa { get; set; }

    public float Vida { get; set; }
    public float Energia { get; set; }


    public Controles()
    {
        Arriba = false;
        Abajo = false;
        Derecha = false;
        Izquierda = false;

        Ataque = false;
        Defensa = false;

        Vida = 100;
        Energia = 0;
    }

    //Definimos las teclas de los controles
    public void Update(KeyCode key)
    {
        if (key == KeyCode.W)
        {
            Arriba = true;
        }
        else if (key == KeyCode.S)
        {
            Abajo = true;
        }
        else if (key == KeyCode.D)
        {
            Derecha = true;
        }
        else if (key == KeyCode.A)
        {
            Izquierda = true;
        }

        else if (key == KeyCode.J)
        {
            Ataque = true;
        }
        else if (key == KeyCode.K)
        {
            Defensa = true;
        }
    }

    //Reseteo 
    public void Reset()
    {
        Arriba = false;
        Abajo = false;
        Derecha = false;
        Izquierda = false;

        Ataque = false;
        Defensa = false;
    }
}
}

