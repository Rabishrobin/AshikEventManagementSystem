using OnlineEventManagementSystem.Entity;
using OnlineEventManagement.DAL.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OnlineEventManagement.DAL.Repository
{
    public class ServiceRepository : IElementRepository
    {
        public void AddElement(object service)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Services.Add((Service)service);               //Adding new service to the database
                context.SaveChanges();                          //Updating the database
            }
        }

        public IEnumerable<object> DisplayElements()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.ToList();               //Returning the list of the services
            }
        }

        public int? VerifyExistance(string serviceName)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                int? id = null;
                if (context.Services.Where(u => u.ServiceName==serviceName).FirstOrDefault() == null)                   //Verifying service existance
                {
                    IEnumerable<Service> services = context.Services.ToList();
                    id = services.Count() == 0 ? 0 : int.Parse(services.Last().ServiceID.ToString().Substring(4)) + 1;
                }
                return id;                               
            }
        }
        public object GetElementById(int serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.Where(e => e.ServiceID == serviceId).FirstOrDefault();                  //Getting a service by passing the service id as a parameter
            }
        }
        public void DeleteElement(int serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Service service = (Service)GetElementById(serviceId);                                                    //Getting the service object to be deleted
                context.Services.Attach(service);                                                               //Attaching the object to the context
                context.Services.Remove(service);                                                               //Removing the object from the context
                context.SaveChanges();                                                                          //Updating the database after deleting the service
            }
        }
        public void UpdateElement(object service)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry((Service)service).State = System.Data.Entity.EntityState.Modified;        //Updating the service details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
    }
}
