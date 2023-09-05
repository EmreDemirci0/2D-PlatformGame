using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 414

public class SiyahDusman : MonoBehaviour
{
    public int SiyahDusmanCan = 100;
    int random;

    //public TMPro.TextMeshProUGUI CanTexi;

    public Transform Karakterimiz,AtmaYeri,cikisyeri,cikisyeriSiyah, SiyahAlevTopuYeri; public Transform[] SiyahDusmanNoktaDizi = new Transform[2];//hngi noktalar arası git gel yapack
    Transform SiyahDusmanGuncelHedef;

    public float SiyahDusmanHizi = 2.5f, SiyahDusmanAlevTopuHiz = 5, SiyahDusmanMesafe, siyahDusmanUzunluk, YeniScaleSiyahDusman=1.8f;//
    float SiyahDusmanXscalem, SiyahDusmanAlevXscalem, SiyahDusmanXscalemDevriye, SiyahDusmanYerSolPosX, SiyahDusmanYerSagPosX;

    Animator SiyahDusmanAnim;

    bool SiyahDusmanVuruyorMu, SiyahDusmanYuruyorMu;
    bool SiyahDusmanDevriyeYapıyorMu;

    public GameObject SiyahDusmanAlevTopu, SiyahDusmanKan, SiyahDusmanOlumSonrasi;

    Rigidbody2D SiyahDusman_rbALEV;

    public Slider SiyahDusmanCanSlider;

    RaycastHit2D hit;

    public LayerMask lm;

    SpriteRenderer siyahDusmanSpriteRendereri;

    void Start()
    {

        SiyahDusmanDevriyeYapıyorMu = false;
        SiyahDusmanXscalem = this.transform.localScale.x;
        SiyahDusmanAnim = this.GetComponent<Animator>();
        SiyahDusmanXscalemDevriye = (this.transform.localScale.x);
        SiyahDusmanAlevXscalem = SiyahDusmanAlevTopu.transform.localScale.x;
        Physics2D.queriesStartInColliders = false;
        siyahDusmanSpriteRendereri = GetComponent<SpriteRenderer>();
        ////////////////////////////////////////////////////////////////////////////////////////////////



    }
    private void Update()
    {       
        siyahDusmanUzunluk = Vector2.Distance(this.transform.position, Karakterimiz.position);
        // hit = Physics2D.Linecast(cikisyeriSiyah.position,cikisyeri.position, lm);
        hit = Physics2D.Raycast(cikisyeriSiyah.position,transform.TransformDirection( Vector2.left));

        GorVeKovala();
        SiyahDusmanCanSlider.value = SiyahDusmanCan;
        DusmanOldu();


    }
   
    void DusmanOldu()
    {   //ölmek
        if (SiyahDusmanCan == 0)
        {
            Instantiate(SiyahDusmanOlumSonrasi, this.transform.position, Quaternion.identity);
            SiyahDusmanKan.transform.parent = null;
            Destroy(gameObject);
            SiyahDusmanKan.SetActive(true);
            Destroy(SiyahDusmanKan, 10f);
        }
    }
    void GorVeKovala()
    {
        if (siyahDusmanUzunluk <= 10 )
        {
            if (Karakterimiz.transform.position.x < this.transform.position.x)//solda
            {   
                hit = Physics2D.Raycast(cikisyeriSiyah.position, transform.TransformDirection(Vector2.left));
            }
            else if (Karakterimiz.transform.position.x > this.transform.position.x)//sagda
            { 
                hit = Physics2D.Raycast(cikisyeriSiyah.position, transform.TransformDirection(Vector2.right));
            }

            SiyahDusmanVuruyorMu = true;
            if (/*hit != null && */hit.collider != null && hit.collider.tag == "Player")
            { 
                SiyahDusmanAnim.SetBool("SiyahDusmanVuruyorMu", true);
            }
             else
            {
           
            SiyahDusmanAnim.SetBool("SiyahDusmanVuruyorMu", false);
            }
             DusmanSagaMiSolaMiBakliyor();
            SiyahDusmanAnim.SetBool("SiyahDusmanYuruyorMu", false);
        }
        else if (siyahDusmanUzunluk >= 10)
        {
            SiyahDusmanVuruyorMu = false;
          //  SiyahDusmanAnim.SetBool("SiyahDusmanVuruyorMu", false);
        }
        if (siyahDusmanUzunluk < 20f && siyahDusmanUzunluk > 10f)
        {
            SiyahDusmanYuruyorMu = true;
            SiyahDusmanVuruyorMu=false;
            this.transform.position = Vector2.MoveTowards(this.transform.position, Karakterimiz.position, SiyahDusmanHizi * Time.deltaTime);
            SiyahDusmanAnim.SetBool("SiyahDusmanYuruyorMu", true);
            DusmanSagaMiSolaMiBakliyor();
        }
        if (siyahDusmanUzunluk > 20)
        {
            devriye();
            SiyahDusmanAnim.SetBool("SiyahDusmanYuruyorMu", true);

        }
    }
    void  DusmanSagaMiSolaMiBakliyor()
    {
        if (Karakterimiz.transform.position.x < this.transform.position.x)//solda
        {
            Debug.Log("Solda");
            hit = Physics2D.Raycast(cikisyeriSiyah.position, transform.TransformDirection(Vector2.left));
            Debug.DrawLine(cikisyeriSiyah.position, hit.point, Color.blue);
            this.transform.localScale = new Vector2(-Mathf.Abs(SiyahDusmanXscalem), transform.localScale.y);
            SiyahDusmanAlevTopu.transform.localScale = new Vector2(-1 * Mathf.Abs(SiyahDusmanAlevXscalem), SiyahDusmanAlevTopu.transform.localScale.y);
        }
        else if (Karakterimiz.transform.position.x > this.transform.position.x)//sagda
        {
            Debug.Log("Sagda");
            hit = Physics2D.Raycast(cikisyeriSiyah.position, transform.TransformDirection(Vector2.right));
            Debug.DrawLine(cikisyeriSiyah.position, hit.point, Color.red);
            this.transform.localScale = new Vector2(Mathf.Abs(SiyahDusmanXscalem), transform.localScale.y);
           SiyahDusmanAlevTopu.transform.localScale = new Vector2(1 * Mathf.Abs(SiyahDusmanAlevXscalem), SiyahDusmanAlevTopu.transform.localScale.y);

        }
    }
    void devriye()
    {
        if (!SiyahDusmanDevriyeYapıyorMu)
        {
            SiyahDusmanDevriyeYapıyorMu = true;
            random = Random.Range(0, 2); //1 //sag
            SiyahDusmanGuncelHedef = SiyahDusmanNoktaDizi[random];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, SiyahDusmanGuncelHedef.position, SiyahDusmanHizi * Time.deltaTime);
            // SulukDusmanMesafe = Vector2.Distance(transform.position, SulukDusmanGuncelHedef.position);
            SiyahDusmanMesafe = this.transform.position.x - SiyahDusmanGuncelHedef.position.x;

            if (Mathf.Abs(SiyahDusmanMesafe) <= 1.5f)
            {
                SiyahDusmanDevriyeYapıyorMu = false;
            }
            if (SiyahDusmanMesafe < 0)
            {
                transform.localScale = new Vector2(YeniScaleSiyahDusman, YeniScaleSiyahDusman);
            }
            else
            {
                transform.localScale = new Vector2(-YeniScaleSiyahDusman, YeniScaleSiyahDusman);
            }


        }
    }
    void AlevTopuCikar()
    {
        if (Karakterimiz.transform.position.x < this.transform.position.x)
        {
            if (/*hit != null &&*/ hit.collider != null && hit.collider.tag == "Player")
            {
                SiyahDusman_rbALEV = Instantiate(SiyahDusmanAlevTopu, SiyahAlevTopuYeri.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                SiyahDusman_rbALEV.AddForce(Vector2.right * -SiyahDusmanAlevTopuHiz, ForceMode2D.Impulse);
            }

        }
        else
        {
            if (/*hit != null &&*/ hit.collider != null && hit.collider.tag == "Player")
            {
                SiyahDusman_rbALEV = Instantiate(SiyahDusmanAlevTopu, SiyahAlevTopuYeri.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            SiyahDusman_rbALEV.AddForce(Vector2.right * SiyahDusmanAlevTopuHiz, ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "AKmermi")
        {
            SiyahDusmanCan = SiyahDusmanCan - 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "AWPmermi")
        {
            SiyahDusmanCan = SiyahDusmanCan - 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "REVOLVERmermi")
        {
            SiyahDusmanCan = SiyahDusmanCan - 10;
            Destroy(collision.gameObject);
        }
    }



}
