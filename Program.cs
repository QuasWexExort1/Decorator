interface IWeapon
{
    string GetName();
    int GetDamage();
}

class Sword : IWeapon
{
    public string GetName()
    {
        return "Sword";
    }

    public int GetDamage()
    {
        return 50;
    }
}

class Bow : IWeapon
{
    public string GetName()
    {
        return "Bow";
    }

    public int GetDamage()
    {
        return 40;
    }
}

class Staff : IWeapon
{
    public string GetName()
    {
        return "Staff";
    }

    public int GetDamage()
    {
        return 35;
    }
}

class WeaponDecorator : IWeapon
{
    protected IWeapon weapon;

    public WeaponDecorator(IWeapon weapon)
    {
        this.weapon = weapon;
    }

    public virtual string GetName()
    {
        return weapon.GetName();
    }

    public virtual int GetDamage()
    {
        return weapon.GetDamage();
    }
}

class FireDecorator : WeaponDecorator
{
    public FireDecorator(IWeapon weapon) : base(weapon)
    {

    }

    public override string GetName()
    {
        return weapon.GetName() + ", с огнем";
    }

    public override int GetDamage()
    {
        return weapon.GetDamage() + 10;
    }
}

class PoisonDecorator : WeaponDecorator
{
    public PoisonDecorator(IWeapon weapon) : base(weapon)
    {

    }

    public override string GetName()
    {
        return weapon.GetName() + ", с ядом";
    }

    public override int GetDamage()
    {
        return weapon.GetDamage() + 15;
    }
}

class CriticalDecorator : WeaponDecorator
{
    public CriticalDecorator(IWeapon weapon) : base(weapon)
    {

    }

    public override string GetName()
    {
        return weapon.GetName() + ", с критическим уроном!";
    }

    public override int GetDamage()
    {
        return weapon.GetDamage() + 30;
    }
}

class Program
{
    static void Main()
    {
        IWeapon weapon = new Sword();

        weapon = new FireDecorator(weapon);

        weapon = new PoisonDecorator(weapon);

        Console.WriteLine(weapon.GetName());
        Console.WriteLine(weapon.GetDamage());


        IWeapon bow = new Bow();
        bow = new PoisonDecorator(bow);
        bow = new CriticalDecorator(bow);
        Console.WriteLine(bow.GetName());
        Console.WriteLine(bow.GetDamage());

        IWeapon staff = new Staff();
        staff = new FireDecorator(staff);
        Console.WriteLine(staff.GetName());
        Console.WriteLine(staff.GetDamage());
    }
}