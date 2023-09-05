using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class karakter : MonoBehaviour
{
    Rigidbody2D rb, rgbAWP, rgbAK, rgbREVOLVER;

    public Transform kursunCikisYeriAWP, kursunCikisYeriAK, kursunCikisYeriREVOLVER, SilahYeri;

    public GameObject AWPkursun, AKkursun, REVOLVERkursun, Kamera, AK47, REVOLVER, AWP;

    public float hiz = 5, mermiHizi = 5, ziplamaHiz = 0, trambolinHiz = 3200, hizi, AWP_AtesEtmeSuresi = 0, AK_AtesEtmeSuresi = 0, REVOLVER_AtesEtmeSuresi = 0;
    float AWPmermiHizi = 0, AKmermiHizi = 0;
    float REVOLVERmermiHizi = 0, xTransformum, hori; public float AlevCanGitmeHizi = 0, SulukCanGitmeHizi = 0;
    public int AKmermiSayisi = 40, REVOLVERmermiSayisi = 20, AWPmermiSayisi = 10;

    public int yanmaSayaci = 0;

    public Slider KarakterCanSlider;
    public int silah = 0, KarakterCan = 100;

    Animator anim;

    bool ZipliyorMu = false/*, AWPelimdeMi = false, AKelimdeMi = false, REVOLVERelimdeMi = false*//*, DahaOnceGirdiMi = false*/; 
    public bool AWPvarMi, REVOLVERvarMi, AKvarMi;

    Vector3 kameraIlkPos, kameraSonPos;
    //Vector2 vektor1, vektor2;
    SpriteRenderer KarakterSpriteRendereri;

    public TMPro.TextMeshProUGUI AKmermiSayisiTexti, AWPmermiSayisiTexti, REVOLVERmermiSayisiTexti, MermiBittiTexti;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        kameraIlkPos = Kamera.transform.position - this.transform.position;
        KarakterSpriteRendereri = GetComponent<SpriteRenderer>();
    }
    private void LateUpdate()
    {
        KameraKontrol();
    }

    IEnumerator AlevTemas()
    {
        //KarakterSpriteRendereri.color = new Color(255, 0, 0);
        KarakterCan -= 10;
        KarakterSpriteRendereri.color = Color.red;
        rb.AddForce(Vector2.up * 700);
        yield return new WaitForSeconds(1f);
        KarakterSpriteRendereri.color = Color.white;

    }
    void Update()
    {
      //  Debug.Log(Time.deltaTime);
        hareket();
        KarakterCanSlider.value = KarakterCan;
       // AtesEtme();

    }
    void KameraKontrol()
    {
        kameraSonPos = kameraIlkPos + this.transform.position;
        Kamera.transform.position = Vector3.Lerp(kameraIlkPos, kameraSonPos, 3f);
    }
    void hareket()
    {
       // hori = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(hori * hiz, rb.velocity.y);
        xTransformum = transform.localScale.x;

        //if (Input.GetKeyDown(KeyCode.Space) && ZipliyorMu == false)
        //{
        //    rb.AddForce(new Vector2(0, ziplamaHiz));
        //    if (!AWPvarMi && !AKvarMi && !REVOLVERvarMi)
        //    {
        //        anim.SetBool("zipliyorMu", true);
        //    }
            

        //    ZipliyorMu = true;
        //}
        //else
        //{
        //    if (!AWPvarMi && !AKvarMi && !REVOLVERvarMi)
        //    {
        //        anim.SetBool("zipliyorMu", false);
        //    }
          

        //}


        if (hori < 0)
        {
            hizi = mermiHizi * -1;
            if (xTransformum < 0)
            {
                transform.localScale = new Vector2(-xTransformum, transform.localScale.y);
                AWPkursun.transform.localScale = new Vector2(-1 * Mathf.Abs(AWPkursun.transform.localScale.x), AWPkursun.transform.localScale.y);
                AKkursun.transform.localScale = new Vector2(-1 * Mathf.Abs(AKkursun.transform.localScale.x), AKkursun.transform.localScale.y);
                REVOLVERkursun.transform.localScale = new Vector2(-1 * Mathf.Abs(REVOLVERkursun.transform.localScale.x), REVOLVERkursun.transform.localScale.y);
            }

        }
        else if (hori > 0)
        {
            if (xTransformum > 0)
            {
                transform.localScale = new Vector2(-xTransformum, transform.localScale.y);
                AWPkursun.transform.localScale = new Vector2(+1 * Mathf.Abs(AWPkursun.transform.localScale.x), AWPkursun.transform.localScale.y);
                AKkursun.transform.localScale = new Vector2(+1 * Mathf.Abs(AKkursun.transform.localScale.x), AKkursun.transform.localScale.y);
                REVOLVERkursun.transform.localScale = new Vector2(+1 * Mathf.Abs(REVOLVERkursun.transform.localScale.x), REVOLVERkursun.transform.localScale.y);
            }

            hizi = mermiHizi;

        }
        if (hori != 0)
        {
            anim.SetBool("yuruyorMu", true);
        }
        else
        {
            anim.SetBool("yuruyorMu", false);
        }

    }
    //void AtesEtme()
    //{
    //    //AWP
    //    AWPmermiHizi += Time.deltaTime;
    //    if (Input.GetMouseButtonDown(0) && AWPmermiHizi > AWP_AtesEtmeSuresi && silah == 1)
    //    {
    //        if (AWPmermiSayisi > 0)
    //        {
    //            AWPmermiSayisi--;
    //            rgbAWP = Instantiate(AWPkursun, kursunCikisYeriAWP.position, Quaternion.identity).GetComponent<Rigidbody2D>();
    //            rgbAWP.AddForce(Vector2.right * hizi, ForceMode2D.Impulse);
    //            AWPmermiSayisiTexti.text = AWPmermiSayisi.ToString();
    //        }
    //        if (AWPmermiSayisi <= 0 && AWPvarMi)
    //        {
    //            MermiBittiTexti.text = "Mermi Bitti";
    //        }

    //        AWPmermiHizi = 0;
    //    }
    //    //if (Input.GetKeyDown(KeyCode.E))
    //    //{
    //    //    AWPelimdeMi = true;
    //    //}
    //    //if (Input.GetKeyUp(KeyCode.E))
    //    //{
    //    //    AWPelimdeMi = false;
    //    //}

    //    //KELEŞ
    //    AKmermiHizi += Time.deltaTime;
    //    if (Input.GetMouseButton(0) && AKmermiHizi > AK_AtesEtmeSuresi && silah == 2)
    //    {
    //        if (AKmermiSayisi > 0)
    //        {
    //            AKmermiSayisi--;
    //            rgbAK = Instantiate(AKkursun, kursunCikisYeriAK.position, Quaternion.identity).GetComponent<Rigidbody2D>();
    //            rgbAK.AddForce(Vector2.right * hizi, ForceMode2D.Impulse);
    //            AKmermiSayisiTexti.text = AKmermiSayisi.ToString();
    //        }
    //        if (AKmermiSayisi <= 0 && AKvarMi)
    //        {
    //            MermiBittiTexti.text = "Mermi Bitti";
    //        }
    //        AKmermiHizi = 0;
    //    }
    //    //if (Input.GetKeyDown(KeyCode.B))
    //    //{
    //    //    AKelimdeMi = true;
    //    //}
    //    //if (Input.GetKeyUp(KeyCode.B))
    //    //{

    //    //    AKelimdeMi = false;
    //    //}

    //    //REVOLVER
    //    REVOLVERmermiHizi += Time.deltaTime;
    //    if (Input.GetMouseButtonDown(0) && REVOLVERmermiHizi > REVOLVER_AtesEtmeSuresi && silah == 3)
    //    {
    //        if (REVOLVERmermiSayisi > 0)
    //        {
    //            REVOLVERmermiSayisi--;
    //            rgbREVOLVER = Instantiate(REVOLVERkursun, kursunCikisYeriREVOLVER.position, Quaternion.identity).GetComponent<Rigidbody2D>();
    //            rgbREVOLVER.AddForce(Vector2.right * hizi, ForceMode2D.Impulse);
    //            REVOLVERmermiSayisiTexti.text = REVOLVERmermiSayisi.ToString();
    //        }
    //        if (REVOLVERmermiSayisi <= 0 && REVOLVERvarMi)
    //        {
    //            MermiBittiTexti.text = "Mermi Bitti";
    //        }


    //        REVOLVERmermiHizi = 0;
    //    }
    //    //if (Input.GetKeyDown(KeyCode.C))
    //    //{
    //    //    REVOLVERelimdeMi = true;
    //    //}
    //    //if (Input.GetKeyUp(KeyCode.C))
    //    //{
    //    //    REVOLVERelimdeMi = false;
    //    //}

    //    //if (AWPvarMi && AKvarMi && REVOLVERvarMi)
    //    //{
    //    //    if (Input.GetKeyDown(KeyCode.P))
    //    //    {
    //    //        silah++;
    //    //        if (silah % 3 == 1 && AWPvarMi)
    //    //        {
    //    //            //  Debug.Log("AWP girdi");
    //    //            AWP.SetActive(true);
    //    //            REVOLVER.SetActive(false);
    //    //            AK47.SetActive(false);
    //    //        }
    //    //        if (silah % 3 == 2 && AKvarMi)
    //    //        {
    //    //            //  Debug.Log("Ak girdi");
    //    //            AWP.SetActive(false);
    //    //            REVOLVER.SetActive(false);
    //    //            AK47.SetActive(true);
    //    //        }
    //    //        if (silah % 3 == 0 && REVOLVERvarMi)
    //    //        {
    //    //            //   Debug.Log("rev girdi");
    //    //            AWP.SetActive(false);
    //    //            REVOLVER.SetActive(true);
    //    //            AK47.SetActive(false);
    //    //        }
    //    //        if (silah > 3)
    //    //        {
    //    //            silah = silah % 3;
    //    //        }
    //    //    }

    //    //}
    //    //else if (REVOLVERvarMi && AWPvarMi && !AKvarMi)
    //    //{
    //    //    //Debug.Log("REV VE AWP ELİMDE keles deil.1.if");
    //    //    if (Input.GetKeyDown(KeyCode.P))
    //    //    {
    //    //        //  Debug.Log("REV VE AWP ELİMDE keles deil.2.if");
    //    //        silah++;
    //    //        if (silah % 2 == 1 && AWPvarMi)
    //    //        {
    //    //            //  Debug.Log("AWP girdi");
    //    //            AWP.SetActive(true);
    //    //            REVOLVER.SetActive(false);
    //    //            AK47.SetActive(false);
    //    //        }

    //    //        if (silah % 2 == 0 && REVOLVERvarMi)
    //    //        {
    //    //            //  Debug.Log("rev girdi");
    //    //            AWP.SetActive(false);
    //    //            REVOLVER.SetActive(true);
    //    //            AK47.SetActive(false);
    //    //        }
    //    //        if (silah > 3)
    //    //        {
    //    //            silah = silah % 3;
    //    //        }
    //    //    }
    //    //}
    //    //else if (AWPvarMi && AKvarMi && !REVOLVERvarMi)
    //    //{
    //    //    if (Input.GetKeyDown(KeyCode.P))
    //    //    {
    //    //        silah++;
    //    //        if (silah % 2 == 1 && AWPvarMi)
    //    //        {
    //    //            //  Debug.Log("AWP girdi");
    //    //            AWP.SetActive(true);
    //    //            REVOLVER.SetActive(false);
    //    //            AK47.SetActive(false);
    //    //        }
    //    //        if (silah % 2 == 0 && AKvarMi)
    //    //        {
    //    //            //  Debug.Log("Ak girdi");
    //    //            AWP.SetActive(false);
    //    //            REVOLVER.SetActive(false);
    //    //            AK47.SetActive(true);
    //    //        }

    //    //        if (silah >= 3)
    //    //        {

    //    //            silah = silah % 3;
    //    //        }
    //    //        if (silah == 0)
    //    //        {
    //    //            silah = 1;
    //    //        }

    //    //    }
    //    //}
    //    //else if (!AWPvarMi && AKvarMi && REVOLVERvarMi)
    //    //{
    //    //    if (Input.GetKeyDown(KeyCode.P))
    //    //    {
    //    //        silah++;
    //    //        if (silah % 2 == 0 && AKvarMi)
    //    //        {
    //    //            //  Debug.Log("Ak girdi");
    //    //            AWP.SetActive(false);
    //    //            REVOLVER.SetActive(false);
    //    //            AK47.SetActive(true);
    //    //        }
    //    //        if (silah % 2 == 1 && REVOLVERvarMi)
    //    //        {
    //    //            //   Debug.Log("rev girdi");
    //    //            AWP.SetActive(false);
    //    //            REVOLVER.SetActive(true);
    //    //            AK47.SetActive(false);
    //    //        }
    //    //        if (silah > 3)
    //    //        {
    //    //            silah = 1;
    //    //        }
    //    //        if (silah == 1)
    //    //        {
    //    //            silah = 2;
    //    //        }

    //    //    }


    //    //}
        
    //}

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AWP" )
        {
            silah = 1;
            AWPvarMi = true;
            //  Debug.Log("AWP collider girdi");
            Destroy(collision.gameObject);
            AWP.SetActive(true);
            AK47.SetActive(false);
            REVOLVER.SetActive(false);
        }
        if (collision.gameObject.tag == "AK47")
        {
            silah = 2;
            // Debug.Log("Ak collider girdi");

            AKvarMi = true;
            //  vektor1 = new Vector2(transform.localScale.x * (AK47.transform.localScale.x / Mathf.Abs(this.transform.localScale.x)), transform.localScale.y * (AK47.transform.localScale.y / Mathf.Abs(this.transform.localScale.y)));
            Destroy(collision.gameObject);
            AWP.SetActive(false);
            AK47.SetActive(true);
            REVOLVER.SetActive(false);

        }
        if (collision.gameObject.tag == "REVOLVER"  )
        {
            //   Debug.Log("rev collider girdi");

            silah = 3;
            REVOLVERvarMi = true;
            // vektor2 = new Vector2(transform.localScale.x * (REVOLVER.transform.localScale.x / Mathf.Abs(this.transform.localScale.x)), transform.localScale.y * (REVOLVER.transform.localScale.y / Mathf.Abs(this.transform.localScale.y)));
            Destroy(collision.gameObject);
            AWP.SetActive(false);
            AK47.SetActive(false);
            REVOLVER.SetActive(true);
        }

    }
    public void AtesEtJoystick()
    {
        AWPmermiHizi += Time.deltaTime;
        if ( silah == 1)
        {
            if (AWPmermiSayisi > 0)
            {
                AWPmermiSayisi--;
                rgbAWP = Instantiate(AWPkursun, kursunCikisYeriAWP.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                rgbAWP.AddForce(Vector2.right * hizi, ForceMode2D.Impulse);
                AWPmermiSayisiTexti.text = AWPmermiSayisi.ToString();
            }
            if (AWPmermiSayisi <= 0 && AWPvarMi)
            {
                MermiBittiTexti.text = "Mermi Bitti";
            }

            AWPmermiHizi = 0;
        }
        //////////////////////////
        AKmermiHizi += Time.deltaTime;
        if (silah == 2)
        {
            if (AKmermiSayisi > 0)
            {
                AKmermiSayisi--;
                rgbAK = Instantiate(AKkursun, kursunCikisYeriAK.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                rgbAK.AddForce(Vector2.right * hizi, ForceMode2D.Impulse);
                AKmermiSayisiTexti.text = AKmermiSayisi.ToString();
            }
            if (AKmermiSayisi <= 0 && AKvarMi)
            {
                MermiBittiTexti.text = "Mermi Bitti";
            }
            AKmermiHizi = 0;
        }
        //////////////////////////////
        ///REVOLVERmermiHizi += Time.deltaTime;
        if ( silah == 3)
        {
            if (REVOLVERmermiSayisi > 0)
            {
                REVOLVERmermiSayisi--;
                rgbREVOLVER = Instantiate(REVOLVERkursun, kursunCikisYeriREVOLVER.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                rgbREVOLVER.AddForce(Vector2.right * hizi, ForceMode2D.Impulse);
                REVOLVERmermiSayisiTexti.text = REVOLVERmermiSayisi.ToString();
            }
            if (REVOLVERmermiSayisi <= 0 && REVOLVERvarMi)
            {
                MermiBittiTexti.text = "Mermi Bitti";
            }


            REVOLVERmermiHizi = 0;
        }

    }
     public void SolaGitJoystick()
    {
        hori = -1;
    }
    public void SagaGitJoystick()
    {
        hori = 1;
    }
    public void ZiplaJoystick()
    {
        if ( ZipliyorMu == false)
        {
            rb.AddForce(new Vector2(0, ziplamaHiz));
            if (!AWPvarMi && !AKvarMi && !REVOLVERvarMi)
            {
                anim.SetBool("zipliyorMu", true);
            }
         //   anim.SetBool("zipliyorMu", false);

            ZipliyorMu = true;
        }
        else
        {
            if (AWPvarMi || AKvarMi || REVOLVERvarMi)
            {
                anim.SetBool("zipliyorMu", false);
            }


        }

    }
    public void SilahDegisJoystick()
    {
        if (AWPvarMi && AKvarMi && REVOLVERvarMi)
        {
           
                silah++;
                if (silah % 3 == 1 && AWPvarMi)
                {
                    //  Debug.Log("AWP girdi");
                    AWP.SetActive(true);
                    REVOLVER.SetActive(false);
                    AK47.SetActive(false);
                }
                if (silah % 3 == 2 && AKvarMi)
                {
                    //  Debug.Log("Ak girdi");
                    AWP.SetActive(false);
                    REVOLVER.SetActive(false);
                    AK47.SetActive(true);
                }
                if (silah % 3 == 0 && REVOLVERvarMi)
                {
                    //   Debug.Log("rev girdi");
                    AWP.SetActive(false);
                    REVOLVER.SetActive(true);
                    AK47.SetActive(false);
                }
                if (silah > 3)
                {
                    silah = silah % 3;
                }
            

        }
        else if (REVOLVERvarMi && AWPvarMi && !AKvarMi)
        {
            //Debug.Log("REV VE AWP ELİMDE keles deil.1.if");
            
                //  Debug.Log("REV VE AWP ELİMDE keles deil.2.if");
                silah++;
                if (silah % 2 == 1 && AWPvarMi)
                {
                    //  Debug.Log("AWP girdi");
                    AWP.SetActive(true);
                    REVOLVER.SetActive(false);
                    AK47.SetActive(false);
                }

                if (silah % 2 == 0 && REVOLVERvarMi)
                {
                    //  Debug.Log("rev girdi");
                    AWP.SetActive(false);
                    REVOLVER.SetActive(true);
                    AK47.SetActive(false);
                }
                if (silah > 3)
                {
                    silah = silah % 3;
                }
            
        }
        else if (AWPvarMi && AKvarMi && !REVOLVERvarMi)
        {
            
                silah++;
                if (silah % 2 == 1 && AWPvarMi)
                {
                    //  Debug.Log("AWP girdi");
                    AWP.SetActive(true);
                    REVOLVER.SetActive(false);
                    AK47.SetActive(false);
                }
                if (silah % 2 == 0 && AKvarMi)
                {
                    //  Debug.Log("Ak girdi");
                    AWP.SetActive(false);
                    REVOLVER.SetActive(false);
                    AK47.SetActive(true);
                }

                if (silah >= 3)
                {

                    silah = silah % 3;
                }
                if (silah == 0)
                {
                    silah = 1;
                }

            
        }
        else if (!AWPvarMi && AKvarMi && REVOLVERvarMi)
        {
           
                silah++;
                if (silah % 2 == 0 && AKvarMi)
                {
                    //  Debug.Log("Ak girdi");
                    AWP.SetActive(false);
                    REVOLVER.SetActive(false);
                    AK47.SetActive(true);
                }
                if (silah % 2 == 1 && REVOLVERvarMi)
                {
                    //   Debug.Log("rev girdi");
                    AWP.SetActive(false);
                    REVOLVER.SetActive(true);
                    AK47.SetActive(false);
                }
                if (silah > 3)
                {
                    silah = 1;
                }
                if (silah == 1)
                {
                    silah = 2;
                }

            


        }
    }
    public void sifirlamaJoystick()
    {
        hori = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Taban" || collision.collider.tag == "alev") && !(collision.gameObject.tag == "zipzip"))
        {
            ZipliyorMu = false;
            anim.SetBool("zipliyorMu", false);

        }
        if (collision.gameObject.tag == "zipzip")
        {
            //anim.SetBool("zipliyorMu",true);
            rb.AddForce(new Vector2(0, trambolinHiz));

        }
        if (collision.gameObject.tag == "alev")
        {
            StartCoroutine(AlevTemas());
        }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        // KarakterSpriteRendereri.color = Color.red;
        if (collision.gameObject.tag == "suluk")
        {
            SulukCanGitmeHizi += Time.deltaTime;
            if (SulukCanGitmeHizi > 0.3f)
            {
                KarakterCan -= 10;
                SulukCanGitmeHizi = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "alevtopu")
        {
            KarakterCan -= 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag=="AKmermiEkle")
        {
            if (AKvarMi)
            {
                AKmermiSayisi += 10;
                AKmermiSayisiTexti.text = AKmermiSayisi.ToString();
                Destroy(collision.gameObject);
            }
            

        }
        if (collision.gameObject.tag == "AWPmermiEkle")
        {
            if (AWPvarMi)
            {
                AWPmermiSayisi += 10;
                AWPmermiSayisiTexti.text = AWPmermiSayisi.ToString();
                Destroy(collision.gameObject);
            }


        }
        if (collision.gameObject.tag == "REVmermiEkle")
        {
            if (REVOLVERvarMi)
            {
                REVOLVERmermiSayisi += 10;
                REVOLVERmermiSayisiTexti.text = REVOLVERmermiSayisi.ToString();
                Destroy(collision.gameObject);
            }


        }

    }







}









