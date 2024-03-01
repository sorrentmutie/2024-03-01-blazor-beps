using DemoBlazor.Models.Interfaces;

namespace DemoBlazor.Models.Services;

public class ServizioDatiEventi : IDatiEventi
{
    public List<Evento> EstraiEventiFuturi()
    {
        return new List<Evento>
        {
           new Evento { Id = 1, Data = DateTime.Today, Località = "Napoli", Nome = "Intro a Blazor" },
           new Evento { Id = 2, Data = DateTime.Today.AddDays(7), Località = "Torino", Nome = "Servizi in Blazor" },
        };
    }

    public List<Evento> EstraiEventiPassati()
    {
       return new List<Evento>
        {
           new Evento { Id = 3, Data = DateTime.Today.AddDays(-7), Località = "Milano", Nome = "Intro a Blazor" },
           new Evento { Id = 4, Data = DateTime.Today.AddDays(-14), Località = "Roma", Nome = "Servizi in Blazor" },
        };
    }
}
