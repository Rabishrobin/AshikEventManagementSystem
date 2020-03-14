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
    //    public static void AddService(Service newService)
    //    {
    //        using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
    //        {
    //            context.Services.Add(newService);
    //            context.SaveChanges();
    //        } 
    //    }

        public static void AddService(Service service)
        {
            using (SqlConnection con = new SqlConnection("EventManagement"))
            {
                SqlCommand cmd = new SqlCommand("Service_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Service_Id", service.ServiceID);
                cmd.Parameters.AddWithValue("@Service_Name", service.ServiceName);
                cmd.Parameters.AddWithValue("@Service_Type", service.ServiceCategory);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static IEnumerable<Service> DisplayServices()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.ToList();
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
                IsExist = (context.Services.Where(e => e.ServiceID == serviceId).FirstOrDefault() == null);
            }
            return IsExist;
        }
        public static Service GetServiceById(string serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Services.Where(e => e.ServiceID == serviceId).FirstOrDefault();
            }
        }
        public static void DeleteService(string serviceId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Service service = GetServiceById(serviceId);
                context.Services.Attach(service);
                context.Services.Remove(service);
                context.SaveChanges();
            }
        }
    }
}
