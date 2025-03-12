using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models;

public partial class MailCrmFinal
{
    public string? Gonderen { get; set; }

public string? Email { get; set; }

public string? Telefon { get; set; }

//public string? Mesaj { get; set; }

//public string? ReferansUrl { get; set; }

//public string? Kvkk { get; set; }

//public string? Platform { get; set; }

//public string? Dil { get; set; }

//public string? Ulke { get; set; }

//public DateTime? CreateDate { get; set; }

//public double? IsSpam { get; set; }

//public double? IsDomestic { get; set; }

//public string? Projects { get; set; }
[Key]
public int EmailId { get; set; }

//public string? UtmSource { get; set; }

//public string? UtmMedium { get; set; }

//public string? UtmCampaign { get; set; }

//public string? VmSource { get; set; }

public bool Status { get; set; }

//public DateTime? RecordDate { get; set; }

}
