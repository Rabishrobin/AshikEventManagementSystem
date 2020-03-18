using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineEventManagement.DAL.Repository
{
    public class ServiceRepository
    {
        public static void AddService(Service newService)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Services.Add(newService);               //Adding new service to the database
                context.SaveChanges();                          //Updating the database
            }
        }

        //public static void AddService(Service service)
        //{
        //    using (SqlConnection con = new SqlConnection("EventManagement"))
        //    {
        //        SqlCommand cmd = new SqlCommand("Service_Insert", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Service_Id", service.ServiceID);
        //        cmd.Parameters.AddWithValue("@Service_Name", service.ServiceName);
        //        cmd.Parameters.AddWithValue("@Service_Type", service.ServiceCategory);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}

        public static IEnumerable<Service> DisplayServices()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.ToList();               //Returning the list of the services
            }
        }

        //public IEnumerable<Service> DisplayServices()
        //{
        //    List<Service> serviceList = new List<Service>();

        //    using (SqlConnection con = new SqlConnection("EventManagement"))
        //    {
        //        SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        con.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            Service service = new Service();

        //            service.ServiceID = rdr["[Service Id]"].ToString();
        //            service.ServiceName = rdr["[Service Name]"].ToString();
        //            service.ServiceCategory = rdr["[Service Type]"].ToString();

        //            serviceList.Add(service);
        //        }
        //        con.Close();
        //    }
        //    return serviceList;
        //}

        public static bool VerifyService(string serviceId)
        {
            bool IsExist = false;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                IsExist = (context.Services.Where(e => e.ServiceID == serviceId).FirstOrDefault() == null);     //Verifying the existance of the service
            }
            return IsExist;
        }
        public static Service GetServiceById(string serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.Where(e => e.ServiceID == serviceId).FirstOrDefault();                  //Getting a service by passing the service id as a parameter
            }
        }
        public static void DeleteService(string serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Service service = GetServiceById(serviceId);                                                    //Getting the service object to be deleted
                context.Services.Attach(service);                                                               //Attaching the object to the context
                context.Services.Remove(service);                                                               //Removing the object from the context
                context.SaveChanges();                                                                          //Updating the database after deleting the service
            }
        }
        public static void UpdateService(Service service)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry(service).State = System.Data.Entity.EntityState.Modified;        //Updating the service details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
    }
}
