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
    private Vector3 _myShootingDirection;

    private System.Action<Vector3> _myReadBulletDirection;
    private System.Action<Vector3> _myReadEnemyDirection;

    private System.Action _myShoot;
    private System.Action _myMove;

    private CharacterController _myCharacterController;
    private CF_GameController _myGameController;

    // Start is called before the first frame update
    void Start()
    {
        _myCharacterController = gameObject.GetComponent<CharacterController>();
        _myGameController = GameObject.FindObjectOfType<CF_GameController>();
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
                p2 = _myObjectsNearMe[i].transform.forward;
                __myReadEnemy(_myObjectsNearMe[i].GetComponent<Agent>(), p1, Random.Range(0.0f, 1.0f));
            }

            __myMove(Random.Range(0.0f, 1.0f));
            __myRandomShoot(Random.Range(0.0f, 1.0f));

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

    private void __myMove(float behaveDecision)
    {
        Vector3 p = Vector3.zero;
        if (behaveDecision <= randomMove)
            p = Random.insideUnitCircle;

        _myMovingDirection = _myMovingDirection + p;

        _myCharacterController.Move(_myMovingDirection.normalized * moveSpeed * Time.deltaTime);
    }

    private void __myRandomShoot(float behaveDecision)
    {
        if(behaveDecision <= randomShoot)
        {
            Shoot(Random.insideUnitCircle);
        }
    }

    private void __myRefreshShoot()
    {
        _myCanShoot = true;
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


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Bullet b = hit.gameObject.GetComponent<Bullet>();
        if ((b != null) && (b.owner.name != name))
        {
            b.owner.killCount++;
            timeAlive = _myGameController.SampleDied();
            GameObject.Destroy(b.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}

