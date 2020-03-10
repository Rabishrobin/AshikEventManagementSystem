using OnlineEventManagement.DAL.Repository;
using OnlineEventManagement.Repository.DAL;
using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEventManagementSystem.BL
{
    public class ServiceBL
    {
        public static void AddService(Service newService)
        {
            ServiceRepository.AddService(newService);
        }
    }
}
