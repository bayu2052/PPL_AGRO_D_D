using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Shop Item
    public Button fishShopButton, pakanShopButton, suplemenShopButton;
    public Text fishPriceText, pakanPricetext, suplemenPriceText;

    // Gold & score
    public Text goldText;
    public Text scoreText;
    public int score, maxScore;

    // Inventory Item
    public Button fishButton, pakanButton, suplemenButton;
    public Text inventFishText, inventPakanText, inventSuplemenText;
    public int invFish, invPakan, invSuplement;

    // Harga & Gold
    public int fishPrice = 50, pakanPrice = 15, suplemenPrice = 30, gold = 500, panen = 100;

    //nyawa
    public Text nyawaText;
    public int nyawa = 3;

    //timer
    public Image timebar;
    public float maxTime = 5f;
    float timeLeft;

    
    public GameObject ikan;
    public GameObject spawnIkan;

    public GameObject health;

    public GameObject Win;
    public GameObject Lose;

    GameObject []lapar;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //timebar = GetComponent<Image>();
        timeLeft = maxTime;
        //StartCoroutine(countdown(300));
        
        // disable button in shop
        fishShopButton.interactable = false;
        pakanShopButton.interactable = false;
        suplemenShopButton.interactable = false;

        //disable button in inventory
        fishButton.interactable = false;
        pakanButton.interactable = false;
        suplemenButton.interactable = false;

        // harganya & Goldnya
        fishPriceText.text = fishPrice.ToString();
        pakanPricetext.text = pakanPrice.ToString();
        suplemenPriceText.text = suplemenPrice.ToString();
        goldText.text = gold.ToString();

        // inventory
        inventFishText.text = invFish.ToString();
        inventPakanText.text = invPakan.ToString();
        inventSuplemenText.text = invSuplement.ToString();

        //score
        scoreText.text = score.ToString();

        //nyawa
        nyawaText.text = nyawa.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timebar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            loser();
        }

        inventFishText.text = "" + invFish;
        inventPakanText.text = "" + invPakan;
        inventSuplemenText.text = "" + invSuplement;

        // gold update
        goldText.text = "= " + gold;

        // score
        scoreText.text = "" + score;

        if (score >= maxScore)
        {
            winner();
        }
        
        if (score <= 0)
        {
            score = 0;
        }

        //nyawa
        nyawaText.text = "= " + nyawa;

        if (nyawa <= 0)
        {
            nyawa = 0;
            loser();
        }

        // Do you have money?
        Buying();
        


    }

    //IEnumerator countdown(int time)
    //{
    //    yield return new WaitForSeconds(time);
    //    loser();
    //}

    public void increaseInventFish()
    {
        invFish += 1;
    }

    public void pendederan()
    {
        invFish -= 1;
        Instantiate(ikan, spawnIkan.transform);
    }

    public void makanin()
    {
        invPakan -= 1;
        Instantiate(health, gameObject.transform);
        //health.GetComponent<moveIkan>().kenyang();
        lapar = GameObject.FindGameObjectsWithTag("ikan");
        //lapar.GetComponent<moveIkan>().kenyang();
        for (int i = 0; i < lapar.Length; i++)
        {
            lapar[i].GetComponent<moveIkan>().kenyang();
        }
    }

    public void sehatin()
    {
        invSuplement -= 1;
        Instantiate(health);
        lapar = GameObject.FindGameObjectsWithTag("ikan");
        for (int i = 0; i < lapar.Length; i++)
        {
            lapar[i].GetComponent<moveIkan>().sehat();
        }
    }

    public void increaseInventPakan()
    {
        invPakan += 1;
    }

    public void increaseInventSuplemen()
    {
        invSuplement += 1;
    }

    public void SellFish()
    {
        fishButton.interactable = true;
        gold -= fishPrice;
    }

    public void SellPakan()
    {
        pakanButton.interactable = true;
        gold -= pakanPrice;
    }

    public void SellSuplemen()
    {
        suplemenButton.interactable = true;
        gold -= suplemenPrice;
    }

    public void nambahUang()
    {
        gold += panen;
        
    }

    public void Score()
    {
        score += 100;
    }

    public void ReduceScore()
    {
        score -= 50;
    }

    public void Nyawa()
    {
        nyawa -= 1;
    }

    public void winner()
    {
        Win.SetActive(true);
        Time.timeScale = 0f;
    }

    public void loser()
    {
        Lose.SetActive(true);
        Time.timeScale = 0f;
    }

    void Buying()
    {
        if (gold < fishPrice)
            fishShopButton.interactable = false;
        if (gold < pakanPrice)
            pakanShopButton.interactable = false;
        if (gold < suplemenPrice)
            suplemenShopButton.interactable = false;

        if (gold >= fishPrice)
        {
            fishShopButton.interactable = true;
        }
        if (gold >= pakanPrice)
        {
            pakanShopButton.interactable = true;
        }
        if (gold >= suplemenPrice)
        {
            suplemenShopButton.interactable = true;
        }

        if (invFish <= 0)
        {
            fishButton.interactable = false;
        }
        if (invPakan <= 0)
        {
            pakanButton.interactable = false;
        }
        if (invSuplement <= 0)
        {
            suplemenButton.interactable = false;
        }
    }    
}
