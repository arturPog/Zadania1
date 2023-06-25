using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetStarCore5.Helpers;
using Newtonsoft.Json;
using Zadania.Data;
using Zadania.Helpers.SRTProcessor;
using Zadania.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Zadania.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly SubtitleProcessor _subtitleProcessor;
        IWebHostEnvironment _hostingEnvironment;
        public CompanyApiController(
            ILogger<CompanyController> logger,
            IHttpClientFactory clientFactory,
            IMapper mapper,
            DatabaseContext context,
             IWebHostEnvironment hostingEnvironment
            )
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _mapper = mapper;
            _context = context;
            _subtitleProcessor = new SubtitleProcessor();
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [Route("GetCompany")]
        public async Task<IEnumerable<Subject>> GetCompany()
        {
            var company = await _context.Subjects.ToListAsync();
            return company;


        }

        [HttpPost]
        [Route("AddCompany")]
        public async Task<Subject> AddCompany(RespondVM respond)
        {
            Subject companyDB = null;
            if (ModelState.IsValid)
            {
                string nip = !string.IsNullOrEmpty(respond.nip) ? respond.nip : "";


                companyDB = await _context.Subjects.Where(x => x.nip == nip).Include(x => x.partners).Include(x => x.representatives).Include(x => x.authorizedClerks).FirstOrDefaultAsync();
                if (companyDB == null)
                {
                    var client = _clientFactory.CreateClient();

                    //var client = new HttpClient();
                    client.BaseAddress = new Uri("https://wl-api.mf.gov.pl");
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpRequestMessage request = null;
                    HttpResponseMessage response = null;
                    var dateCyrrent = DateTime.Now.ToString("yyyy-MM-dd");


                    response = await client.GetAsync($"/api/search/nip/{nip}?date={dateCyrrent}");




                    var sessionId = "";
                    if (response.IsSuccessStatusCode)
                    {
                        //sessionId = await responseSessionId.Content.ReadAsStringAsync();


                        var responseContent = await response.Content.ReadAsStringAsync();
                        RootVM companyData = JsonConvert.DeserializeObject<RootVM>(responseContent);

                        companyDB = new Subject();
                        companyDB.krs = companyData.result.subject.krs != null ? companyData.result.subject.krs : "";
                        companyDB.nip = companyData.result.subject.nip != null ? companyData.result.subject.nip : "";

                        if (companyData.result.subject.partners != null && companyData.result.subject.partners.Count() > 0)
                        {
                            EntityPersonWspolnik entityPersonWspolnik = new EntityPersonWspolnik();
                            foreach (var item in companyData.result.subject.partners)
                            {
                                entityPersonWspolnik.nip = item.nip != null ? item.nip : "";
                                entityPersonWspolnik.firstName = item.firstName != null ? item.firstName : "";
                                entityPersonWspolnik.lastName = item.lastName != null ? item.lastName : "";
                                entityPersonWspolnik.companyName = item.companyName != null ? item.companyName : "";
                                entityPersonWspolnik.pesel = item.pesel != null ? item.pesel : "";

                            }
                            companyDB.partners.Add(entityPersonWspolnik);
                        }
                        companyDB.name = companyData.result.subject.name != null ? companyData.result.subject.name : "";
                        companyDB.pesel = companyData.result.subject.pesel != null ? companyData.result.subject.pesel : "";
                        companyDB.registrationDenialDate = companyData.result.subject.registrationDenialDate != null ? companyData.result.subject.registrationDenialDate : "";
                        companyDB.registrationLegalDate = companyData.result.subject.registrationLegalDate != null ? companyData.result.subject.registrationLegalDate : "";
                        companyDB.regon = companyData.result.subject.regon != null ? companyData.result.subject.regon : "";
                        companyDB.removalDate = companyData.result.subject.removalDate != null ? companyData.result.subject.removalDate : "";
                        companyDB.removalBasis = companyData.result.subject.removalBasis != null ? companyData.result.subject.removalBasis : "";

                        if (companyData.result.subject.representatives != null && companyData.result.subject.representatives.Count() > 0)
                        {
                            Representative representative = new Representative();
                            foreach (var item in companyData.result.subject.representatives)
                            {
                                representative.nip = item.nip != null ? item.nip : "";
                                representative.firstName = item.firstName != null ? item.firstName : "";
                                representative.lastName = item.lastName != null ? item.lastName : "";
                                representative.companyName = item.companyName != null ? item.companyName : "";


                            }
                            companyDB.representatives.Add(representative);
                        }
                        companyDB.residenceAddress = companyData.result.subject.residenceAddress != null ? companyData.result.subject.residenceAddress : "";
                        companyDB.statusVat = companyData.result.subject.statusVat != null ? companyData.result.subject.statusVat : "";
                        companyDB.workingAddress = companyData.result.subject.workingAddress != null ? companyData.result.subject.workingAddress : "";
                        companyDB.restorationBasis = companyData.result.subject.restorationBasis != null ? companyData.result.subject.restorationBasis : "";
                        companyDB.restorationDate = companyData.result.subject.restorationDate != null ? companyData.result.subject.restorationDate : "";
                        companyDB.registrationDenialBasis = companyData.result.subject.registrationDenialBasis != null ? companyData.result.subject.registrationDenialBasis : "";
                        companyDB.registrationDenialDate = companyData.result.subject.registrationDenialDate != null ? companyData.result.subject.registrationDenialDate : "";

                        if (companyData.result.subject.authorizedClerks != null && companyData.result.subject.authorizedClerks.Count() > 0)
                        {
                            EntityPersonProkurent entityPersonProkurent = new EntityPersonProkurent();
                            foreach (var item in companyData.result.subject.authorizedClerks)
                            {
                                entityPersonProkurent.nip = item.nip != null ? item.nip : "";
                                entityPersonProkurent.firstName = item.firstName != null ? item.firstName : "";
                                entityPersonProkurent.lastName = item.lastName != null ? item.lastName : "";
                                entityPersonProkurent.companyName = item.companyName != null ? item.companyName : "";
                                entityPersonProkurent.pesel = item.pesel != null ? item.pesel : "";

                            }
                            companyDB.authorizedClerks.Add(entityPersonProkurent);
                        }


                        //var resoult = _mapper.Map<Root>(companyData);

                       

                        _context.Add<Subject>(companyDB);
                        _context.SaveChanges();

                    }
                    else
                    {
                        var testc = "";
                    }
                }
                return companyDB;
            }

            return companyDB;
        }

      
    }
}
