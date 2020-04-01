using System.Collections.Generic;

namespace OnlineEventManagement.DAL.Interface
{
    public interface IElementRepository
    {
        void AddElement(object obj);
        IEnumerable<object> DisplayElements();
        int? VerifyExistance(string name);
        object GetElementById(int id);
        void DeleteElement(int id);
        void UpdateElement(object obj);
    }
}
