using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL.Interface
{
    public interface IServiceBL
    {
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(int serviceId);
        IEnumerable<Service> GetServiceList();
        Service GetServiceById(int serviceId);
        bool VerifyService(string serviceName);
        int GenerateServiceID();
    }
}
