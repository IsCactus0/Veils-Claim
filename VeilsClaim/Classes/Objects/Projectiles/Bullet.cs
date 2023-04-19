namespace VeilsClaim.Classes.Objects.Projectiles
{
    public class Bullet : Projectile
    {
        public Bullet(Projectile copy)
            : base(copy)
        {
        }
        public Bullet()
            : base()
        {
            Penetration = 3;
            MinDamage = 12;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public override void Update(float delta)
        {
            base.Update(delta);
        }
        public override Bullet Clone()
        {
            return new Bullet(this);
        }
    }
}