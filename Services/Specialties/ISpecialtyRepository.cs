using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;

namespace Clinica.Services
{
    public interface ISpecialtyRepository
    {
        IEnumerable<Specialty> GetALL();
        IEnumerable<Specialty> GetAllInactivo();
        Specialty? GetById(int id);
        void Add(Specialty specialty);
        void Remove(int id);
        void Activar(int id);
        void Update(Specialty specialty);
    }
}