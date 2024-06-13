using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models;

public partial class MailCrmFinal
{
    public string? Gonderen { get; set; }

    public string? Email { get; set; }

    public double? Telefon { get; set; }

    public string? Mesaj { get; set; }

    public string? ReferansUrl { get; set; }

    public string? Kvkk { get; set; }

    public string? Platform { get; set; }

    public string? Dil { get; set; }

    public string? Ulke { get; set; }

    public string? CreateDate { get; set; }

    public double? IsSpam { get; set; }

    public bool? IsDomestic { get; set; }

    public string? Projects { get; set; }

    public double? EmailId { get; set; }

    public string? UtmSource { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmCampaign { get; set; }

    public string? VmSource { get; set; }

    public bool Status { get; set; }

    public DateTime? RecordDate { get; set; }
    [Key]
    public int PrimaryKey { get; set; }
}
