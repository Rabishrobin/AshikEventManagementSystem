using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL.Interface
{
    public interface IElementBL
    {
        void AddElement(object obj);
        object GetElementById(int id);
        IEnumerable<object> DisplayElements();
        int? VerifyExistance(string name);
        void DeleteElement(int id);
        void UpdateElement(object obj);
    }
}
