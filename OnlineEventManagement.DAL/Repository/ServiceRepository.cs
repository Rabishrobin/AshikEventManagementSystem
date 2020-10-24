using OnlineEventManagementSystem.Entity;
using OnlineEventManagement.DAL.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;

namespace OnlineEventManagement.DAL.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public void AddService(Service service)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Services.Add(service);               //Adding new service to the database
                context.SaveChanges();                          //Updating the database
            }
        }
        public IEnumerable<Service> GetServiceList()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.Include("Category").ToList();               //Returning the list of the services
            }
        }
        public bool VerifyService(string serviceName)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                bool CanAddService = false;
                //Verifying the existance of the event
                if (context.Services.Where(u => u.ServiceName == serviceName).FirstOrDefault() == null)
                {
                    CanAddService = true;
                }
                return CanAddService;
            }
        }
        public Service GetServiceById(int serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.Where(e => e.ServiceID == serviceId).FirstOrDefault();                  //Getting a service by passing the service id as a parameter
            }
        }
        public void DeleteService(int serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Service service = GetServiceById(serviceId);                                                    //Getting the service object to be deleted
                context.Services.Attach(service);                                                               //Attaching the object to the context
                context.Services.Remove(service);                                                               //Removing the object from the context
                context.SaveChanges();                                                                          //Updating the database after deleting the service
            }
        }
        public void UpdateService(Service service)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry(service).State = System.Data.Entity.EntityState.Modified;        //Updating the service details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
        public int GenerateServiceID()
        {
            int id = 0;
            int serviceId;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                //Getting the latest event id
                id = int.Parse(context.Services.ToList().Last().ServiceID.ToString().Substring(4))+1;
                //Generating event id
                serviceId = int.Parse((int)'S' + DateTime.Now.Year.ToString().Substring(2, 2) + id.ToString().PadLeft(3, '0'));
            }
            return serviceId;
        }
    }
}
