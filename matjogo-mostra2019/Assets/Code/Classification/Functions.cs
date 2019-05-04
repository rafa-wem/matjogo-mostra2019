using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{

    #region FACEIS

    public int function1(float x, float y)
    {
        if (x <= 50.0f)
        {
            if (y <= 50.0f)
            {
                return 3;
            }
            else
            {
                return 1;
            }

        }
        else
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

    public int function2(float x, float y)
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

    public int function3(float x, float y)
    {
        if (y >= x * 2.0f && x <= 50.0f)
        {
            return 1;
        }
        else if (y >= x * -2.0f + 200.0f && x > 50.0f)
        {
            return 3;
        }
        else
        {
            return 2;
        }
    }

    public int function4(float x, float y)
    {
        if (Mathf.Sqrt(Mathf.Pow(x - 50.0f, 2.0f) + Mathf.Pow(y - 50.0f, 2.0f)) <= 35.0f)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public int function5(float x, float y)
    {
        if (x < 100.0f / 3.0f || x > 200.0f / 3.0f)
            return 1;
        else return 2;
    }

    #endregion

    #region MEDIAS

    public int function6(float x, float y)
    {
        if ((y <= -x * 2.0f + 100.0f && x < 50.0f) || (y <= x * 2.0f - 100.0f && x > 50.0f))
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public int function7(float x, float y)
    {
        if (y > 25.0f * Mathf.Sin(0.1f * x) + 50.0f)
        {
            return 1;
        }
        else return 2;
    }

    public int function8(float x, float y)
    {
        if (y >= 75 || (y >= 25 && y < 50))
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public int function9(float x, float y)
    {
        if (y >= 2.0f * x)
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

    #endregion

    #region DIFICEIS

    public int function11(float x, float y)
    {
        if (((Mathf.Pow(x - 50.0f, 2) / 14.0f) + (Mathf.Pow(y - 50.0f, 2) / 6.0f)) <= 20.0f)
        {
            return 1;
        }
        else if (((Mathf.Pow(x - 50.0f, 2) / 14.0f) + (Mathf.Pow(y - 50.0f, 2) / 6.0f)) <= 80.0f)
        {
            return 2;
        }
        else if (((Mathf.Pow(x - 50.0f, 2) / 14.0f) + (Mathf.Pow(y - 50.0f, 2) / 6.0f)) <= 170.0f)
        {
            return 3;
        }
        else if (((Mathf.Pow(x - 50.0f, 2) / 14.0f) + (Mathf.Pow(y - 50.0f, 2) / 6.0f)) <= 410.0f)
        {
            return 4;
        }
        else
        {
            return 1;
        }
    }

    public int function12(float x, float y)
    {
        RaycastHit info;
        if (Physics.Raycast(new Vector3(x - 300.0f, y - 100.0f, -20.0f), Vector3.forward, out info))
        {
            //Debug.Log(info.collider.gameObject.name);
            if (info.collider.gameObject.name.Contains("C1"))
            {
                return 1;
            }
            else return 4;
        }
        return 0;
    }

    public int function13(float x, float y)
    {
        RaycastHit info;
        if (Physics.Raycast(new Vector3(x - 100.0f, y - 100.0f, -20.0f), Vector3.forward, out info))
        {
            //Debug.Log(info.collider.gameObject.name);
            if (info.collider.gameObject.name.Contains("C1"))
            {
                return 1;
            }
            else return 3;
        }
        return 0;
    }

    #endregion

    #region SUPERDIFICEIS

    public int function10(float x, float y)
    {
        if (Mathf.Sqrt(Mathf.Pow(x - 26.0f, 2.0f) + Mathf.Pow(y - 72.0f, 2.0f)) <= 17.0f)
        {
            return 3;
        }
        else if (Mathf.Sqrt(Mathf.Pow(x - 70.0f, 2.0f) + Mathf.Pow(y - 30.0f, 2.0f)) <= 24.0f)
        {
            return 4;
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

    public int function14(float x, float y)
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
        else if (y >= retaF && y >= retaG)
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
        else// if (y >= retaG && y < retaI)
        {
            return 2;
        }
    }

    #endregion

}
