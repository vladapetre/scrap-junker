using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Abot.Events;
using ScrapJunker.Crawler.Api;
using ScrapJunker.Crawler.Api.CQRS.Commands;
using ScrapJunker.Crawler.Base;
using ScrapJunker.Crawler.Core.Interface;
using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.IOC;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrapJunker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new CrawlerApiObjectFactory());

            var crawlDispathcer = container.GetInstance<ICommandDispatcher>();



            var configuration = new CrawlerConfiguration()
            {
                CrawlTimeoutSeconds = 30,
                MaxConcurrentThreads = 1,
                MaxPagesToCrawl = 5,
                UserAgentString = "Scrap Junker Test v1",
            };

            var domainNames = new List<string>
            {
            "http://opelkeersebilck.opbe.carflowmanager.be",
            "http://opelgman.opbe.carflowmanager.be",
            "http://opelberckmans.opbe.carflowmanager.be",
            "http://opelvervloet.opbe.carflowmanager.be",
            "http://opelvanhollebeke.opbe.carflowmanager.be",
            "http://opelexelmans.opbe.carflowmanager.be",
            "http://opeldhontgjl.opbe.carflowmanager.be",
            "http://opelmazuinneuville.opbe.carflowmanager.be",
            "http://opelpiret.opbe.carflowmanager.be",
            "http://opeldeleersnyder.opbe.carflowmanager.be",
            "http://opelvanacker.opbe.carflowmanager.be",
            "http://opelgoethals.opbe.carflowmanager.be",
            "http://opelvalentin.opbe.carflowmanager.be",
            "http://opellonneville.opbe.carflowmanager.be",
            "http://bodenbrussels.opbe.carflowmanager.be",
            "http://opelbouzendorff.opbe.carflowmanager.be",
            "http://opelhens.opbe.carflowmanager.be",
            "http://opelvoetdiksmuide.opbe.carflowmanager.be",
            "http://etswillemssa.opbe.carflowmanager.be",
            "http://opelgeurts.opbe.carflowmanager.be",
            "http://opelgaragemon.opbe.carflowmanager.be",
            "http://opelbeerens.opbe.carflowmanager.be",
            "http://opeldetandtmarc.opbe.carflowmanager.be",
            "http://opelgaragevdcars.opbe.carflowmanager.be",
            "http://opelmontysmotor.opbe.carflowmanager.be",
            "http://opelnoirhomme.opbe.carflowmanager.be",
            "http://opeldecru.opbe.carflowmanager.be",
            "http://opeldeluyker.opbe.carflowmanager.be",
            "http://opeldelta.opbe.carflowmanager.be",
            "http://opelwillemoons.opbe.carflowmanager.be",
            "http://opelvandenabbeele.opbe.carflowmanager.be",
            "http://opeloset.opbe.carflowmanager.be",
            "http://opelhouttequiet.opbe.carflowmanager.be",
            "http://opelfrijters.opbe.carflowmanager.be",
            "http://opeldeclerc.opbe.carflowmanager.be",
            "http://opelmarchemotors.opbe.carflowmanager.be",
            "http://opeldinantmotors.opbe.carflowmanager.be",
            "http://opelmulkers.opbe.carflowmanager.be",
            "http://opelwittockx.opbe.carflowmanager.be",
            "http://opelsoers.opbe.carflowmanager.be",
            "http://opelvanneste.opbe.carflowmanager.be",
            "http://opeldegroote.opbe.carflowmanager.be",
            "http://opelvanderhaegen.opbe.carflowmanager.be",
            "http://opelrikleyssen.opbe.carflowmanager.be",
            "http://opelautopolis.opbe.carflowmanager.be",
            "http://opelwerneresch.opbe.carflowmanager.be",
            "http://opelbuga.opbe.carflowmanager.be",
            "http://opelleplae.opbe.carflowmanager.be",
            "http://opelproxicar.opbe.carflowmanager.be",
            "http://opelmullens.opbe.carflowmanager.be",
            "http://opelgeurtsgenk.opbe.carflowmanager.be",
            "http://opelgaragejacobl�onsa.opbe.carflowmanager.be",
            "http://opelgaragecox.opbe.carflowmanager.be",
            "http://opelgaragevanderroost.opbe.carflowmanager.be",
            "http://opelstoffelen.opbe.carflowmanager.be",
            "http://opelgaragedesitter.opbe.carflowmanager.be",
            "http://opeletsmonniersa.opbe.carflowmanager.be",
            "http://opelgaragewilly.opbe.carflowmanager.be",
            "http://opelvandenabbeelefreddy.opbe.carflowmanager.be",
            "http://opelgaragegovaertshugo.opbe.carflowmanager.be",
            "http://opelgaragegysens.opbe.carflowmanager.be",
            "http://opelgaragedevriendt.opbe.carflowmanager.be",
            "http://opelvanmoljoseph.opbe.carflowmanager.be",
            "http://opelgaragedecortejulien.opbe.carflowmanager.be",
            "http://opelgaragevanlanduyt.opbe.carflowmanager.be",
            "http://opelctcmoyson.opbe.carflowmanager.be",
            "http://opelbarto.opbe.carflowmanager.be",
            "http://opelgaragevanroosbroeck.opbe.carflowmanager.be",
            "http://opelhaesen.opbe.carflowmanager.be",
            "http://opelgaragehubin.opbe.carflowmanager.be",
            "http://opelgaragedebolle.opbe.carflowmanager.be",
            "http://opelgaragebaeten.opbe.carflowmanager.be",
            "http://opeldegadt.opbe.carflowmanager.be",
            "http://opeldelim.opbe.carflowmanager.be",
            "http://opelmanoli.opbe.carflowmanager.be",
            "http://opelstevens.opbe.carflowmanager.be",
            "http://opelgaragestniklaas.opbe.carflowmanager.be",
            "http://opeldhont.opbe.carflowmanager.be",
            "http://opeldeketelaere.opbe.carflowmanager.be",
            "http://opelvienne.opbe.carflowmanager.be",
            "http://opelgaragethomaes.opbe.carflowmanager.be",
            "http://opelneyrinck.opbe.carflowmanager.be",
            "http://opelgarageriesfr�res.opbe.carflowmanager.be",
            "http://opelbounameaux.opbe.carflowmanager.be",
            "http://opelliegeauto.opbe.carflowmanager.be",
            "http://opelspirlet.opbe.carflowmanager.be",
            "http://opelalain.opbe.carflowmanager.be",
            "http://opelbaert.opbe.carflowmanager.be",
            "http://opeldesmetmotors.opbe.carflowmanager.be",
            "http://opeldecaigny.opbe.carflowmanager.be",
            "http://opeldesomersinnesael.opbe.carflowmanager.be",
            "http://opelvanderperre.opbe.carflowmanager.be",
            "http://opelbastien.opbe.carflowmanager.be",
            "http://welkombijopellauwersgman.opbe.carflowmanager.be",
            "http://opelbredael.opbe.carflowmanager.be",
            "http://opelmenggarage.opbe.carflowmanager.be",
            "http://opelbariseaumottrie.opbe.carflowmanager.be",
            "http://motorcenterdiekirch.opbe.carflowmanager.be",
            "http://opelgaragekreusen.opbe.carflowmanager.be",
            "http://opelcgautomobiles.opbe.carflowmanager.be",
            "http://opelautostad.opbe.carflowmanager.be",
            "http://opelvandierendonck.opbe.carflowmanager.be",
            "http://opelfran�ois.opbe.carflowmanager.be",
            "http://lecomtescrl.opbe.carflowmanager.be",
            "http://garagerenier.opbe.carflowmanager.be"
            };

            Parallel.ForEach(domainNames, new ParallelOptions
            {
                MaxDegreeOfParallelism = 10
            }
            ,domain =>
            {
                crawlDispathcer.Dispatch(new RunCrawlerCommand(Guid.NewGuid(), -1, new Crawler.Api.DTO.RunCrawlerConfigurationDto
                {
                    CrawlTimeoutSeconds = 30,
                    MaxConcurrentThreads = 10,
                    MaxPagesToCrawl = 500,
                    Url = domain
                }));
            });
        }
    }
}
