using SoftwareCompany.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public class DeveloperManager : IDeveloperManager
    {
        #region Fields & Constructor
        private readonly IGenericRepository<Developer> developerRepo;

        public DeveloperManager(IGenericRepository<Developer> _developerRepo)
        {
            developerRepo = _developerRepo;
        }
        #endregion

        #region Methods


        public IEnumerable<DeveloperReadDto> GetAll()
        {
            var DevelopersFromDB = developerRepo.GetAll();
            return DevelopersFromDB.Select(d => new DeveloperReadDto
            {
                Id = d.Id,
                Name = d.Name,
                Salary = d.Salary
            }).ToList();
        }
        public DeveloperReadDto? GetById(int id)
        {
            var DeveloperFromDB = developerRepo.GetById(id);
            if (DeveloperFromDB == null)
                return null;
            return new DeveloperReadDto
            {
                Id = DeveloperFromDB.Id,
                Name = DeveloperFromDB.Name,
                Salary = DeveloperFromDB.Salary
            };
        }
        public int Add(DeveloperAddDto developerDto)
        {
            var newDeveloper = new Developer
            {
                Name = developerDto.Name
            };
            developerRepo.Add(newDeveloper);
            // newDeveloper.Id = default
            developerRepo.SaveChanges(); //====> returns the object added with its {Id} set by database provider
            // newDeveloper.Id = 157
            return newDeveloper.Id;
        }
        public bool Update(DeveloperUpdateDto developerDto)
        {
            var DeveloperFromDB = developerRepo.GetById(developerDto.Id);
            if (DeveloperFromDB == null)
                return false;
            DeveloperFromDB.Name = developerDto.Name;
            developerRepo.Update(DeveloperFromDB);
            developerRepo.SaveChanges();
            return true;
        }
        public void Delete(int id)
        {
            var DeveloperFromDB = developerRepo.GetById(id);
            if (DeveloperFromDB == null)
                return;
            developerRepo.Delete(DeveloperFromDB);
            developerRepo.SaveChanges();
        }

        #endregion
    }
}
