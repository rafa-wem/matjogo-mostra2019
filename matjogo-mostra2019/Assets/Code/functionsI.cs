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
            if(x <= 50.0f)
            {
                if(y <= 50.0f)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }

            } else
            {
                if (y <= 50.0f)
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
        if(y >= 2.0f * x)
        {
            return 1;
        }
        else if (y >= x)
        {
            return 2;
        }
        else if (y >= x / 2.0f)
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
        if (Mathf.Sqrt( Mathf.Pow(x - 26.0f, 2.0f) + Mathf.Pow(y - 72.0f, 2.0f) ) <= 17.0f)
        {
            return 3;
        }
        else if (Mathf.Sqrt(Mathf.Pow(x - 70.0f, 2.0f) + Mathf.Pow(y - 30.0f, 2.0f)) <= 24.0f)
        {

        }
        else if (y >= (2.0f * x - 25.0f))
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
    int F14(float x, float y)
    {
        float third = 1.0f / 3.0f;

        float retaF = (-3.0f * x) + 200.0f;
        float retaG = (3.0f * x) - 100.0f;
        float retaH = ((-1.0f * third) * x) + (200.0f * third);
        float retaI = (third * x) + (100.0f * third);
        
        if (y >= retaI && y < retaH)
        {
            return 1;
        }
        else if (y >= retaH && y < retaF)
        {
            return 4;         
        }
        else if (y >= retaF && y >= retaG )
        {
            return 2;
        }
        else if (y < retaG && y >= retaI)
        {
            return 3;
        }
        else if (y < retaI && y >= retaH)
        {
            return 4;
        }
        else if (y < retaH && y >= retaF)
        {
            return 1;
        }
        else if (y < retaF && y < retaG)
        {
            return 3;
        }
        else if (y >= retaG && y < retaI)
        {
            return 2;
        }
    }

}

