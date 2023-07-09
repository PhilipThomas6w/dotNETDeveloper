namespace FourPillarsApp
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public string Species { get; set; }

        public int Legs { get; set; }

        public DateTime Age { get; set; }

        public int MyProperty { get; set; }

        public abstract string Speak();
        

        public virtual double Move()
        {
            return 0d;
        }

    }
}
