﻿using Microsoft.EntityFrameworkCore;
using StoneXXI.DB.Models;

namespace StoneXXI.DB.Contexts
{
    /// <summary>
    /// Контекст приложения для работы с БД
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="options">Настройки контекста</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Валюта
        /// </summary>
        public DbSet<Currency> Currencys { get; set; }

        /// <summary>
        /// Курс обмена
        /// </summary>
        public DbSet<ExchangeRate> ExchangeRate { get; set; }

    }
}
