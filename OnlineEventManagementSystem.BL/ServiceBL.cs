using OnlineEventManagement.DAL.Repository;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.BL.Interface;
using System.Collections.Generic;
using OnlineEventManagementSystem.Entity;
using System;

namespace OnlineEventManagementSystem.BL
{
    public class ServiceBL : IServiceBL
    {
        IServiceRepository serviceRepository;
        public ServiceBL()
        {
            serviceRepository = new ServiceRepository();
        }
        public void AddService(Service service)
        {
            serviceRepository.AddService(service);       //Adding new service
        }
        public Service GetServiceById(int serviceId)
        {
            return serviceRepository.GetServiceById(serviceId);    //Getting a particular service from the database
        }
        public IEnumerable<Service> GetServiceList()
        {
            return serviceRepository.GetServiceList();         //Getting the services from the database
        }
        public bool VerifyService(string serviceName)
        {
            return serviceRepository.VerifyService(serviceName);    //Verifying service existance
        }
        public void DeleteService(int serviceId)
        {
            serviceRepository.DeleteService(serviceId);         //Deleting service from the database
        }
        public void UpdateService(Service service)
        {
            serviceRepository.UpdateService(service);      //Updating the service details in the database
        }

        public int GenerateServiceID()
        {
            return serviceRepository.GenerateServiceID();
        }
    }
}
