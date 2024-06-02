using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FormsProject.Repositorys.Models;

[Table("Table")]
public partial class Table
{
    public int Id { get; set; }

    [Key]
    [Column("SERIAL")]
    public int Serial { get; set; }

    [Column("OFFICE")]
    public int? Office { get; set; }

    [Column("NFILE")]
    [StringLength(50)]
    public string Nfile { get; set; } = null!;

    [Column("DFILE")]
    public DateOnly Dfile { get; set; }

    [Column("MAHDAR")]
    public int Mahdar { get; set; }

    [Column("DMAHDAR")]
    public DateOnly Dmahdar { get; set; }

    [Column("CRIME")]
    [StringLength(50)]
    public string? Crime { get; set; }

    [Column("GENERAL")]
    [StringLength(50)]
    public string? General { get; set; }

    [Column("JURY")]
    [StringLength(50)]
    public string? Jury { get; set; }

    [Column("MADBOUT")]
    [StringLength(50)]
    public string? Madbout { get; set; }

    [Column("RESUME")]
    [StringLength(50)]
    public string? Resume { get; set; }

    [Column("IRES")]
    [StringLength(50)]
    public string? Ires { get; set; }

    [Column("TYPE")]
    [StringLength(50)]
    public string? Type { get; set; }

    [Column("REM", TypeName = "text")]
    public string? Rem { get; set; }

    [Column("PROCUREUR")]
    [StringLength(50)]
    public string? Procureur { get; set; }

    [Column("KPRO")]
    public int? Kpro { get; set; }

    [Column("ACCUSE")]
    [StringLength(50)]
    public string? Accuse { get; set; }

    [Column("KACCU")]
    public int? Kaccu { get; set; }
}
