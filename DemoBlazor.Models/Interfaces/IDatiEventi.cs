namespace DemoBlazor.Models.Interfaces;

public interface IDatiEventi
{
    List<Evento> EstraiEventiPassati();
    List<Evento> EstraiEventiFuturi();
}
