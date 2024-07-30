using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;

namespace Clinica.Services
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        IEnumerable<Patient> GetAllInactivo();
        Patient? GetById(int id);
        void Add(Patient patient);
        void Remove(int id);
        void Activar(int id);
        void Update(Patient patient);
    }
}