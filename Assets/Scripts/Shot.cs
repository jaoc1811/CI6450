using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{   
    public agent character;

    public agent target;

    public Projectile projectile;
    public Projectile flying;


    public float Speed;

    protected Vector3 shot;

    public float radius;

    protected void calcutaleFiringSolution(Vector3 start, Vector3 end, float muzzleV,bool coming){
        Vector3 delta = end- start;

        float a = projectile.gravity.magnitude;
        float b = -4 * (Vector3.Dot(projectile.gravity,delta) + muzzleV*muzzleV);
        float c = 4 * delta.magnitude*delta.magnitude;

        float b2minus4ac = b * b - 4 * a * c;

        if( b2minus4ac > 0){

            float time0 = Mathf.Sqrt((-b + Mathf.Sqrt(b2minus4ac)) / (2*a));
            float time1 = Mathf.Sqrt((-b + Mathf.Sqrt(b2minus4ac)) / (2*a));
            float ttt;

            if(time0 < 0){
                if(time1 > 0){
                    ttt = time1;
                }else{
                    return;
                }
            } else {
                if(time1 < 0){
                    ttt = time0;
                } else{
                    ttt = Mathf.Min(time0,time1);
                }
            }


            shot = (delta * 2 - projectile.gravity * (ttt * ttt)) / (2 * muzzleV * ttt);

            if(coming){
                flying.velocity=shot*Speed;
                
            }else{
                projectile.velocity = shot*Speed;

                flying = Instantiate(projectile);
            }
          
        }

    }


    // Update is called once per frame
    void Update()
    {   
        float distance = Mathf.Infinity;
        float distance2 = distance;
        if(Input.GetKeyDown(KeyCode.J)){
            projectile.transform.position = character.transform.position;

            shot = character.asVector(character.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * Speed + new Vector3(0,0,10f);
            projectile.velocity = shot;
            Instantiate(projectile);


        } else if(Input.GetKeyDown(KeyCode.K)){
            projectile.transform.position = character.transform.position;

            calcutaleFiringSolution(character.transform.position,target.transform.position,Speed,false);
        }


        if(flying){
            distance = (flying.transform.position - target.transform.position).magnitude;

            if(distance < radius){
            //     projectile.transform.position = target.transform.position;

                calcutaleFiringSolution(target.transform.position,character.transform.position,Speed,true);
            }

            distance2 = (flying.transform.position - character.transform.position).magnitude;

            if(distance2 < radius){
                calcutaleFiringSolution(character.transform.position,target.transform.position,Speed,true);
            }
        }


    }
}
