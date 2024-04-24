﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MayTheFourth.Models
{
    public abstract class BaseModel
    {
        [Key]
        public long Id { get; set; }

        public static void Configure(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    var entity = modelBuilder.Entity(entityType.ClrType);
                    entity.Property<long>("Id").HasColumnName($"{entityType.ClrType.Name}Id");
                }
            }
        }

    }
}
