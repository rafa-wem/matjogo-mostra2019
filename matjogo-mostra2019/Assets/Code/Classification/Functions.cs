using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public int function1(float x, float y)
    {
        return 0;
    }

    public int function2(float x, float y)
    {
        return 0;
    }

    public int function3(float x, float y)
    {
        if (y >= x / 2.0f && x <= 50.0f)
        {
            return 1;
        }
        else if (y < x / 2.0f && y < -x / 2.0f + 50.0f)
        {
            return 2;
        }
        else
        {
            return 3;
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
        if(x < 100.0f/3.0f || x > 200.0f/3.0f)
          return 1;
        else return 2;
    }

    public int function6(float x, float y)
    {
        if ((y <= -x / 2.0f && x < 50.0f) || (y <= x / 2.0f + 50.0f && x > 50.0f))
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
        return 0;
    }

    public int function10(float x, float y)
    {
        return 0;
    }

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
            else return 2;
        }
        return 0;
    }

    public int function13(float x, float y)
    {
        RaycastHit info;
        if(Physics.Raycast(new Vector3(x - 100.0f, y - 100.0f, -20.0f), Vector3.forward, out info))
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

    public int function14(float x, float y)
    {
        return 0;
    }
}
