﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23CV.Entities
{
    public class Rol
    {
        [Key]
        public int PKRol { get; set; }
        public string Nombre { get; set; }
    }
}
