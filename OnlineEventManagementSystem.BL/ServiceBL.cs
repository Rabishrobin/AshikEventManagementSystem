using OnlineEventManagement.DAL.Repository;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL
{
    public class ServiceBL
    {
        static IElementRepository serviceRepository;
        static ServiceBL()
        {
            serviceRepository = new ServiceRepository();
        }
        public static void AddService(Service newService)
        {
            serviceRepository.AddElement(newService);       //Adding new service
        }
        public static Service GetServiceById(int serviceId)
        {
            return (Service)serviceRepository.GetElementById(serviceId);    //Getting a particular service from the database
        }
        public static IEnumerable<Service> DisplayServices()
        {
            return (IEnumerable<Service>)serviceRepository.DisplayElements();         //Getting the services from the database
        }
        public static int? VerifyService(string serviceName)
        {
            return serviceRepository.VerifyExistance(serviceName);    //Verifying service existance
        }
        public static void DeleteService(int serviceId)
        {
            serviceRepository.DeleteElement(serviceId);         //Deleting service from the database
        }
        public static void UpdateService(Service service)
        {
            serviceRepository.UpdateElement(service);      //Updating the service details in the database
        }
    }
}
