using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 414


public class Dusman : MonoBehaviour
{
    public int DusmanCan = 100;
    int random;

    //public TMPro.TextMeshProUGUI CanTexi;

    public Transform Karakterimiz, RayCastCikisyeri, AlevTopuYeri; 
    public Transform[] noktaDizi = new Transform[2];//hngi noktalar arası git gel yapack
    Transform guncelHedef;

    public float DusmanHizi = 2.5f, AlevTopuHiz = 5, mesafe, uzunluk, YeniScaleDusman = 12;
    float Xscalem, AlevXscalem, XscalemDevriye, YerSolPosX, YerSagPosX;

    Animator Anim;

    bool VuruyorMu, YuruyorMu;
    bool devriyeYapıyorMu;

    public GameObject AlevTopu, kan, DusmanOlumSonrasi;

    Rigidbody2D rbALEV;

    public Slider DusmanCanSlider;

    RaycastHit2D hit;

    void Start()
    {

        devriyeYapıyorMu = false;
        Xscalem = this.transform.localScale.x;
        Anim = this.GetComponent<Animator>();
        XscalemDevriye = (this.transform.localScale.x);
        AlevXscalem = AlevTopu.transform.localScale.x;
        Physics2D.queriesStartInColliders = false;
        if (Karakterimiz.transform.position.x < this.transform.position.x)//solda
        {
            this.transform.localScale = new Vector2(-Mathf.Abs(Xscalem), transform.localScale.y); 
        }
        else//sagda
        {  //
            this.transform.localScale = new Vector2(Mathf.Abs(Xscalem), transform.localScale.y);
            AlevTopu.transform.localScale = new Vector2(1 * Mathf.Abs(AlevXscalem), AlevTopu.transform.localScale.y);
        }


    }
    void Update()
    {    

        uzunluk = Vector2.Distance(this.transform.position, Karakterimiz.position);
        hit = Physics2D.Raycast(RayCastCikisyeri.position, transform.TransformDirection(Vector2.left));
        GorVeKovala();
        DusmanCanSlider.value = DusmanCan;
        DusmanOldu();
       
       

    }
    void DusmanOldu()
    {   //ölmek
        if (DusmanCan == 0)
        {
            Instantiate(DusmanOlumSonrasi, this.transform.position, Quaternion.identity);
            kan.transform.parent = null;
            Destroy(gameObject);
            kan.SetActive(true);
            Destroy(kan, 10f);
        }
    }
    void GorVeKovala()
    {
        if (uzunluk <= 10)
        {
            if (Karakterimiz.transform.position.x < this.transform.position.x)//solda
            {
                hit = Physics2D.Raycast(RayCastCikisyeri.position, transform.TransformDirection(Vector2.left));
            }
            else if (Karakterimiz.transform.position.x > this.transform.position.x)//sagda
            {
                hit = Physics2D.Raycast(RayCastCikisyeri.position, transform.TransformDirection(Vector2.right));
            }
            VuruyorMu = true;
            if (/*hit != null &&*/ hit.collider != null && hit.collider.tag == "Player")
            {
                Anim.SetBool("VuruyorMu", true);
            }
            else
            { 
                Anim.SetBool("VuruyorMu", false);
            }
            DusmanSagaMiSolaMiBakliyor();
            Anim.SetBool("YuruyorMu", false);
            //Anim.SetBool("VuruyorMu", true);
            //Anim.SetBool("YuruyorMu", false);
        }
        else if (uzunluk >= 10)
        {
            VuruyorMu = false;
            Anim.SetBool("VuruyorMu", false);
        }
        if (uzunluk < 20f && uzunluk > 10f)
        {
            YuruyorMu = true;
            VuruyorMu = false;
            this.transform.position = Vector2.MoveTowards(this.transform.position, Karakterimiz.position, DusmanHizi * Time.deltaTime);
            Anim.SetBool("YuruyorMu", true);
            DusmanSagaMiSolaMiBakliyor();
            //if (Karakterimiz.transform.position.x < this.transform.position.x)//solda
            //{
            //    //ben
            //    this.transform.localScale = new Vector2(-Mathf.Abs(Xscalem), transform.localScale.y);
            //    AlevTopu.transform.localScale = new Vector2(-1 * Mathf.Abs(AlevXscalem), AlevTopu.transform.localScale.y);
            //    //yusuf
            //    //this.transform.localScale = new Vector2(-10, 10);
            //    //AlevTopu.transform.localScale = new Vector2(-1, 1);
            //}
            //else//sagda
            //{  //yusuf
            //    //this.transform.localScale = new Vector2(10, 10);
            //    //AlevTopu.transform.localScale = new Vector2(1, 1);
            //    //ben
            //    this.transform.localScale = new Vector2(Mathf.Abs(Xscalem), transform.localScale.y);
            //    AlevTopu.transform.localScale = new Vector2(1 * Mathf.Abs(AlevXscalem), AlevTopu.transform.localScale.y);

            //}
        }
        if (uzunluk > 20)
        {
            devriye();
            Anim.SetBool("YuruyorMu", true);

        }
    }
    void DusmanSagaMiSolaMiBakliyor()
    {
        if (Karakterimiz.transform.position.x < this.transform.position.x)//solda
        {
            Debug.Log("Solda");
            hit = Physics2D.Raycast(RayCastCikisyeri.position, transform.TransformDirection(Vector2.left));
            Debug.DrawLine(RayCastCikisyeri.position, hit.point, Color.blue);
            this.transform.localScale = new Vector2(-Mathf.Abs(Xscalem), transform.localScale.y);
            AlevTopu.transform.localScale = new Vector2(-1 * Mathf.Abs(AlevXscalem), AlevTopu.transform.localScale.y);
        }
        else if (Karakterimiz.transform.position.x > this.transform.position.x)//sagda
        {
            Debug.Log("Sagda");
            hit = Physics2D.Raycast(RayCastCikisyeri.position, transform.TransformDirection(Vector2.right));
            Debug.DrawLine(RayCastCikisyeri.position, hit.point, Color.red);
            this.transform.localScale = new Vector2(Mathf.Abs(Xscalem), transform.localScale.y);
            AlevTopu.transform.localScale = new Vector2(1 * Mathf.Abs(AlevXscalem), AlevTopu.transform.localScale.y);

        }
    }
    void devriye()
    {
        if (!devriyeYapıyorMu)
        {
            devriyeYapıyorMu = true;
            random = Random.Range(0, 2); //1 //sag
            guncelHedef = noktaDizi[random];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, guncelHedef.position, DusmanHizi * Time.deltaTime);
            // SulukDusmanMesafe = Vector2.Distance(transform.position, SulukDusmanGuncelHedef.position);
            mesafe = this.transform.position.x - guncelHedef.position.x;

            if (Mathf.Abs(mesafe) <= 1.5f)
            {
                devriyeYapıyorMu = false;
            }
            if (mesafe < 0)
            {
                transform.localScale = new Vector2(YeniScaleDusman, YeniScaleDusman);
            }
            else
            {
                transform.localScale = new Vector2(-YeniScaleDusman, YeniScaleDusman);
            }


        }
       
    }
    void AlevTopuCikar()
    {
        if (Karakterimiz.transform.position.x < this.transform.position.x)
        {
            if (/*hit != null &&*/ hit.collider != null && hit.collider.tag == "Player")
            {
                rbALEV = Instantiate(AlevTopu, AlevTopuYeri.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                rbALEV.AddForce(Vector2.right * -AlevTopuHiz, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (/*hit != null && */hit.collider != null && hit.collider.tag == "Player")
            {
                rbALEV = Instantiate(AlevTopu, AlevTopuYeri.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                rbALEV.AddForce(Vector2.right * AlevTopuHiz, ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "AKmermi")
        {
            DusmanCan = DusmanCan - 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "AWPmermi")
        {
            DusmanCan = DusmanCan - 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "REVOLVERmermi")
        {
            DusmanCan = DusmanCan - 10;
            Destroy(collision.gameObject);
        }
    }




}