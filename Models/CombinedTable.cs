using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models;

public partial class CombinedTable
{
    public double? DataId { get; set; }

    public string? CreatedTime { get; set; }

    public double? FormId { get; set; }

    public string? FormName { get; set; }

    public string? Platform { get; set; }

    public string? VillaTipiTercihi { get; set; }

    public string? KacOdaliVilla { get; set; }

    public string? IletisimKurulacakKanal { get; set; }

    public string? Email { get; set; }

    public string? Fullname { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Ulke { get; set; }

    public double? MetaCrmId { get; set; }

    public string? Dil { get; set; }

    public double? YatirimButcesiMiktari { get; set; }

    public string? YatirimButcesiDövizTipi { get; set; }

    public string? Projects { get; set; }

    public string? Mesaj { get; set; }

    public string? ReferansUrl { get; set; }

    public string? Kvkk { get; set; }

    public double? IsSpam { get; set; }

    public double? IsDomestic { get; set; }

    public double? EmailId { get; set; }
    public bool Status { get; set; }
    public string? EvBakmaAmaci { get; set; }
    public string? KategoriAdi { get; set; }
    public string? KategoriId { get; set; }
    [Key]
    public int PrimaryKey { get; set; }
}
