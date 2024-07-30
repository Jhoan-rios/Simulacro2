using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;

namespace Clinica.Services
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetAllInactivo();
        Doctor? GetById(int id);
        void Add(Doctor doctor);
        void Remove(int id);
        void Activar(int id);
        void Update(Doctor doctor);
    }
}