using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveIkan : MonoBehaviour
{
    //public delegate void onClick();
    //public static event onClick goldPanen;

    GameObject panen;
    GameObject scores;
    GameObject minus;
    GameObject nyawa;
   
    public health healthIkan;
    public float speed;
    private float waitTime;
    public float startWaitTime;
    GameObject movespot;
    private int randomSpot;
    public GameObject notif;
    public Vector3 spotPosition;
    public bool udahBesar;
    public bool clickAble;
    public bool lastclick;
    public GameObject barHealth;

    //public int bangkaiikan = 3;
   

    float temp;


// Start is called before the first frame update
    void Start()
    {
        
        movespot = GameObject.Find("spawnSpotKiri");
        
        
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, movespot.GetComponent<titikGerak>().moveSpot.Length);
        StartCoroutine(timer(10));
        udahBesar = false;
        clickAble = false;
        lastclick = false;
        healthIkan.Initialize(100, 100);

      

    }

    // Update is called once per frame
    void Update()
    {


        if (!udahBesar)
        {
            movespot = GameObject.Find("spawnSpotKiri");
        }
        else
        {
            movespot = GameObject.Find("spawnSpotKanan");
            //StopCoroutine(timerdeder());
            StartCoroutine(timer2(20));
            decrease();
            mati();
        }

        

        transform.position = Vector2.MoveTowards(transform.position, movespot.GetComponent<titikGerak>().moveSpot[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movespot.GetComponent<titikGerak>().moveSpot[randomSpot].position) < 0.2f)
        {

            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, movespot.GetComponent<titikGerak>().moveSpot.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (temp > transform.position.x)
        {
            flipkanan(); 
        }
        else if (temp < transform.position.x)
        {
            flipkiri();
        }
        
    }

    private void LateUpdate()
    {
        temp = transform.position.x;
    }

    void flipkanan()
    {
        this.GetComponent<SpriteRenderer>().flipX = true;
    }

    void flipkiri()
    {
        this.GetComponent<SpriteRenderer>().flipX = false;
    }

    IEnumerator timer(int time)
    {
        yield return new WaitForSeconds(time);
        //StartCoroutine(timerdeder(5));
        jadiBesar();
    }
    IEnumerator timer2(int time)
    {
        yield return new WaitForSeconds(time);
        besarLagi();
        barOff();
    }

    //IEnumerator timerdeder(int time)
    //{
    //    yield return new WaitForSeconds(time);
    //    Destroy(gameObject);
    //    minus = GameObject.Find("ControlShop");
    //    minus.GetComponent<GameControl>().ReduceScore();
    //    nyawa = GameObject.Find("ControlShop");
    //    nyawa.GetComponent<GameControl>().Nyawa();
    //}

    void decrease()
    {
        healthIkan.CurrentValue -= 0.1f;
    }

    public void kenyang()
    {
        healthIkan.CurrentValue += 25f;
    }

    public void sehat()
    {
        healthIkan.CurrentValue += 100f;
    }

    void mati()
    {
        if(healthIkan.CurrentValue == 0)
        {
            Destroy(gameObject);
            minus = GameObject.Find("ControlShop");
            minus.GetComponent<GameControl>().ReduceScore();
            nyawa = GameObject.Find("ControlShop");
            nyawa.GetComponent<GameControl>().Nyawa();
        }
    }

    void jadiBesar()
    {
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        notifOn();
        clickAble = true;
    }

    void besarLagi()
    {
        this.transform.localScale = new Vector3(0.8f, 0.8f, 0);
        notifOn();
        lastclick = true;
    }

    
    void notifOn()
    {
        notif.SetActive(true);
    }

    void notifOff()
    {
        notif.SetActive(false);
    }

    void barOn()
    {
        barHealth.SetActive(true);
    }

    void barOff()
    {
        barHealth.SetActive(false);
    }

   

    private void OnMouseDown()
    {
        if (clickAble) {
            
            udahBesar = true;
            notifOff();
            barOn();
            //coba();
            
        }

        if (lastclick)
        {
            panen = GameObject.Find("ControlShop");
            panen.GetComponent<GameControl>().nambahUang();

            scores = GameObject.Find("ControlShop");
            scores.GetComponent<GameControl>().Score();

            Destroy(gameObject);
        }
    }

    
}
