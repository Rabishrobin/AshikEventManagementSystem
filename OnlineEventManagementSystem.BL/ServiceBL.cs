using OnlineEventManagement.DAL.Repository;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL
{
    public class ServiceBL
    {
        public static void AddService(Service newService)
        {
            ServiceRepository.AddService(newService);       //Adding new service
        }
        public static Service GetServiceById(string serviceId)
        {
            return ServiceRepository.GetServiceById(serviceId);    //Getting a particular service from the database
        }
        public static IEnumerable<Service> DisplayServices()
        {
            return ServiceRepository.DisplayServices();         //Getting the services from the database
        }
        public static bool VerifyService(string serviceId)
        {
            return ServiceRepository.VerifyService(serviceId);    //Verifying service existance
        }
        public static void DeleteService(string serviceId)
        {
            ServiceRepository.DeleteService(serviceId);         //Deleting service from the database
        }
        public static void UpdateService(Service service)
        {
            ServiceRepository.UpdateService(service);      //Updating the service details in the database
        }
    }
}
