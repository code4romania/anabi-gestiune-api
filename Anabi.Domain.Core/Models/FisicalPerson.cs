namespace Anabi.Domain.Models
{
    public class FisicalPerson : Person
    {
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string PersonalNumber { get; set; }

        public string IdSerie { get; set; }

        public string IdNumber { get; set; }


        public override string Name { get { return Lastname + " " + Firstname; } }

        public override string Identifier { get { return PersonalNumber; } }


    }
}
