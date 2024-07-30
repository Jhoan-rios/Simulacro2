using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;

namespace Clinica.Services
{
    public interface ITreatmentRepository
    {
        IEnumerable<Treatment> GetAll();
        IEnumerable<Treatment> GetAllInactivo();
        Treatment? GetById(int id);
        void Add(Treatment treatment);
        void Remove(int id);
        void Update(Treatment treatment);
    }
}