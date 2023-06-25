using System.ComponentModel.DataAnnotations;

namespace Zadania.Models
{
    public class Representative
    {
        [Key]
        public int RepresentativeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nip { get; set; }
        public string companyName { get; set; }
    }

    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public Subject subject { get; set; }
        public string requestDateTime { get; set; }
        public string requestId { get; set; }
    }

    public class Root
    {

        [Key]
        public int RootId { get; set; }
        public Result result { get; set; }
    }
    public class EntityPersonProkurent
    {
        [Key]
        public int EntityPersonProkurentId { get; set; }
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string pesel { get; set; }
        public string nip { get; set; }


    }
    public class EntityPersonWspolnik
    {
        [Key]
        public int EntityPersonWspolnikId { get; set; }
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string pesel { get; set; }
        public string nip { get; set; }


    }
    public class AccountNumbers
    {
        [Key]
        public int AccountNumbersId { get; set; }
        public string Numbers { get; set; }
      


    }
    public class Subject
    {
        public Subject()
        {
            this.authorizedClerks = new List<EntityPersonProkurent>();
            this.partners = new List<EntityPersonWspolnik>();
            this.representatives = new List<Representative>();
            //this.accountNumbers = new AccountNumbers();
        }

        [Key]
        public int SubjectId { get; set; }
        public List<EntityPersonProkurent> authorizedClerks { get; set; }
        public string regon { get; set; }
        public string restorationDate { get; set; }
        public string workingAddress { get; set; }
        public bool hasVirtualAccounts { get; set; }
        public string statusVat { get; set; }
        public string krs { get; set; }
        public string restorationBasis { get; set; }
        //public List<AccountNumbers> accountNumbers { get; set; }
        public string registrationDenialBasis { get; set; }
        public string nip { get; set; }
        public string removalDate { get; set; }
        public List<EntityPersonWspolnik> partners { get; set; }
        public string name { get; set; }
        public string registrationLegalDate { get; set; }
        public string removalBasis { get; set; }
        public string pesel { get; set; }
        public List<Representative> representatives { get; set; }
        public string residenceAddress { get; set; }
        public string registrationDenialDate { get; set; }
    }
}
