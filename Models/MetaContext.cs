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

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.FullNames).HasColumnName("full_names");
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
