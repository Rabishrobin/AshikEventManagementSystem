using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL.Interface
{
    public interface IPackageBL
    {
        void AddPackage(Package newPackage);
        void UpdatePackage(Package existingPackage);
        void DeletePackage(int packageId);
        IEnumerable<Package> GetPackageList();
        Package GetPackageById(int packageId);
        bool VerifyPackage(string packageName);
        int GeneratePackageID();
    }
}
