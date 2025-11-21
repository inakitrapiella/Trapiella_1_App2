using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Models
{
    public class Turno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public int PacienteId { get; set; }
    }

}
