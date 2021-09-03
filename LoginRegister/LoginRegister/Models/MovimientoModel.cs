using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegister.Models
{
    public class MovimientoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Maquinarias { get; set; }
        public string Horometro { get; set; }
        public string Descripcion { get; set; }
        public string Kilometraje { get; set; }
        public string Combustible { get; set; }
        public string FechaCarga { get; set; }
    }
}
