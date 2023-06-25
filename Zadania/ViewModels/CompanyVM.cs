using System.ComponentModel.DataAnnotations;

namespace Zadania.Models
{
    public class RepresentativeVM
    {
       
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nip { get; set; }
        public string companyName { get; set; }
    }

    public class ResultVM
    {
       
        public SubjectVM subject { get; set; }
        public string requestDateTime { get; set; }
        public string requestId { get; set; }
    }

    public class RootVM
    {

        public ResultVM result { get; set; }
    }
    public class EntityPersonProkurentVM
    {
        
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string pesel { get; set; }
        public string nip { get; set; }


    }
    public class EntityPersonWspolnikVM
    {
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string pesel { get; set; }
        public string nip { get; set; }


    }
    
    
    public class SubjectVM
    {
        public SubjectVM()
        {
            this.authorizedClerks = new List<EntityPersonProkurentVM>();
            this.partners = new List<EntityPersonWspolnikVM>();
            this.representatives = new List<RepresentativeVM>();
        }
        public List<EntityPersonProkurentVM> authorizedClerks { get; set; }
        public string regon { get; set; }
        public string restorationDate { get; set; }
        public string workingAddress { get; set; }
        public bool hasVirtualAccounts { get; set; }
        public string statusVat { get; set; }
        public string krs { get; set; }
        public string restorationBasis { get; set; }
        public List<string> accountNumbers { get; set; }
        public string registrationDenialBasis { get; set; }
        public string nip { get; set; }
        public string removalDate { get; set; }
        public List<EntityPersonWspolnikVM> partners { get; set; }
        public string name { get; set; }
        public string registrationLegalDate { get; set; }
        public string removalBasis { get; set; }
        public string pesel { get; set; }
        public List<RepresentativeVM> representatives { get; set; }
        public string residenceAddress { get; set; }
        public string registrationDenialDate { get; set; }
    }

    public class RespondVM
    {

        public string nip { get; set; }

    }
}
