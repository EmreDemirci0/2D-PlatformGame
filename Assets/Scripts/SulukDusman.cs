
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
#pragma warning disable 414

public class SulukDusman : MonoBehaviour
{
    public int SulukDusmanCan = 100;


    public Transform Karakterimiz; public Transform[] SulukDusmanNoktaDizi = new Transform[2];
    Transform SulukDusmanGuncelHedef;

    int random;

    public float SulukDusmanHizim = 2f, SulukDusmanMesafe, uzunluk, YeniScaleSulukDusman = 2;
    float SulukXscalem, SulukXscalemDevriye, SulukYerSolPosX, SulukYerSagPosX;




    public bool SulukDusmandevriyeYapıyorMu;

    public GameObject SulukKan, SulukDusmanOlumSonrasi;

    Rigidbody2D rbALEV;

    public Slider SulukDusmanCanSlider;



    void Start()
    {
        SulukDusmandevriyeYapıyorMu = false;
        SulukXscalemDevriye = (this.transform.localScale.x);
    }

    // Update is called once per frame
    private void Update()
    {

      //  this.transform.position = Vector2.MoveTowards(this.transform.position, Karakterimiz.position, SulukDusmanHizim * Time.deltaTime);
        uzunluk = Vector2.Distance(this.transform.position, Karakterimiz.position);
        if (uzunluk < 1.5f)
        {
            //Debug.Log("uzunluk 1.5ten ufak");
            // this.transform.position=
        }
        if (uzunluk < 20 && uzunluk>1.5f)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, Karakterimiz.position, SulukDusmanHizim * Time.deltaTime);
            if (Karakterimiz.transform.position.x < this.transform.position.x)//solda
            {
                this.transform.localScale = new Vector2(-Mathf.Abs(SulukXscalemDevriye), transform.localScale.y);
            }
            else
            {
                this.transform.localScale = new Vector2(Mathf.Abs(SulukXscalemDevriye), transform.localScale.y);
            }
        }
       
        else if (uzunluk > 20)
        {
            //devriye();
            devriyemiz();

        }
        SulukDusmanCanSlider.value = SulukDusmanCan;
        DusmanOldu();
        //    Debug.DrawLine(transform.position, SulukDusmanGuncelHedef.position, Color.red);

    }
    void DusmanOldu()
    {   //ölmek
        if (SulukDusmanCan == 0)
        {
            Instantiate(SulukDusmanOlumSonrasi, this.transform.position, Quaternion.identity);
            SulukKan.transform.parent = null;
            Destroy(gameObject);
            SulukKan.SetActive(true);
            Destroy(SulukKan, 10f);
        }
    }
   

    void devriyemiz()
    {

        if (!SulukDusmandevriyeYapıyorMu)
        {
            SulukDusmandevriyeYapıyorMu = true;
            SulukDusmanGuncelHedef = SulukDusmanNoktaDizi[Random.Range(0, 2)];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, SulukDusmanGuncelHedef.position, SulukDusmanHizim * Time.deltaTime);
            SulukDusmanMesafe = transform.position.x - SulukDusmanGuncelHedef.position.x;
            if (Mathf.Abs(SulukDusmanMesafe) <= 1.5f)
            {
                SulukDusmandevriyeYapıyorMu = false;
            }
            if (SulukDusmanMesafe < 0)
            {
                transform.localScale = new Vector2(YeniScaleSulukDusman, YeniScaleSulukDusman);
            }
            else
            {
                transform.localScale = new Vector2(-YeniScaleSulukDusman, YeniScaleSulukDusman);
            }
        }

    }

    // }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "AKmermi")
        {
            SulukDusmanCan = SulukDusmanCan - 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "AWPmermi")
        {
            SulukDusmanCan = SulukDusmanCan - 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "REVOLVERmermi")
        {
            SulukDusmanCan = SulukDusmanCan - 10;
            Destroy(collision.gameObject);
        }
    }



}
