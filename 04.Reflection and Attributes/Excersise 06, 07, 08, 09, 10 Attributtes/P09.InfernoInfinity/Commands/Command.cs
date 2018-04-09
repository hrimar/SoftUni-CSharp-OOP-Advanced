using P09.InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command : IExecutable
    {

    private Dictionary<string, IWeapon> weapons;
    private WeaponFactory weaponFactory;
    private GemFactory gemFactory;
    private string[] args;

    public string[] Args
    {
        get { return args; }
        set { args = value; }
    }



    public Command(Dictionary<string, IWeapon> weapons, WeaponFactory weaponFactory, GemFactory gemFactory, string[] args)
    {
        this.Weapons = weapons;
        this.WeaponFactory = weaponFactory;
        this.GemFactory = gemFactory;
        this.Args = args;
    }


    public GemFactory GemFactory
    {
        get { return gemFactory; }
        set { gemFactory = value; }
    }


    public WeaponFactory WeaponFactory
    {
        get { return  weaponFactory; }
        set {  weaponFactory = value; }
    }

    public Dictionary<string, IWeapon> Weapons
    {
        get { return weapons; }
        set { weapons = value; }
    }

    public abstract void Execute();

}

