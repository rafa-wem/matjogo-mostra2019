using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public int killCount = 0;
    public float timeAlive = 0;

    public float visionRange;

    public float moveSpeed;

    public float fireRate;
    public float fireBulletSpeed;
    public float fireDamage;
    public float fireDuration;

    public Color color;

    public float chaseEnemy;        //Bloodlust
    public float dodgeBullet;       //Cowardice
    public float randomShoot;       //Madness
    public float randomMove;        //Wandering

    private bool _myIsInitialized = false;
    private bool _myCanShoot = true;
    private Collider[] _myObjectsNearMe;

    private Vector3 _myMovingDirection;
    private Vector3 _myDodgingDirection;

    private CharacterController _myCharacterController;
    private CF_GameController _myGameController;

    // Start is called before the first frame update
    void Start()
    {
        _myCharacterController = gameObject.GetComponent<CharacterController>();
        _myGameController = GameObject.FindObjectOfType<CF_GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_myIsInitialized)
        {
            _myObjectsNearMe = Physics.OverlapSphere(gameObject.transform.position, visionRange);

            Vector3 p1, p2;
            for (int i = 0; i < _myObjectsNearMe.Length; i++)
            {
                p1 = _myObjectsNearMe[i].transform.position - gameObject.transform.position;
                __myReadEnemy(_myObjectsNearMe[i].GetComponent<Agent>(), p1, Random.Range(0.0f, 1.0f));
                __myReadBullet(_myObjectsNearMe[i].GetComponent<Bullet>(), p1, Random.Range(0.0f, 1.0f));
            }

            __myMove(Random.Range(0.0f, 1.0f));
            __myShoot(Random.Range(0.0f, 1.0f));

            _myMovingDirection = Vector3.zero;
        }
    }

    private void __myReadEnemy(Agent e, Vector3 direction, float behaveDecision)
    {
        if (e == null) return;
        if (direction.magnitude == 0) return;

        int s = behaveDecision <= chaseEnemy ? 1 : -1;
        _myMovingDirection = _myMovingDirection + (s * direction);
    }

    private void __myReadBullet(Bullet e, Vector3 direction, float behaveDecision)
    {
        if (e == null) return;
        float angle = Vector3.Angle(direction, e.direction);
        angle = angle * Mathf.Deg2Rad;
        if (Mathf.Abs(Mathf.Cos(angle)+1) < 0.01f)
        {
            if(behaveDecision <= dodgeBullet)
            {
                _myDodgingDirection.x += e.direction.y;
                _myDodgingDirection.y += -e.direction.x;
                _myDodgingDirection.z = 0.0f;
            }
        }

        int s = behaveDecision <= chaseEnemy ? 1 : -1;
        _myMovingDirection = _myMovingDirection + (s * direction);
    }

    private void __myMove(float behaveDecision)
    {
        Vector3 p = Vector3.zero;
        if (behaveDecision <= randomMove)
            p = Random.insideUnitCircle;

        p = (_myMovingDirection + _myDodgingDirection + p).normalized;
        p.z = 0.0f;
        _myCharacterController.Move(p * moveSpeed * Time.deltaTime);
    }

    private void __myShoot(float behaveDecision)
    {
        if(_myMovingDirection.magnitude > 0)
        {
            Shoot(_myMovingDirection);
        }
        else if(behaveDecision <= randomShoot)
        {
            Shoot(Random.insideUnitCircle);
        }
    }

    private void __myRefreshShoot()
    {
        _myCanShoot = true;
    }

    public void Initialize(float visionRange, float moveSpeed, float fireRate, float fireBulletSpeed, float fireDamage, float fireDuration, float r, float g, float b, float chaseEnemy, float dodgeBullet, float randomShoot, float randomMove)
    {
        this.visionRange = visionRange;
        this.moveSpeed = moveSpeed;
        this.fireRate = fireRate;
        this.fireDuration = fireDuration;
        this.fireBulletSpeed = fireBulletSpeed;
        this.fireDamage = fireDamage;
        this.color = new Color(r, g, b);
        this.chaseEnemy = chaseEnemy;
        this.dodgeBullet = dodgeBullet;
        this.randomShoot = randomShoot;
        this.randomMove = randomMove;

        this.GetComponent<UnityEngine.UI.Image>().color = this.color;
        _myIsInitialized = true;
        _myCanShoot = false;
        Invoke("__myRefreshShoot", fireRate);
    }

    public void Shoot(Vector3 direction)
    {
        if (_myCanShoot)
        {
            direction.Normalize();
            GameObject go = GameObject.Instantiate(_myGameController.bullet, transform.position + direction * 5.0f, Quaternion.identity);
            _myGameController.SetVisible(go);
            go.GetComponent<Bullet>().Initialize(this, direction, fireBulletSpeed, fireDamage, fireDuration);
            _myCanShoot = false;
            Invoke("__myRefreshShoot", fireRate);
        }
    }

    public void GetKill()
    {
        killCount++;
    }

    public void GetKilled()
    {
        timeAlive = _myGameController.SampleDied();
        this.gameObject.SetActive(false);
    }

}

