using OnlineEventManagement.DAL;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class PackageRepository : IPackageRepository
    {
        public void AddPackage(Package newPackage)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Packages.Add(newPackage);           //Adding the Package details to the context
                context.SaveChanges();                  //Saving the changes to the database
            }
        }
        public void DeletePackage(int packageId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Package existingPackage = GetPackageById(packageId);                    //Getting the package object to be deleted
                context.Packages.Attach(existingPackage);                           //Attaching the object to be removed
                context.Packages.Remove(existingPackage);                           //Removing the event from the database
                context.SaveChanges();                                          //Saving the changes
            }
        }
        public void UpdatePackage(Package updatedPackage)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry(updatedPackage).State = System.Data.Entity.EntityState.Modified;        //Updating the package details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
        public IEnumerable<Package> GetPackageList()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Packages.ToList();                         //Getting all the packages from the database as a list
            }
        }
        public bool VerifyPackage(string packageName)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                bool CanAddEvent = false;
                //Verifying the existance of the package
                if (context.Events.Where(u => u.EventName == packageName).FirstOrDefault() == null)
                {
                    CanAddEvent = true;
                }
                return CanAddEvent;
            }
        }
        public Package GetPackageById(int pacakageId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Packages.Where(e => e.PackageID == pacakageId).FirstOrDefault();        //Getting the event details by passing the id 
            }
        }
        public int GeneratePackageID()
        {
            int id = 0;
            int packageId;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                //Getting the latest package id
                id = int.Parse(context.Packages.ToList().Last().PackageID.ToString().Substring(4)) + 1;
                //Generating event id
                packageId = int.Parse((int)'P' + DateTime.Now.Year.ToString().Substring(2, 2) + id.ToString().PadLeft(3, '0'));
            }
            return packageId;
        }
    }
}
