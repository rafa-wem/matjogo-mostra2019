using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionsI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Quatro quadrantes
    int F1(float x, float y)
    {
            if(x <= 50)
            {
                if(y <= 50)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }

            } else
            {
                if (y <= 50)
                {
                    return 4;
                }
                else
                {
                    return 2;
                }
            }
    }
    // Função y = x
    int F2(float x, float y)
    {
        if (y >= x)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
    // funções y = x, y = 2x, y = 1/2x
    int F9(float x, float y)
    {
        if(y >= 2 * x)
        {
            return 1;
        }
        else if (y >= x)
        {
            return 2;
        }
        else if (y >= x / 2)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }

    // funções y = 2x-25
    int F10(float x, float y)
    {
        if (y >= 2 * x - 25)
        {

        }
        else
        {

        }
    }

}
