using OnlineEventManagement.Repository.DAL;
using OnlineEventManagement.DAL.Interface;
using System.Collections.Generic;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using System;

namespace OnlineEventManagementSystem.BL
{
    public class PackageBL : IPackageBL
    {
        IPackageRepository packageRepository;
        public PackageBL()
        {
            packageRepository = new PackageRepository();
        }
        public void AddPackage(Package newPackage)
        {
            packageRepository.AddPackage(newPackage);             //Adding new package to the database
        }
        public Package GetPackageById(int packageId)
        {
            return packageRepository.GetPackageById(packageId);    //Getting a particular package
        }
        public IEnumerable<Package> GetPackageList()
        {
            return packageRepository.GetPackageList();         //Getting the Packages as object in list from the database 
        }
        public bool VerifyPackage(string packageName)
        {
            return packageRepository.VerifyPackage(packageName);        //Verifying the existance of the package
        }
        public void DeletePackage(int packageId)
        {
            packageRepository.DeletePackage(packageId);           //Deleting an package from the database
        }
        public void UpdatePackage(Package updatedPackage)
        {
            packageRepository.UpdatePackage(updatedPackage);      //Updating the package details in the database
        }
        public int GeneratePackageID()
        {
            return packageRepository.GeneratePackageID();
        }
    }
}
