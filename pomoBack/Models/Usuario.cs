﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace pomoBack.Models;

public partial class Usuario
{
    public int Iduser { get; set; }

    public string NombreUsuario { get; set; }

    public string Email { get; set; }

    public DateTime? Fecrea { get; set; }

    public int? Edad { get; set; }

    public string Pais { get; set; }

    public string Ciudad { get; set; }

    public string Password { get; set; }

    public string Img { get; set; }

    public int? EstadoConexion { get; set; }
}