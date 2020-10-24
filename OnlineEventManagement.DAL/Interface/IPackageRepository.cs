using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagement.DAL.Interface
{
    public interface IPackageRepository
    {
        void AddPackage(Package category);
        void UpdatePackage(Package category);
        void DeletePackage(int packageId);
        IEnumerable<Package> GetPackageList();
        Package GetPackageById(int packageId);
        bool VerifyPackage(string packageName);
        int GeneratePackageID();
    }
}
