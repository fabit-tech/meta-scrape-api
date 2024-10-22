using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MetaApi.Models;

public partial class MetaContext : DbContext
{
    public MetaContext(DbContextOptions<MetaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CombinedTable> CombinedTables { get; set; }
    public virtual DbSet<CreateAddSetId> CreateAddSetId { get; set; }
    public virtual DbSet<MailCrmFinal> MailCrmFinal { get; set; }
    public virtual DbSet<Ihale> Ihale { get; set; }
    public virtual DbSet<IhaleBirimFiyat> IhaleBirimFiyat { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //combined table
        modelBuilder.Entity<CombinedTable>(entity =>
        {
            entity.ToTable("combined_table");

            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DataId).HasColumnName("data_id");
            entity.Property(e => e.Dil).HasColumnName("dil");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EmailId).HasColumnName("email_id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.FormName).HasColumnName("form_name");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.IletisimKurulacakKanal).HasColumnName("iletisim_kurulacak_kanal");
            entity.Property(e => e.IsDomestic).HasColumnName("is_domestic");
            entity.Property(e => e.IsSpam).HasColumnName("is_spam");
            entity.Property(e => e.KacOdaliVilla).HasColumnName("kac_odali_villa");
            entity.Property(e => e.Kvkk).HasColumnName("kvkk");
            entity.Property(e => e.Mesaj).HasColumnName("mesaj");
            entity.Property(e => e.MetaCrmId).HasColumnName("meta_crm_id");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.Platform).HasColumnName("platform");
            entity.Property(e => e.Projects).HasColumnName("projects");
            entity.Property(e => e.ReferansUrl).HasColumnName("referans_url");
            entity.Property(e => e.Ulke).HasColumnName("ulke");
            entity.Property(e => e.VillaTipiTercihi).HasColumnName("villa_tipi_tercihi");
            entity.Property(e => e.YatirimButcesiDövizTipi).HasColumnName("yatirim_butcesi_döviz_tipi");
            entity.Property(e => e.YatirimButcesiMiktari).HasColumnName("yatirim_butcesi_miktari");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.PrimaryKey).HasColumnName("primary_key");
            entity.Property(e => e.EvBakmaAmaci).HasColumnName("ev_bakma_amaci");
            entity.Property(e => e.KategoriAdi).HasColumnName("kategori_adi");
            entity.Property(e => e.KategoriId).HasColumnName("kategori_id");
            entity.Property(e => e.RecordDate).HasColumnName("record_date");
            entity.Property(e => e.OriginalFullname).HasColumnName("original_fullname");
        });
        //createAddId table
        modelBuilder.Entity<CreateAddSetId>(entity =>
        {
            entity.ToTable("create_adset_id");

            entity.Property(e => e.PrimaryId).HasColumnName("primary_id");
            entity.Property(e => e.CategoryName).HasColumnName("kategori_adi");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.Status).HasColumnName("status");
          
        });

        modelBuilder.Entity<MailCrmFinal>(entity =>
        {
            entity.ToTable("mail_crm_final");

            entity.Property(e => e.Gonderen).HasColumnName("gonderen");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Telefon).HasColumnName("telefon");
            entity.Property(e => e.Mesaj).HasColumnName("mesaj");
            entity.Property(e => e.ReferansUrl).HasColumnName("referans_url");
            entity.Property(e => e.Kvkk).HasColumnName("kvkk");
            entity.Property(e => e.Platform).HasColumnName("platform");
            entity.Property(e => e.Dil).HasColumnName("dil");
            entity.Property(e => e.Ulke).HasColumnName("ulke");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IsSpam).HasColumnName("is_spam");
            entity.Property(e => e.IsDomestic).HasColumnName("is_domestic");
            entity.Property(e => e.Projects).HasColumnName("projects");
            entity.Property(e => e.EmailId).HasColumnName("email_id");
            entity.Property(e => e.UtmSource).HasColumnName("utm_source");
            entity.Property(e => e.UtmMedium).HasColumnName("utm_medium");
            entity.Property(e => e.UtmCampaign).HasColumnName("utm_campaign");
            entity.Property(e => e.VmSource).HasColumnName("vm_source");
            entity.Property(e => e.Status).HasColumnName("status");

        });

      
        modelBuilder.Entity<Ihale>(entity =>
        {
            entity.ToTable("ihale");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RecordDate).HasColumnName("record_date");
            entity.Property(e => e.ExcelPath).HasColumnName("ecxel_path");
            entity.Property(e => e.CariId).HasColumnName("cari_id");
            entity.Property(e => e.IhaleId).HasColumnName("ihale_id");
            entity.Property(e => e.UniqueIndexId).HasColumnName("unique_index_id");
            entity.Property(e => e.GenelGiderKarYuzdesi).HasColumnName("genel_gider_kar_yuzdesi");
            entity.Property(e => e.Status).HasColumnName("status");
          

        });

        modelBuilder.Entity<IhaleBirimFiyat>(entity =>
        {
            entity.ToTable("ihale_birim_fiyat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MalzemeBirimFiyat).HasColumnName("malzeme_birim_fiyat");
            entity.Property(e => e.IhaleId).HasColumnName("ihale_id");
           
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
