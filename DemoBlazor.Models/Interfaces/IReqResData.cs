namespace DemoBlazor.Models.Interfaces;

public interface IReqResData
{
    Task<List<Person>?> GetPeople();
    void CancelRequest();
}
