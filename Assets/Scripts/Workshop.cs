using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop : MonoBehaviour
{

    public Blade blade;

    public Grip grip;

    public Gem[] gems;

    private Weapon assemblyWeapon;



    public void Assemble()
    {
        GameObject weaponObj = new GameObject();
        weaponObj.AddComponent<Weapon>().Assemble(blade, grip, gems);
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 100, 100), "Assemble"))
        {
            Assemble();
        }
    }

}
